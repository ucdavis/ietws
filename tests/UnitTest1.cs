using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        const string key = "";

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

        [TestMethod]
        public async Task CanGetKerberos() {
            var client = new Ietws.IetClient(key);
            var result = await client.Kerberos.Search("iamId", "1000029584");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000029584");

            Assert.IsNotNull(client);
        }
    }
}
