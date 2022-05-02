using Microsoft.AspNetCore.Mvc;
using Aduno.Database.Logic.Entities;
using Aduno.Database.Logic.Enumerations;
using Aduno.WebAPI.Models;

namespace Aduno.WebAPI.Controllers
{
    /// <summary>
    /// A generic one for the standard CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity</typeparam>
    /// <typeparam name="TModel">The type of model</typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : GenericController<Database.Logic.Entities.Interaction, InteractionEdit, InteractionModel>
    {
        public InteractionController(Database.Logic.Controllers.InteractionController controller) : base(controller)
        {
        }

        [HttpGet("absencelist/{classId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InteractionModel>> GetAbsencelist(int classId)
        {
            using var classCtrl = new Database.Logic.Controllers.ClassController();
            using var ctrl = EntityController as Database.Logic.Controllers.InteractionController;

            var users = await classCtrl.GetUsersOfClassByIdAsync(classId);

            return Ok();
        }

        [HttpGet("latest/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<InteractionModel>> GetLastInteractionAsync(int id)
        {
            var ctrl = EntityController as Database.Logic.Controllers.InteractionController;

            if (ctrl == null)
                throw new Exception("Controller null");

            var entity = await ctrl.GetLastInteractionAsync(id);

            if (entity == null)
                return NoContent();

            return Ok(ToModel(entity));
        }


        [HttpPost("{userId}/{roomId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
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

            return CreatedAtAction("Get", new { Id=act.Id }, ToModel(act));
        }
    }
}
