using Microsoft.EntityFrameworkCore;
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

        public DbSet<Display> DisplaySet { get; set; }
        public DbSet<Room> RoomSet { get; set; }
        public DbSet<Device> DeviceSet { get; set; }
        public DbSet<User> PupilSet { get; set; }
        public DbSet<QRSessionCookie> QRSessionCookieSet { get; set; }

        public ReSignDbContext(DbContextOptions<ReSignDbContext> options) : base(options)
        {
        }

        public ReSignDbContext()
        {

        }
    }
}
