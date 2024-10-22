using System;
using System.Collections.Generic;

namespace Database_Connect.Models;

public partial class RoleTbl
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public int RightsId { get; set; }

    public virtual RightsTbl Rights { get; set; } = null!;

    public virtual ICollection<UserTbl> UserTbls { get; set; } = new List<UserTbl>();
}
