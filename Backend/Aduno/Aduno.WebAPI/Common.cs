using Aduno.Database.Logic.Enumerations;
using System.Security.Claims;

namespace Aduno.WebAPI
{
    public class Common
    {
        public static Role? GetUserRoleFromUser(ClaimsPrincipal user)
        {
            var claim = user.FindFirst("userrole");

            if (claim == null)
                return null;

            var value = claim.Value;
            Role role = (Role)Convert.ToInt32(value);

            return role;
        }
    }
}
