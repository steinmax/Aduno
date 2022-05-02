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
    public class RoomController : GenericController<Database.Logic.Entities.Room, Models.RoomEdit, Models.RoomModel>
    {
        public RoomController(Database.Logic.Controllers.RoomController controller) : base(controller)
        {
        }
    }
}
