using System;
using System.Collections.Generic;

namespace Database_Connect.Models;

public partial class TblAll
{
    public string Name { get; set; } = null!;

    public int Id { get; set; }

    public string? RoleName { get; set; }

    public string? Rights { get; set; }

    public string ContactDetails { get; set; } = null!;
}
