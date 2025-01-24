namespace DS.Lib.Unece.Tests;

[TestClass]
public class TestOverrides
{
    [TestMethod]
    public void TestOverride_UNECEtoSI()
    {
        UnitOfMeasureTranslator.OverrideUNECEtoSITranslation("MTR", "mmmmmmmmmmmmmmmmm");
        string code = UnitOfMeasureTranslator.UNECEtoSI("MTR");
        Assert.AreEqual("mmmmmmmmmmmmmmmmm", code);
    }

    [TestMethod]
    public void TestOverride_SItoUNECE()
    {
        UnitOfMeasureTranslator.OverrideSItoUNECETranslation("St", "H87");
        UnitOfMeasureTranslator.OverrideSItoUNECETranslation("m", "MMM");
        string code1 = UnitOfMeasureTranslator.SItoUNECE("St"); // returns "H87"
        Assert.AreEqual("H87", code1);
        string code2 = UnitOfMeasureTranslator.SItoUNECE("m"); // returns "MMM"
        Assert.AreEqual("MMM", code2);
    }

}
