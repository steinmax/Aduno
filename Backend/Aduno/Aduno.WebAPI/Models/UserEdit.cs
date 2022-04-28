using Aduno.Database.Logic.Enumerations;

namespace Aduno.WebAPI.Models
{
    public class UserEdit
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Member;
    }
}
