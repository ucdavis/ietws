namespace Ietws
{
    public class PPSAssociationsResult {
        public string IamId { get; set; }
        public string deptCode { get; set; }
        public string deptOfficialName { get; set; }
        public string deptDisplayName { get; set; }
        public string deptAbbrev { get; set; }
        public bool isUCDHS { get; set; }
        public string bouOrgOId { get; set; }
        public string adminDeptCode { get; set; }
        public string adminDeptOfficialName { get; set; }
        public string adminDeptDisplayName { get; set; }
        public string adminDeptAbbrev { get; set; }
        public bool adminIsUCDHS { get; set; }
        public string adminBouOrgOId { get; set; }
        public string apptDeptCode { get; set; }
        public string apptDeptOfficialName { get; set; }
        public string apptDeptDisplayName { get; set; }
        public string apptDeptAbbrev { get; set; }
        public bool apptIsUCDHS { get; set; }
        public string apptBouOrgOId { get; set; }
        public string assocRank { get; set; }
        public string assocStartDate { get; set; }
        public string assocEndDate { get; set; }
        public string titleCode { get; set; }
        public string titleOfficialName { get; set; }
        public string titleDisplayName { get; set; }
        public string positionTypeCode { get; set; }
        public string positionType { get; set; }
        public string percentFullTime { get; set; }
        public string createDate { get; set; }
        public string modifyDate { get; set; }       
        
    }

      public class PPSAssociationIamIdResult {
        public string IamId { get; set; }
        
    }
}