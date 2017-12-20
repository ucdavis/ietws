using System.Threading.Tasks;

namespace Ietws
{
    // https://ucdavis.jira.com/wiki/spaces/IETP/pages/132808788/Identity+Store+Core+People+API
    public class PeopleRequests : RequestBase
    {
        public PeopleRequests(IetClient client) : base(client) { }

        // Can search on oFirstName, oMiddleName,oLastName,dFirstName,dMiddleName,dLastName,mothraId,studentId,externalId,iamId,ppsId,bannerPIdM
        public async Task<ContactResults> Search(string field, string value)
        {
            this.Url = "iam/people/search";

            this.QueryItems.Add(field, value);

            return await this.GetAsync<ContactResults>();
        }

        public async Task<ContactResults> Get(string iamId)
        {
            this.Url = "iam/people/" + iamId;

            return await this.GetAsync<ContactResults>();
        }
    }
}
