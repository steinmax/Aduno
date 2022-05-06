using Microsoft.AspNetCore.Mvc;


namespace Aduno.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenceController : ControllerBase
    {
        [HttpGet("{classId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Models.PrecenceModel>>> GetPresenceListByClassId(int classId)
        {
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
                }

                return presenceResult;
            })
            .Select(t => t.Result)
            .ToList();
            
            return Ok(presenceListResult);
        }
    }
}
