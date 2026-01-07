using System.Threading.Tasks;

namespace Ietws
{
    public class HsDataRequests : RequestBase
    {
        //https://iet-ws.ucdavis.edu/api/swagger-ui/index.html#/hs-data-controller/searchHealthEmail
        public HsDataRequests(IetClient client) : base(client) { }

        public async Task<HsDataResults> Search(HsDataSearchField field, string value)
        {
            //https://iet-ws.ucdavis.edu/api/iam/hsdata/email/search?iamId=
            this.Url = "iam/hsdata/email/search";

            this.QueryItems.Add(field.ToString(), value);

            return await this.GetAsync<HsDataResults>();
        }

    }
}
