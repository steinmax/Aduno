using ReSign.Database.Logic.Entities;

namespace ReSign.Database.Logic.Controllers
{
    public sealed class InteractionController : GenericController<Interaction>
    {
        public InteractionController() : base()
        {
        }

        public InteractionController(ControllerObject other) : base(other)
        {
        }

        //further Business logics

        public async Task<Interaction?> GetLastInteractionAsync(int userId)
        {
            using var userController = new UserController(this);
            var user = await userController.GetByIdAsync(userId);

            if (user == null)
                return null;

            var lastInteraction = EntitySet.Where(e => e.UserId == userId)
                                            .OrderBy(e => e.DateTime)
                                            .FirstOrDefault();

            return lastInteraction;
        }

        public async Task<Interaction?> GetLastInteractionOfDateAsync(int userId, DateTime filterDate)
        {
            using var userCtrl = new UserController(this);
            var user = await userCtrl.GetByIdAsync(userId);

            if (user == null)
                return null;

            var lastInteraction = EntitySet.Where(i => i.UserId == userId 
                                                        && i.DateTime.Date == filterDate.Date)
                                            .OrderBy(i => i.DateTime)
                                            .FirstOrDefault();
            return lastInteraction;
        }
    }
}
