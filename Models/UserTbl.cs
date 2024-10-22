using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database_Connect.Models;

public partial class UserTbl
{
  
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ContactDetails { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual RoleTbl? Role { get; set; } = null!;
}
