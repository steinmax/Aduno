using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReSign.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : GenericController<Database.Logic.Entities.General.Room, Models.RoomEdit, Models.RoomModel>
    {
        public RoomController(Database.Logic.Controllers.RoomController controller) : base(controller)
        {
        }
    }
}
