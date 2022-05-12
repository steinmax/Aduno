using Aduno.Database.Logic.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Aduno.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PresenceController : ControllerBase
    {
        [HttpGet("{classId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Models.PrecenceModel>>> GetPresenceListByClassId(int classId)
        {
            if(Common.HasRole(User, Role.Admin) == false)
                return Unauthorized();

            using var classCtrl = new Database.Logic.Controllers.ClassController();
            var users = await classCtrl.GetUsersOfClassByIdAsync(classId);

            if(users == null)
                return NotFound();

            using var interactionCtrl = new Database.Logic.Controllers.InteractionController(classCtrl);
            using var userCtrl = new Database.Logic.Controllers.UserController(classCtrl);

            var presenceListResult = users.Select(async (u) =>
            {
                var lastInteraction = await interactionCtrl.GetLastInteractionOfTodayAsync(u.Id);
                var presenceResult = new Models.PrecenceModel()
                {
                    UserId = u.Id,
                    IsPresent = false
                };
                presenceResult.CopyFrom(u);

                if (lastInteraction != null)
                {
                    presenceResult.IsPresent = lastInteraction.Type == Database.Logic.Enumerations.InteractionType.CheckIn ? true : false;
                    presenceResult.Time = lastInteraction.DateTime;
                }

                return presenceResult;
            })
            .Select(t => t.Result)
            .ToList();
            
            return Ok(presenceListResult);
        }
    }
}
