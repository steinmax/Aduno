using Microsoft.AspNetCore.Mvc;
using ReSign.Database.Logic.Controllers;
using ReSign.Database.Logic.Entities.PresenceSystem;
using ReSign.WebAPI.Models;

namespace ReSign.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : GenericController<Database.Logic.Entities.PresenceSystem.Interaction, InteractionEdit, InteractionModel>
    {
        public InteractionController(Database.Logic.Controllers.InteractionController controller) : base(controller)
        {
        }
        
        [HttpPost]
        public override Task<ActionResult<InteractionModel>> PostAsync([FromBody] InteractionEdit model)
        {
            var ctrl = EntityController as Database.Logic.Controllers.InteractionController;


            return base.PostAsync(model);
        }
    }
}
 