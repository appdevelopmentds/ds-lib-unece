namespace DS.Lib.Unece.Tests;

[TestClass]
public sealed class SimpleTests
{
    [TestMethod]
    public void Test_MTR_to_m()
    {
        string code = UnitOfMeasureUneceSIConverter.UneceToSI("MTR");
        Assert.AreEqual("m", code);
    }

    [TestMethod]
    public void Test_m_to_MTR()
    {
        string code = UnitOfMeasureUneceSIConverter.SIToUnece("m");
        Assert.AreEqual("MTR", code);
    }
    [TestMethod]
    public void Test_LS()
    {
        string code = UnitOfMeasureUneceSIConverter.UneceToSI("LS");
        Assert.AreEqual("lump sum", code);
    }
    [TestMethod]
    public void Test_MQW()
    {
        string code = UnitOfMeasureUneceSIConverter.UneceToSI("MQW");
        Assert.AreEqual("m³·wk", code);
    }
    [TestMethod]
    public void Test_UneceToSI_not_found()
    {
        var exception = Assert.ThrowsException<IndexOutOfRangeException>(() => { string siCode = UnitOfMeasureUneceSIConverter.UneceToSI("ABCD123"); });
    }
    [TestMethod]
    public void Test_SIToUnece_not_found()
    {
        var exception = Assert.ThrowsException<IndexOutOfRangeException>(() => { string siCode = UnitOfMeasureUneceSIConverter.SIToUnece("ABCD123"); });
    }

    [TestMethod]
    public void Test_try_m_to_MTR()
    {
        bool success = UnitOfMeasureUneceSIConverter.TrySIToUnece("m", out string code);
        Assert.AreEqual("MTR", code);
        Assert.IsTrue(success);
    }

    [TestMethod]
    public void Test_try_MTR_to_m()
    {
        bool success = UnitOfMeasureUneceSIConverter.TryUneceToSI("MTR", out string code);
        Assert.AreEqual("m", code);
        Assert.IsTrue(success);
    }
    
    [TestMethod]
    public void Test_try_UNCECE_not_found_without_fallback()
    {
        bool success = UnitOfMeasureUneceSIConverter.TryUneceToSI("BLAH", out string code);
        Assert.IsFalse(success);
        Assert.AreEqual("BLAH", code); // without fallback, returns the same.
    }
        [TestMethod]
    public void Test_try_UNCECE_not_found_with_fallback()
    {
        bool success = UnitOfMeasureUneceSIConverter.TryUneceToSI("BLAH", out string code, "FB");
        Assert.IsFalse(success);
        Assert.AreEqual("FB", code); // fallback
    }

    [TestMethod]
    public void Test_try_SI_not_found_without_fallback()
    {
        bool success = UnitOfMeasureUneceSIConverter.TrySIToUnece("m4", out string code);
        Assert.IsFalse(success);
        Assert.AreEqual("m4", code); // without fallback, returns the same.
    }
        [TestMethod]
    public void Test_try_SI_not_found_with_fallback()
    {
        bool success = UnitOfMeasureUneceSIConverter.TrySIToUnece("m4", out string code, "FB");
        Assert.IsFalse(success);
        Assert.AreEqual("FB", code); // fallback
    }
}
