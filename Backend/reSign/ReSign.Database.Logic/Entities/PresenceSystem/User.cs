﻿using Microsoft.EntityFrameworkCore;
using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Entities.General;
using ReSign.Database.Logic.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSign.Database.Logic.Entities.PresenceSystem;

[Table("User"), Index(nameof(FirstName), nameof(LastName), nameof(OrganisationId))]
public class User : VersionObject
{
    [Required(), MaxLength(128)]
    public string FirstName { get; set; } = string.Empty;

    [Required(), MaxLength(128)]
    public string LastName { get; set; } = string.Empty;

    [Required()]
    public Role Role { get; set; } = Role.Member;

    //reference
    public int OrganisationId { get; set; }

    //navigation
    public Organisation? Organisation { get; set; }
    public List<Device> Devices { get; set; } = new();

}