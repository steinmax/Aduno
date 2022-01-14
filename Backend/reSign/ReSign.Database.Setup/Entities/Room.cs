﻿using ReSign.Database.Logic.Entities.Base;

namespace ReSign.Database.Logic.Entities;

public class Room : VersionObject
{
    public string Floor { get; set; }
    public int RoomNumber { get; set; }
    public string Notes { get; set; }
}