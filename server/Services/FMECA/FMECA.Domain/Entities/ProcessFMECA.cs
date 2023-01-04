using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Common;
namespace FMECA.Domain.Entities;

public class ProcessFMECA:Audit
{
    public int FMECAId { get; set; }
    public int sequenceId { get; set; }
    public int ProcessLevel { get; set; }
    public string ProcessId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}
