using Microsoft.EntityFrameworkCore;
using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Entities.General;
using ReSign.Database.Logic.Entities.PresenceSystem;

namespace ReSign.Database.Logic.DataContext
{
    public class ReSignDbContext : DbContext
    {
        #region Testing purposes only: SQL-Server
        /*
        private static string ConnectStr => "Data Source=127.0.0.1,14330; Database=resign; User Id=sa; Password=passme!1234";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectStr);
            base.OnConfiguring(optionsBuilder);
        }*/
        #endregion

        #region Testing purposes only: PostgreSQL
        private static string ConnectStr => "User ID=resign;Password=@bb$3O1QM?;Host=193.122.4.14;Port=5432;Database=resign;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectStr);
            base.OnConfiguring(optionsBuilder);
        }
        #endregion

        public DbSet<Organisation>? OrganisationSet { get; set; }
        public DbSet<Room>? RoomSet { get; set; }
        public DbSet<Device>? DeviceSet { get; set; }
        public DbSet<Interaction>? InteractionSet { get; set; }
        public DbSet<QRToken>? QRTokenSet { get; set; }
        public DbSet<User>? UserSet { get; set; }

        /*
        public ReSignDbContext(DbContextOptions<ReSignDbContext> options) : base(options)
        {
        }

        public ReSignDbContext()
        {

        }
        */

        public DbSet<E> GetDbSet<E>() where E : IdentityEntity
        {
            var result = default(DbSet<E>);

            if (typeof(E) == typeof(Organisation))
            {
                result = OrganisationSet as DbSet<E>;
            }
            else if(typeof(E) == typeof(Room))
            {
                result = RoomSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Device))
            {
                result = DeviceSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Interaction))
            {
                result = InteractionSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(QRToken))
            {
                result = QRTokenSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(User))
            {
                result = UserSet as DbSet<E>;
            }
            return result;
        }
    }
}
