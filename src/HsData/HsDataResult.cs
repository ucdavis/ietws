
namespace Ietws
{
    public class HsDataResult
    {
        public string IamId { get; set; } = string.Empty;
        public string MothraId { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public string HsExternalId { get; set; } = string.Empty;

        public string HealthEmail { get; set; } = string.Empty; // Really, the only value we care about
    }
}
