using System.Threading.Tasks;

namespace Ietws
{
    // https://ucdavis.jira.com/wiki/spaces/IETP/pages/132808796/Identity+Store+Primary+Kerberos+Account+API
    public class KerberosRequests : RequestBase
    {
        public KerberosRequests(IetClient client) : base(client) { }

        // Can search on iamId, userId, uuid, retType
        // return type is 'people' for people related info, default for identity store view
        public async Task<ContactResults> Search(string field, string value, string returnType = "people")
        {
            this.Url = "iam/people/prikerbacct/search";

            this.QueryItems.Add(field, value);
            this.QueryItems.Add("retType", returnType);

            return await this.GetAsync<ContactResults>();
        }

        public async Task<ContactResults> Get(string iamId)
        {
            this.Url = "iam/people/prikerbacct/" + iamId;

            return await this.GetAsync<ContactResults>();
        }
    }
}
