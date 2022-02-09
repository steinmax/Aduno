using Microsoft.EntityFrameworkCore;
using ReSign.Database.Data.Entities.General;
using ReSign.Database.Data.Entities.PresenceSystem;

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
        public DbSet<Class> ClassSet { get; set; }
        public DbSet<Device> DeviceSet { get; set; }
        public DbSet<User> PupilSet { get; set; }
        public DbSet<QRSessionCookie> QRSessionCookieSet { get; set; }

        /*public ReSignDbContext(DbContextOptions<ReSignDbContext> options) : base(options)
        {
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var displayBuilder = modelBuilder.Entity<Display>();
            displayBuilder.ToTable("Display");
            displayBuilder.HasKey(x => x.Id);
            displayBuilder.Property(x => x.RowVersion)
                .IsRowVersion();
            displayBuilder.Property(x => x.MacAddress)
                .HasMaxLength(17)       //Mac address should be exactly 17 characters long
                .IsRequired();

            displayBuilder.Property(x => x.Designation)
                .HasMaxLength(64);

            displayBuilder.Property(x => x.Notes)
                .HasMaxLength(1024)
                .IsRequired();

            displayBuilder.HasOne(x => x.Room);

            var roomBuilder = modelBuilder.Entity<Room>();
            roomBuilder.ToTable("Room");
            roomBuilder.HasKey(x => x.Id);
            roomBuilder.Property(x => x.RowVersion)
                .IsRowVersion();
            roomBuilder.Property(x => x.Floor)    //U = Untergeschoss; E = Erdgeschoss; 1 = Erster Stock; 2 = Zweiter Stock
                .HasMaxLength(1)
                .IsRequired();

            /*
            roomBuilder.HasCheckConstraint(       //Check constraints stated in comment above
                name: "Floor", 
                sql: "Room.Floor = 'U' or Room.Floor = 'E' or Room.Floor = '1' or Room.Floor = '2'");
            */

            roomBuilder.Property(x => x.RoomNumber)
                .IsRequired();

            var classBuilder = modelBuilder.Entity<Class>();
            classBuilder.ToTable("Class");
            classBuilder.HasKey(c => c.Id);
            classBuilder.Property(c => c.RowVersion)
                .IsRowVersion();
            classBuilder.Property(c => c.Grade)
                .IsRequired();
            classBuilder.Property(c => c.Designation)
                .HasMaxLength(64);

            var deviceBuilder = modelBuilder.Entity<Device>();
            deviceBuilder.ToTable("Device");
            deviceBuilder.HasKey(d => d.Id);
            deviceBuilder.Property(d => d.RowVersion)
                .IsRowVersion();
            deviceBuilder.Property(d => d.UniqueId)
                .IsRequired();

            var pupilBuilder = modelBuilder.Entity<User>();
            pupilBuilder.ToTable("Pupil");
            pupilBuilder.HasKey(p => p.Id);
            pupilBuilder.Property(p => p.RowVersion)
                .IsRowVersion();
            pupilBuilder.Property(p => p.FirstName)
                .HasMaxLength(64)
                .IsRequired();
            pupilBuilder.Property(p => p.LastName)
                .HasMaxLength(64)
                .IsRequired();
            pupilBuilder.Property(p => p.MatNr)
                .HasMaxLength(15)
                .IsRequired();

            var qrsessionbuilder = modelBuilder.Entity<QRSessionCookie>();
            qrsessionbuilder.ToTable("QRSessionCookie");
            qrsessionbuilder.HasKey(qr => qr.Id);
            qrsessionbuilder.Property(qr => qr.RowVersion)
                .IsRowVersion();
            qrsessionbuilder.Property(qr => qr.DateCreated)
                .IsRequired();
            qrsessionbuilder.Property(qr => qr.IsValid)
                .IsRequired();
            qrsessionbuilder.Property(qr => qr.Token)
                .HasMaxLength(20)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
