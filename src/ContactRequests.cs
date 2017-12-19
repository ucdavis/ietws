using System.Threading.Tasks;

namespace Ietws
{
    public class ContactRequests : RequestBase {
        public ContactRequests(IetClient client) : base(client) { }

        public async Task<ContactResults> Search(string q) {

            this.Url = "iam/people/contactinfo/search";
            this.QueryItems.Add("email", "srkirkland@ucdavis.edu");

            return await this.GetAsync<ContactResults>();
        }

    }
}
