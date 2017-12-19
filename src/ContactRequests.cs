using System.Threading.Tasks;

namespace Ietws
{
    public class ContactRequests : RequestBase {
        public ContactRequests(IetClient client) : base(client) { }

        // https://ucdavis.jira.com/wiki/spaces/IETP/pages/132808797/Identity+Store+Contact+Info+API
        // Can search on iamId, email, hsEmail, campusEmail, refType
        public async Task<ContactResults> Search(string field, string value) {

            this.Url = "iam/people/contactinfo/search";

            this.QueryItems.Add(field, value);

            return await this.GetAsync<ContactResults>();
        }

        public async Task<ContactResults> Get(string iamId) {
            this.Url = "iam/people/contactinfo/" + iamId;

            return await this.GetAsync<ContactResults>();
        }
    }
}
