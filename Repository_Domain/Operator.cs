using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository_Domain
{
    [Serializable]
    [Table("Operator")]
    public partial class Operator : IEntity<int>
    {
        [Key] public int OperatorID { get; set; }

        [Required] [StringLength(50)] public string OperatorName { get; set; }

        [Required] [StringLength(15)] public string  SimName { get; set; }

        [Required] [StringLength(10)] public string NidNo { get; set; }

        [Required] [StringLength(15)] public string CellPhoneNo { get; set; }
    }
}