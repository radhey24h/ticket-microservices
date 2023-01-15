using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Common;
using FMECA.Domain.Common.Enum;

namespace FMECA.Domain.Entities;

public class UserDetails:Entity
{
    public string Name { get; set; } = default!;
    public int Image { get; set; }
    public int EmailID { get; set; }
    public Role Role { get; set; }
}
