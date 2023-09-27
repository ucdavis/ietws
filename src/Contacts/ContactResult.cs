namespace Ietws
{
    public class ContactResult {
        public string IamId { get; set; }

        public string Email { get; set; }
        public string CampusEmail { get; set; } //Probably null. It is when the save field is found on the person query
        public string PostalAddress { get; set; }
        public string WorkPhone { get; set; }
        public string WorkCell { get; set; }

        // Not Used?
        public string HsEmail { get; set; }



    }
}
