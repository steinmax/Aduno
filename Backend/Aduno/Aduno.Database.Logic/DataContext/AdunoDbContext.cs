using Aduno.Database.Logic.Entities.Base;
using Aduno.Database.Logic.Entities;

namespace Aduno.Database.Logic.DataContext
{
    internal class AdunoDbContext : DbContext
    {
        #region Testing purposes only: PostgreSQL
        private static string ConnectStr => "User ID=aduno;Password=@bb$3O1QM?;Host=student.cloud.htl-leonding.ac.at/s.rausch-schott/aduno/postgres;Port=5432;Database=aduno;";
        //private static string ConnectStr => "User ID=aduno;Password=bb$3O1QM;Host=postgres;Port=5432;Database=aduno;";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectStr);
            base.OnConfiguring(optionsBuilder);
        }
        #endregion

        public DbSet<Room>? RoomSet { get; set; }
        public DbSet<Interaction>? InteractionSet { get; set; }
        public DbSet<User>? UserSet { get; set; }
        public DbSet<Class>? ClassSet { get; set; }

        public DbSet<E>? GetDbSet<E>() where E : IdentityEntity
        {
            var result = default(DbSet<E>);

            if(typeof(E) == typeof(Room))
            {
                result = RoomSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Interaction))
            {
                result = InteractionSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(User))
            {
                result = UserSet as DbSet<E>;
            }
            else if(typeof(E) == typeof(Class))
            {
                result = ClassSet as DbSet<E>;
            }
            return result;
        }
    }
}
