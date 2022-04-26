using Microsoft.AspNetCore.Mvc;
using ReSign.Database.Logic.Entities;
using ReSign.Database.Logic.Enumerations;
using ReSign.WebAPI.Models;

namespace ReSign.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : GenericController<Database.Logic.Entities.Interaction, InteractionEdit, InteractionModel>
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

            var entity = await ctrl.GetLastInteractionAsync(id);

            if (entity == null)
                return NotFound();

            return ToModel(entity);
        }


        [HttpPost("{userId}/{roomId}")]
        public async Task<ActionResult<InteractionModel>> ToggleCheckState(int userId, int roomId)
        {
            var ctrl = EntityController as Database.Logic.Controllers.InteractionController;

            if (ctrl == null)
                throw new Exception("Controller null");

            Interaction? last = await ctrl.GetLastInteractionAsync(userId);

            InteractionType type = last == null ? InteractionType.CheckIn : last.Type == InteractionType.CheckIn ? InteractionType.CheckOut : InteractionType.CheckIn;

            Interaction interaction = new Interaction();
            interaction.UserId = userId;
            interaction.RoomId = roomId;
            interaction.DateTime = DateTime.Now;
            interaction.Type = type;

            Interaction act = await ctrl.InsertAsync(interaction);

            return ToModel(act);
        }
    }
}
