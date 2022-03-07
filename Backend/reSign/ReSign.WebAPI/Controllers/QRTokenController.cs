using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReSign.Database.Logic.Controllers;
using ReSign.Database.Logic.Entities.PresenceSystem;

namespace ReSign.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRTokenController : GenericController<Database.Logic.Entities.PresenceSystem.QRToken, Models.QRTokenEdit, Models.QRTokenModel>
    {
        public QRTokenController(Database.Logic.Controllers.QRTokenController controller) : base(controller)
        {
        }
    }
}
