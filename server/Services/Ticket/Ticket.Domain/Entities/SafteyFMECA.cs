using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Common;
namespace Ticket.Domain.Entities;

public class SafteyFMECA : Audit
{
    public int FMECAId { get; set; }
    public string FMECAName { get; set; } = string.Empty;
    public string Project { get; set; }=string.Empty;
    public int TopLevelPartNumber { get; set; }
    public FMECAType FMECAType { get; set; }
    public ProcessFMECAType ProcessFMECAType { get; set; }
    
}
