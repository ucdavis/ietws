using System.Linq;
using System.Threading.Tasks;
using ietws.PPSDepartment;
using Ietws;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;

namespace tests
{
    [TestClass]
    public class ApiTests
    {
        protected readonly string key;

        public ApiTests()
        {
            var configuration = new ConfigurationBuilder()
            .AddUserSecrets<ApiTests>()
            .Build();

            key = configuration.GetSection("Key").Value;
        }

        [TestMethod]
        public async Task CanSearchContactEmail()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.Contacts.Search(ContactSearchField.email, "srkirkland@ucdavis.edu");

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
        public async Task CanGetPersonInfo()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.People.Get("1000029584");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000029584");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPersonInfo2()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.People.Get("1000009309");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000009309");
            Assert.AreEqual(result.ResponseData.Results[0].EmployeeId, "10220155");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPersonInfo3()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.People.Search(PeopleSearchField.employeeId, "10220155");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000009309");
            Assert.AreEqual(result.ResponseData.Results[0].EmployeeId, "10220155");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPronounInfo1()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.People.Get("1000009309");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000009309");
            Assert.AreEqual(result.ResponseData.Results[0].DPronouns, null);

            Assert.IsNotNull(client);
        }

        [TestMethod, Ignore("This has not updated at time of testing. And... maybe they don't like M")]
        public async Task CanGetPronounInfo2()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.People.Get("1000091412");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000091412");
            Assert.AreEqual(result.ResponseData.Results[0].DPronouns, "M");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPronounInfo3()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.People.Get("1000219473");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000219473");
            Assert.AreEqual(result.ResponseData.Results[0].DPronouns, "He, Him");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetKerberos() {
            var client = new Ietws.IetClient(key);
            var result = await client.Kerberos.Search(KerberosSearchField.iamId, "1000029584");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000029584");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPPSIamIds()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.PPSAssociations.GetIamIds(PPSAssociationsSearchField.deptCode, "030003");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);
            
            Assert.IsTrue(result.ResponseData.Results.Length > 500);

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPPSAssociations()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.PPSAssociations.Search(PPSAssociationsSearchField.iamId, "1000029584");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000029584");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPPSAssociationsSupervisorIamId()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.PPSAssociations.Search(PPSAssociationsSearchField.iamId, "1000009309");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000009309");
            Assert.AreEqual(result.ResponseData.Results[0].reportsToIAMID, "1000029584");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPPSAssociationsWithPeopleReturnType()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.PPSAssociations.Search<PeopleResults>(PPSAssociationsSearchField.iamId, "1000029584", "people");

            // 0 is success
            Assert.AreEqual(result.ResponseStatus, 0);

            Assert.AreEqual(result.ResponseData.Results[0].IamId, "1000029584");

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPPSDepartmentByDeptCode()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.PpsDepartment.Search(PPSDepartmentSearchField.deptCode, "030000");

            Assert.AreEqual(result.ResponseStatus, 0);
            Assert.AreEqual(result.ResponseData.Results[0].deptDisplayName, "AGR & ENV SCI DEANS OFFICE");
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPPSDepartmentByOrgOId()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.PpsDepartment.Search(PPSDepartmentSearchField.orgOId, "F80B657CA26C23A0E0340003BA8A560D");

            Assert.AreEqual(result.ResponseStatus, 0);
            Assert.AreEqual(result.ResponseData.Results[0].deptDisplayName, "AGR & ENV SCI DEANS OFFICE");
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public async Task CanGetPPSDepartmentWhenNotFound()
        {
            var client = new Ietws.IetClient(key);
            var result = await client.PpsDepartment.Search(PPSDepartmentSearchField.deptCode, "099000");

            Assert.AreEqual(result.ResponseStatus, 0);
            Assert.AreEqual(result.ResponseData.Results.Length, 0);
            Assert.IsNotNull(client);
        }
    }
}
