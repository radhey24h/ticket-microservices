using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMECA.Domain.Common;

public class Entity
{
    [Key, Column(Order = 0)]
    public int ID { get; set; }
}
