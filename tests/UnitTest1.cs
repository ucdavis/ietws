using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        const string key = "55ca637-8e507-0ef3e05-33121788-02ada";

        [TestMethod]
        public async Task CanSearchContactEmail()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.Contacts.Search("email", "srkirkland@ucdavis.edu");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000029584");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetContactInfo() {
            var client = new Ietws.IetClient(key);
            var result = await client.Contacts.Get("1000029584");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000029584");

            Assert.IsNotNull(client);
        }
    }
}
