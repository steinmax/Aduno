using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSign.Database.Logic.DataContext
{
    public class BaseDbContext : DbContext
    {
        # region Testing purposes only:
        private static string ConnectStr => "";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.
            base.OnConfiguring(optionsBuilder);
        }

        #endregion
        public DbSet<Entities.Display> DisplaySet { get; set; }
        public DbSet<Entities.Room> RoomSet { get; set; }
        public DbSet<Entities.DisplayRoomMap> DisplayRoomMapSet { get; set; }

    }
}
