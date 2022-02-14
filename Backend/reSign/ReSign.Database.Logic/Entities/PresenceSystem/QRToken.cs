using Microsoft.EntityFrameworkCore;
using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Entities.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSign.Database.Logic.Entities.PresenceSystem
{
    [Table("QRToken")]
    [Index(nameof(Token), IsUnique = true)]
    public class QRToken : VersionEntity
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required]
        public bool IsValid { get; set; } = true;

        [Column("UsedByDeviceId")]
        public int? DeviceId { get; set; }
        
        public int? DisplayId { get; set; }

     
        //navigation
        public Device? UsedByDevice { get; set; }
        public Display? Display { get; set; }
    }
}
