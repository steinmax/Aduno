using Microsoft.AspNetCore.Mvc;

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
    }
}
