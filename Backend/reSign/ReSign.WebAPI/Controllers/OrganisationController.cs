using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReSign.Database.Logic.Controllers;
using ReSign.Database.Logic.Entities.General;

namespace ReSign.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : GenericController<Database.Logic.Entities.General.Organisation, Models.OrganisationEdit, Models.OrganisationModel>
    {
        public OrganisationController(Database.Logic.Controllers.OrganisationController controller) : base(controller)
        {
        }
    }
}
