namespace TechnicalAxosTest
{
    [TestClass]
    public class TestRemoteFunctions
    {
        [TestMethod]
        public void TestListCountries()
        {
            var response = TechnicalAxosServices.Country.List().Result;
            Assert.IsTrue(response.Success, response.Message);
        }
    }
}