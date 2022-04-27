using Microsoft.AspNetCore.Mvc;

namespace Aduno.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : GenericController<Database.Logic.Entities.Room, Models.RoomEdit, Models.RoomModel>
    {
        public RoomController(Database.Logic.Controllers.RoomController controller) : base(controller)
        {
        }
    }
}
