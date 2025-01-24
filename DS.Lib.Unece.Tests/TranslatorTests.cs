using System.Diagnostics;
using System.Globalization;

namespace DS.Lib.Unece.Tests;

[TestClass]
public sealed class TranslatorTests
{
    private long memoryBefore = 0;

    [TestInitialize]
    public void Setup()
    {
        // Garbage Collector ausführen, um Speichermessung genauer zu machen
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        // Speicher vor der Ausführung messen
        this.memoryBefore = GC.GetTotalMemory(forceFullCollection: true);
    }

    [TestCleanup]
    public void CleanUp()
    {
        // Speicher nach der Ausführung messen
        long memoryAfter = GC.GetTotalMemory(forceFullCollection: true);

        // Arbeitsspeicherverbrauch berechnen
        long memoryUsed = memoryAfter - memoryBefore;

        // Ausgabe oder Testbedingung
        Debug.WriteLine($"Memory Used: {memoryUsed / 1024.0 / 1024.0} MB");

        // Assertion: Arbeitsspeicherverbrauch sollte kleiner als ein Grenzwert sein (z. B. 11 MB)
        Assert.IsTrue(memoryUsed < 11_000_000);
    }

    [TestMethod]
    public void Test_MTR_to_m()
    {
        string code = UnitOfMeasureTranslator.UNECEtoSI("MTR");
        Assert.AreEqual("m", code);
    }

    [TestMethod]
    public void Test_m_to_MTR()
    {
        string code = UnitOfMeasureTranslator.SItoUNECE("m");
        Assert.AreEqual("MTR", code);
    }
    [TestMethod]
    public void Test_LS()
    {
        string code = UnitOfMeasureTranslator.UNECEtoSI("LS");
        Assert.AreEqual("lump sum", code);
    }

    [TestMethod]
    public void Test_LS_de()
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
        Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
        string code = UnitOfMeasureTranslator.UNECEtoSI("LS");
        Assert.AreEqual("Pauschal", code);
    }

    [TestMethod]
    public void Test_MQW()
    {
        string code = UnitOfMeasureTranslator.UNECEtoSI("MQW");
        Assert.AreEqual("m³·wk", code);
    }
    [TestMethod]
    public void Test_UneceToSI_not_found()
    {
        var exception = Assert.ThrowsException<IndexOutOfRangeException>(() => { string siCode = UnitOfMeasureTranslator.UNECEtoSI("ABCD123"); });
    }
    [TestMethod]
    public void Test_SIToUnece_not_found()
    {
        var exception = Assert.ThrowsException<IndexOutOfRangeException>(() => { string siCode = UnitOfMeasureTranslator.SItoUNECE("ABCD123"); });
    }

    [TestMethod]
    public void Test_try_m_to_MTR()
    {
        bool success = UnitOfMeasureTranslator.TrySItoUNECE("m", out string code);
        Assert.AreEqual("MTR", code);
        Assert.IsTrue(success);
    }

    [TestMethod]
    public void Test_try_MTR_to_m()
    {
        bool success = UnitOfMeasureTranslator.TryUNECEtoSI("MTR", out string code);
        Assert.AreEqual("m", code);
        Assert.IsTrue(success);
    }

    [TestMethod]
    public void Test_try_UNCECE_not_found_without_fallback()
    {
        bool success = UnitOfMeasureTranslator.TryUNECEtoSI("BLAH", out string code);
        Assert.IsFalse(success);
        Assert.AreEqual("BLAH", code); // without fallback, returns the same.
    }
    [TestMethod]
    public void Test_try_UNCECE_not_found_with_fallback()
    {
        bool success = UnitOfMeasureTranslator.TryUNECEtoSI("BLAH", out string code, "FB");
        Assert.IsFalse(success);
        Assert.AreEqual("FB", code); // fallback
    }

    [TestMethod]
    public void Test_try_SI_not_found_without_fallback()
    {
        bool success = UnitOfMeasureTranslator.TrySItoUNECE("m4", out string code);
        Assert.IsFalse(success);
        Assert.AreEqual("m4", code); // without fallback, returns the same.
    }
    [TestMethod]
    public void Test_try_SI_not_found_with_fallback()
    {
        bool success = UnitOfMeasureTranslator.TrySItoUNECE("m4", out string code, "FB");
        Assert.IsFalse(success);
        Assert.AreEqual("FB", code); // fallback
    }
}
