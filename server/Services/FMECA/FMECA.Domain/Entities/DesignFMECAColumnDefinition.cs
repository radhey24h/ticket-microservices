using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Common;
namespace FMECA.Domain.Entities;

public class DesignFMECAColumnDefinition : Audit
{
    [Key]
    public string Name { get; set; } = default!;
    public string Header { get; set; } = default!;
    public string DataType { get; set; } = default!;
    public string Description { get; set; } = string.Empty;

}
