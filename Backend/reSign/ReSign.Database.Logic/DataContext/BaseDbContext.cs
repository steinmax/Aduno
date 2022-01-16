using Microsoft.EntityFrameworkCore;

namespace ReSign.Database.Logic.DataContext
{
    public class BaseDbContext : DbContext
    {
        # region Testing purposes only:
        private static string ConnectStr => "Data Source=127.0.0.1,14330; Database=resign; User Id=sa; Password=passme!1234";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectStr);
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        public DbSet<Entities.Display> DisplaySet { get; set; }
        public DbSet<Entities.Room> RoomSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var displayBuilder = modelBuilder.Entity<Entities.Display>();
            displayBuilder.ToTable("Displays");
            displayBuilder.HasKey(x => x.Id);
            displayBuilder.Property(x => x.RowVersion)
                .IsRowVersion();
            displayBuilder.Property(x => x.MacAddress)
                .HasMaxLength(17)       //Mac address should be exactly 17 characters long
                .IsRequired();

            displayBuilder.Property(x => x.Designation)
                .HasMaxLength(100);

            displayBuilder.Property(x => x.Notes)
                .HasMaxLength(1000)
                .IsRequired();

            displayBuilder.HasOne(x => x.Room);

            var roomBuilder = modelBuilder.Entity<Entities.Room>();
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

            base.OnModelCreating(modelBuilder);
        }

    }
}
