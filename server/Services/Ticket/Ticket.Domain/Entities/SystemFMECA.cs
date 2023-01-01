using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Common;
namespace Ticket.Domain.Entities;

public class SystemFMECA : Audit
{

    public int FMECAId { get; set; }
    public int sequenceId { get; set; }
    public int PartLevel { get; set; }
    public string PartNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

