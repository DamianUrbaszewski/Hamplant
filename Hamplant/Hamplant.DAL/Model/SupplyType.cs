using System.ComponentModel.DataAnnotations.Schema;

namespace Hamplant.DAL.Model
{
    [Table("SupplyType")]
    public class SupplyType: BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
