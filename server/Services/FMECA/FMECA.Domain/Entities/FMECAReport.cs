using FMECA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Domain.Entities;

public class FMECAReport:Audit
{
    public int ID { get; set; }
    public string userID { get; set; } = default!;
    public string ReportName { get; set; } = default!;
    public bool IsDefault { get; set; }
    public List<string> ReportColumn { get; set; }
}
