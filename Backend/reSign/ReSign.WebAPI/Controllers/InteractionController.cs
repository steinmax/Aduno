using Microsoft.AspNetCore.Mvc;
using ReSign.Database.Logic.Controllers;
using ReSign.Database.Logic.Entities.PresenceSystem;
using ReSign.Database.Logic.Enumerations;
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

        [HttpGet("latest/{id}")]
        public async Task<ActionResult<InteractionModel>> GetLastInteractionAsync(int id)
        {
            var ctrl = EntityController as Database.Logic.Controllers.InteractionController;

            if (ctrl == null)
                throw new Exception("Controller null");

            return ToModel(await ctrl.GetLastInteraction(id));
        }


        [HttpPost("{id}/{roomId}/{qrtokenId}")]
        public async Task<ActionResult<InteractionModel>> ToggleCheckState(int id, int roomId, int qrtokenId)
        {
            var ctrl = EntityController as Database.Logic.Controllers.InteractionController;

            if (ctrl == null)
                throw new Exception("Controller null");
            
            Interaction last = await ctrl.GetLastInteraction(id);

            InteractionType type = last == null ? InteractionType.CheckIn : last.Type == InteractionType.CheckIn ? InteractionType.CheckOut : InteractionType.CheckIn;

            Interaction interaction = new Interaction();
            interaction.UserId = id;
            interaction.RoomId = roomId;
            interaction.QRTokenId = qrtokenId;
            interaction.DateTime = DateTime.Now;
            interaction.Type = type;

            Interaction act = await ctrl.InsertAsync(interaction);

            return ToModel(act);
        }
    }
}
 