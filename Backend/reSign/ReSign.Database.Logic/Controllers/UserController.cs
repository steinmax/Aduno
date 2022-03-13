using ReSign.Database.Logic.Entities.PresenceSystem;

namespace ReSign.Database.Logic.Controllers
{
    public sealed class UserController : GenericController<User>
    {
        public UserController() : base()
        {
        }

        public UserController(ControllerObject other) : base(other)
        {
        }

        //further BL

        public async Task<User?> GetByNameAsync(string name)
        {
            var usr = await EntitySet.Where(e => e.Username == name).FirstOrDefaultAsync();
            return usr;
        }

        public async Task<User?> CheckCredentials(string username, string password)
        {
            var usr = await GetByNameAsync(username);
            if (usr == null)
                return null;

            if (usr.Password == password)
                return usr;
            else
                return null;
        }
    }
}
