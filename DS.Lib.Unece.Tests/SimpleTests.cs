namespace DS.Lib.Unece.Tests;

[TestClass]
public sealed class SimpleTests
{
    [TestMethod]
    public void Test_MTR_to_m()
    {
        string code = UneceSIConverter.UneceToSI("MTR");
        Assert.AreEqual("m", code);
    }

    [TestMethod]
    public void Test_m_to_MTR()
    {
        string code = UneceSIConverter.SIToUnece("m");
        Assert.AreEqual("MTR", code);
    }
    [TestMethod]
    public void Test_UneceToSI_not_found()
    {
        // Act & Assert
        var exception = Assert.ThrowsException<IndexOutOfRangeException>(() => { string siCode = UneceSIConverter.UneceToSI("ABCD123"); });
    }
    [TestMethod]
    public void Test_SIToUnece_not_found()
    {
        // Act & Assert
        var exception = Assert.ThrowsException<IndexOutOfRangeException>(() => { string siCode = UneceSIConverter.SIToUnece("ABCD123"); });
    }
}
