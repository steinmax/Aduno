using ReSign.Database.Logic.Entities.Base;

namespace ReSign.Database.Logic.Entities;

public class Display : VersionObject
{
    public string MacAddress { get; set; }
    public string Designation { get; set; }
    public string Notes { get; set; }
}