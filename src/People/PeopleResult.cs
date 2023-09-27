using System;

namespace Ietws
{
    public class PeopleResult
    {
        public string IamId { get; set; }
        public string PpsId { get; set; }
        public string EmployeeId { get; set; }
        public string MothraId { get; set; }
        public string StudentId { get; set; }
        public string BannerPidm { get; set; }
        public string ExternalId { get; set; }
        public string OFirstName { get; set; }
        public string OMiddleName { get; set; }
        public string OLastName { get; set; }
        public string OFullName { get; set; }
        public string OSuffix { get; set; }
        public string DFirstName { get; set; }
        public string DMiddleName { get; set; }
        public string DLastName { get; set; }
        public string DSuffix { get; set; }
        public string DPronouns { get; set; }
        public string DFullName { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsHSEmployee { get; set; }
        public bool IsFaculty { get; set; }
        public bool IsStudent { get; set; }
        public bool IsExternal { get; set; }
        public bool IsStaff { get; set; }
        public DateTime ModifyDate { get; set; }

        public string CampusEmail { get; set; } //This one might be the official one to use, or at leat the one to most likely have a value

        public string FirstName => string.IsNullOrWhiteSpace(DFirstName) ? OFirstName : DFirstName;
        public string MiddleName => string.IsNullOrWhiteSpace(DMiddleName) ? OMiddleName : DMiddleName;
        public string LastName => string.IsNullOrWhiteSpace(DLastName) ? OLastName : DLastName;
        public string FullName => string.IsNullOrWhiteSpace(DFullName) ? OFullName : DFullName;
    }
}
