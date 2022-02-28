using ReSign.Database.Logic.Controllers;
using ReSign.Database.Logic.Entities.PresenceSystem;
using ReSign.WebAPI.Models;

namespace ReSign.WebAPI.Controllers
{
    public class InteractionController : GenericController<Database.Logic.Entities.PresenceSystem.Interaction, InteractionEdit, InteractionModel>
    {
        public InteractionController(Database.Logic.Controllers.InteractionController controller) : base(controller)
        {
        }
    }
}
 