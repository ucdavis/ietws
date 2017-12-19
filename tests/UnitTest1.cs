using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            var client = new Ietws.IetClient("55ca637-8e507-0ef3e05-33121788-02ada");
            var result = await client.Contacts.Search("query");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000029584");

            Assert.IsNotNull(client);
        }
    }
}
