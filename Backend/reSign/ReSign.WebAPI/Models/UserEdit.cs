using ReSign.Database.Logic.Enumerations;

namespace ReSign.WebAPI.Models
{
    public class UserEdit
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Member;
        public int OrganisationId { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
