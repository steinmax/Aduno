using Aduno.Database.Logic.Enumerations;

namespace Aduno.WebAPI.Models
{
    public class UserModel : IdentityModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Member;
        public int ClassId { get; set; }
    }
}
