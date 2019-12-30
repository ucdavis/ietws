using System.Threading.Tasks;

namespace Ietws
{
    public class PPSAssociationsRequests : RequestBase
    {
        public PPSAssociationsRequests(IetClient client) : base(client) { }

        // https://ucdavis.jira.com/wiki/spaces/IETP/pages/132808762/Identity+Store+PPS+Associations+API
        // Can search on iamId , deptCode , isUCDHS , adminDeptCode , adminIsUCDHS , apptDeptCode , apptIsUCDHS , bouOrgOId , titleCode , assocRank
        // retType can be 'people' or 'default'
        public async Task<PPSAssociationResults> Search(PPSAssociationsSearchField field, string value, string retType = "default")
        {

            this.Url = "iam/associations/pps/search";

            this.QueryItems.Add(field.ToString(), value);

            return await this.GetAsync<PPSAssociationResults>();
        }

        public async Task<PPSAssociationIamIdResults> GetIamIds(PPSAssociationsSearchField field, string value, string retType = "default")
        {
            this.Url = "iam/associations/pps/search";

            this.QueryItems.Add(field.ToString(), value);

            this.QueryItems.Add("retType", "iamids");

            return await this.GetAsync<PPSAssociationIamIdResults>();

        }



        public async Task<PPSAssociationResults> Get(string iamId)
        {
            this.Url = "iam/associations/pps/" + iamId;

            return await this.GetAsync<PPSAssociationResults>();
        }
    }
}