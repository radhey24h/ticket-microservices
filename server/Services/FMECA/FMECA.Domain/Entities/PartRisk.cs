using FMECA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Domain.Entities;

public class PartRisk : Entity
{
    [ForeignKey("fk_FMECANumber")]
    public string FMECANumber { get; set; }
    public int SequenceId { get; set; }
    public int PartLevel { get; set; }
    public string PartNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

