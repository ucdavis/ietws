using System;
using System.Collections.Generic;
using System.Text;

namespace ietws.PPSDepartment
{
 //https://ucdavis.jira.com/wiki/spaces/IETP/pages/132808816/Identity+Store+PPS+Departments+API
    public class PPSDepartmentResult
    {
        public string orgOId { get; set; }
        public string deptCode { get; set; }
        public string deptOfficialName { get; set; }
        public string deptDisplayName { get; set; }
        public string deptAbbrev { get; set; }
        public bool isUCDHS { get; set; }
        public string bouOrgOId { get; set; }
        public DateTime createDate { get; set; }
        public DateTime modifyDate { get; set; }
    }
}
