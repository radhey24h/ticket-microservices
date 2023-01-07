using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Common.Enum;

namespace FMECA.Domain.Common;

public class UserDetails
{
    public int ID { get; set; }
    public string Name { get; set; } = default!;
    public int Image { get; set; }
    public int EmailID { get; set; }
    public Role Role { get; set; } 
}
