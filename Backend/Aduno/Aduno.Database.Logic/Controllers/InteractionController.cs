using Aduno.Database.Logic.Entities;
using Aduno.Database.Logic.Enumerations;

namespace Aduno.Database.Logic.Controllers
{
    public sealed class InteractionController : GenericController<Interaction>
    {
        public InteractionController() : base()
        {
        }

        public InteractionController(ControllerObject other) : base(other)
        {
        }

        //further Business logics

        public Task<Interaction?> GetLastInteractionAsync(int userId)
        {
            return GetLastInteractionOfDateAsync(userId, null);
        }

        public async Task<Interaction?> GetLastInteractionOfDateAsync(int userId, DateTime? filterDate)
        {
            using var userCtrl = new UserController(this);
            var user = await userCtrl.GetByIdAsync(userId);

            if (user == null)
                return null;

            var lastInteraction = EntitySet.Where(i => i.UserId == userId 
                                                        && (filterDate == null || i.DateTime.Date == filterDate.Value.Date))
                                            .OrderByDescending(i => i.DateTime)
                                            .FirstOrDefault();
            return lastInteraction;
        }

        public Task<Interaction?> GetLastInteractionOfTodayAsync(int userId)
        {
            return GetLastInteractionOfDateAsync(userId, DateTime.Today);
        }

        public async Task<Interaction?> TogglePresenceState(int userId, int roomId)
        {
            using var userCtrl = new UserController(this);
            var user = await userCtrl.GetByIdAsync(userId);

            if (user == null)
                return null;

            using var roomCtrl = new RoomController(this);
            var room = await roomCtrl.GetByIdAsync(roomId);

            if (room == null)
                return null;

            using var interactionCtrl = new InteractionController(this);

            //Build entity to persist
            Interaction? last = await interactionCtrl.GetLastInteractionAsync(userId);

            InteractionType type = last == null ? InteractionType.CheckIn : last.Type == InteractionType.CheckIn ? InteractionType.CheckOut : InteractionType.CheckIn;

            var interaction = new Interaction
            {
                UserId = userId,
                RoomId = roomId,
                DateTime = DateTime.Now,
                Type = type
            };

            await interactionCtrl.InsertAsync(interaction);
            await SaveChangesAsync();

            return interaction;
        }
    }
}
