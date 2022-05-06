using Microsoft.AspNetCore.Mvc;
using Aduno.Common.Logic.Extensions;

namespace Aduno.WebAPI.Controllers
{
    /// <summary>
    /// A generic one for the standard CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity</typeparam>
    /// <typeparam name="TModel">The type of model</typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : GenericController<Database.Logic.Entities.Class, Models.ClassEdit, Models.ClassModel>
    {
        public ClassController(Database.Logic.Controllers.ClassController controller) : base(controller)
        {
        }

        [HttpGet("{id}/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Models.UserModel>>> GetUsersByClassId(int id)
        {
            using var ctrl = new Database.Logic.Controllers.ClassController();

            var result = await ctrl.GetUsersOfClassByIdAsync(id);
            if(result == null)
                return NotFound();

            return Ok(result.Select(u =>
            {
                var model = new Models.UserModel();
                model.CopyFrom(u);
                return model;
            }));
        } 
    }
}
