using ReSign.Database.Logic.Entities.PresenceSystem;
using ReSign.Database.Logic.Enumerations;

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

        //further BL

        public async Task<InteractionType?> GetCurrentInteractionType(int userId)
        {
            using var userController = new UserController(this);
            var user = await userController.GetByIdAsync(userId);

            if (user == null)
                return null;
        }
    }
}
