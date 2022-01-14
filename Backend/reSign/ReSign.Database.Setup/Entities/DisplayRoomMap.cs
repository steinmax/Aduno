namespace ReSign.Database.Logic.Entities
{
    public class DisplayRoomMap
    {
        public int DisplayId { get; set; }
        public int RoomId { get; set; }

        //Navigation
        public Display Display { get; set; }
        public Room Room { get; set; }
    }
}
