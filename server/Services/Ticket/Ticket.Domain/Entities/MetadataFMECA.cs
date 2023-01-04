using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Common;
using FMECA.Domain.Common.Enum;

namespace FMECA.Domain.Entities;

public class MetadataFMECA:Audit
{
    public int FMECAId { get; set; }
    public string FMECAName { get; set; } = string.Empty;
    public string Project { get; set; }=string.Empty;
    public int TopLevelPartNumber { get; set; }
    public FMECAType FMECAType { get; set; }
    public ProcessFMECAType ProcessFMECAType { get; set; }
    
}
