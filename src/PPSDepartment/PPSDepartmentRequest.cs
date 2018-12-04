using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ietws;

namespace ietws.PPSDepartment
{

    public class PPSDepartmentRequest : RequestBase
    {
        
        public PPSDepartmentRequest(IetClient client) : base(client) { }

        //curl -i -H "Accept: application/json" https://iet-ws.ucdavis.edu/api/iam/orginfo/pps/depts/search?deptCode=061419&key=myKey&v=1.0
        public async Task<PPSDepartmentResults> Search(string value)
        {

            this.Url = "iam/orginfo/pps/depts/search";

            this.QueryItems.Add("deptCode", value); //They can also search by a guid... but I don't care

            return await this.GetAsync<PPSDepartmentResults>();
        }
    }
}
