using System.Threading.Tasks;

namespace Ietws
{
    public class PPSAssociationsRequests : RequestBase {
        public PPSAssociationsRequests(IetClient client) : base(client) { }

        // https://ucdavis.jira.com/wiki/spaces/IETP/pages/132808762/Identity+Store+PPS+Associations+API
        // Can search on iamId , deptCode , isUCDHS , adminDeptCode , adminIsUCDHS , apptDeptCode , apptIsUCDHS , bouOrgId , titleCode , assocRank , retType
        public async Task<ContactResults> Search(PPSAssociationsSearchField field, string value, ReturnType retType = ReturnType.@default) {

            this.Url = "iam/associations/pps/search";

            this.QueryItems.Add(field.ToString(), value);

            if (retType != ReturnType.@default)
            {
                this.QueryItems.Add("retType", retType);
                return await this.GetAsync<PPSAssociationIamIdResults>();
            }

            return await this.GetAsync<PPSAssociationsResults>();
        }

        public async Task<ContactResults> Get(string iamId) {
            this.Url = "iam/associations/pps/" + iamId;

            return await this.GetAsync<PPSAssociationsResults>();
        }
    }
}