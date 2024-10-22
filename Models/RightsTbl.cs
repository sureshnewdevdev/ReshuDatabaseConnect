using System;
using System.Collections.Generic;

namespace Database_Connect.Models;

public partial class RightsTbl
{
    public int RightsId { get; set; }

    public string? Rights { get; set; }

    public virtual ICollection<RoleTbl> RoleTbls { get; set; } = new List<RoleTbl>();
}
