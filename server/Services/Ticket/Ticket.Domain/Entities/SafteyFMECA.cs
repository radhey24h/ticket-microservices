using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Common;
namespace FMECA.Domain.Entities;

public class SafteyFMECA : Audit
{
    public int FMECAId { get; set; }
    public int sequenceId { get; set; }
    public int PartLevel { get; set; }
    public string PartNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

