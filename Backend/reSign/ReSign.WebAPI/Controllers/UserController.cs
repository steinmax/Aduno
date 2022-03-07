using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReSign.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<Database.Logic.Entities.PresenceSystem.User, Models.UserEdit, Models.UserModel>
    {
        public UserController(Database.Logic.Controllers.UserController controller) : base(controller)
        {
        }
    }
}
