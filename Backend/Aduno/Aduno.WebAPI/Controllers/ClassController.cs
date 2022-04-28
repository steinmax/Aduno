namespace Aduno.WebAPI.Controllers
{
    public class ClassController : GenericController<Database.Logic.Entities.Class, Models.ClassEdit, Models.ClassModel>
    {
        public ClassController(Database.Logic.Controllers.ClassController controller) : base(controller)
        {
        }


    }
}
