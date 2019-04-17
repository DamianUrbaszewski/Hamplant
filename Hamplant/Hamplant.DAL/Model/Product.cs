using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Hamplant.Common.Enums.GeneralEnums;

namespace Hamplant.DAL.Model
{
    [Table("Product")]
    public class Product : BaseEntity, IEntityWithWriteTime
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public SupplyStatus SupplyStatus { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }

        public Guid NumberOfProductId { get; set; }

        public virtual MeasurementValue NumberOfProduct { get; set; }

        public DateTimeOffset LastWriteTime { get; set; }

        public Guid SupplyId { get; set; }

        public virtual Supply Supply { get; set; }
    }
}
