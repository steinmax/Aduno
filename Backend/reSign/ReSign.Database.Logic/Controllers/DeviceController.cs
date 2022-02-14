using ReSign.Database.Logic.Entities.PresenceSystem;

namespace ReSign.Database.Logic.Controllers
{
    public sealed class DeviceController : GenericController<Device>
    {
        public DeviceController() : base()
        {
        }

        public DeviceController(ControllerObject other) : base(other)
        {
        }

        //Further business logic (on top of CRUD)

    }
}
