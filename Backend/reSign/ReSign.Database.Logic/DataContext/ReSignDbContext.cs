using Microsoft.EntityFrameworkCore;

namespace ReSign.Database.Logic.DataContext
{
    public class ReSignDbContext : DbContext
    {
        # region Testing purposes only:
        private static string ConnectStr => "Data Source=127.0.0.1,14330; Database=resign; User Id=sa; Password=passme!1234";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectStr);
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        public DbSet<Entities.General.Display> DisplaySet { get; set; }
        public DbSet<Entities.General.Room> RoomSet { get; set; }
        public DbSet<Entities.General.Class> ClassSet { get; set; }
        public DbSet<Entities.PresenceSystem.Device> DeviceSet { get; set; }
        public DbSet<Entities.PresenceSystem.Pupil> PupilSet { get; set; }
        public DbSet<Entities.PresenceSystem.QRSessionCookie> QRSessionCookieSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var displayBuilder = modelBuilder.Entity<Entities.General.Display>();
            displayBuilder.ToTable("Displays");
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

            var roomBuilder = modelBuilder.Entity<Entities.General.Room>();
            roomBuilder.ToTable("Rooms");
            roomBuilder.HasKey(x => x.Id);
            roomBuilder.Property(x => x.RowVersion)
                .IsRowVersion();
            roomBuilder.Property(x => x.Floor)    //U = Untergeschoss; E = Erdgeschoss; 1 = Erster Stock; 2 = Zweiter Stock
                .IsRequired();

            roomBuilder.HasCheckConstraint(       //Check constraints stated in comment above
                name: "Floor", 
                sql: "Floor = 'U' or Floor = 'E' or Floor = '1' or Floor = '2'");

            roomBuilder.Property(x => x.RoomNumber)
                .IsRequired();

            var classBuilder = modelBuilder.Entity<Entities.General.Class>();
            classBuilder.ToTable("Classes");
            classBuilder.HasKey(c => c.Id);
            classBuilder.Property(c => c.RowVersion)
                .IsRowVersion();
            classBuilder.Property(c => c.Grade)
                .IsRequired();
            classBuilder.Property(c => c.Designation)
                .HasMaxLength(64);

            var deviceBuilder = modelBuilder.Entity<Entities.PresenceSystem.Device>();
            deviceBuilder.ToTable("Devices");
            deviceBuilder.HasKey(d => d.Id);
            deviceBuilder.Property(d => d.RowVersion)
                .IsRowVersion();
            deviceBuilder.Property(d => d.UniqueId)
                .IsRequired();

            var pupilBuilder = modelBuilder.Entity<Entities.PresenceSystem.Pupil>();
            pupilBuilder.ToTable("Pupils");
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

            var qrsessionbuilder = modelBuilder.Entity<Entities.PresenceSystem.QRSessionCookie>();
            qrsessionbuilder.ToTable("QRSessionCookies");
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
