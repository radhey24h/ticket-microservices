using FMECA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Domain.Entities;

public class ProcessRisk:Entity
{
    public int SequenceID { get; set; }
    public int ProcessLevel { get; set; }
    public string ProcessId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}
