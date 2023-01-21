using FMECA.Domain.Common;
using FMECA.Domain.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Domain.Entities;

public class ProcessRiskColumnDefinition : Entity
{
    [Required]
    public string ColumnName { get; set; } = default!;
    [Required]
    public FMECAType FMECAType { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Header { get; set; } = default!;
    public string DataType { get; set; } = default!;
    public string Description { get; set; } = string.Empty;

}
