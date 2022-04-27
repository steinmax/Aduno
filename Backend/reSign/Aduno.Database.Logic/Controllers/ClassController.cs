namespace Aduno.Database.Logic.Controllers
{
    public class ClassController : GenericController<Entities.Class>
    {
        public ClassController() : base()
        {
        }

        public ClassController(ControllerObject other) : base(other)
        {
        }


        //further business logic

        public async Task<IEnumerable<Entities.User>?> GetUsersOfClassByIdAsync(int id)
        {
            var _class = await GetByIdAsync(id);
            if (_class == null)
                return null;

            return _class.Users;
        }

        //public async Task InsertUserToClass

    }
}
