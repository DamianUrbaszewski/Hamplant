using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamplant.DAL.Model
{
    [Table("SupplyTypeDefinition")]
    public class SupplyTypeDefinition: BaseEntity
    {
        public Guid SupplyTypeId { get; set; }

        public virtual SupplyType SupplyType { get; set; }

        public Guid SupplyCategoryId { get; set; }

        public virtual SupplyCategory SupplyCategory { get; set; }

        public int Order { get; set; }
    }
}
