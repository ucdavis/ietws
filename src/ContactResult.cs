namespace Ietws
{
    public class ContactResult {
        public string IamId { get; set; }

        public string Email { get; set; }
        public string CampusEmail { get; set; }
        public string PostalAddress { get; set; }
        public string WorkPhone { get; set; }
        
    }

    public class KerberosResult {
        public string IamId { get; set; }
        public string PpsId { get; set; }
        public string UserId { get; set; }
        public string oFirstName { get; set; }
        public string oMiddleName { get; set; }
        public string oLastName { get; set; }
        public string oFullName { get; set; }
        public string oSuffix { get; set; }
    }
}
