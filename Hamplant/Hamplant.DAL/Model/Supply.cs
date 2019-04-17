using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Hamplant.Common.Enums.GeneralEnums;

namespace Hamplant.DAL.Model
{
    [Table("Supply")]
    public class Supply: BaseEntity, IEntityWithWriteTime
    {
        public SupplyStatus SupplyStatus { get; set; }

        public Guid SupplyTypeId { get; set; }

        public virtual SupplyType SupplyType { get; set; }

        public Guid NumberOfSuppliesId { get; set; }

        public virtual MeasurementValue NumberOfSupplies { get; set; }

        public bool isRequired { get; set; }

        public int DaysToExpiration { get; set; }

        public DateTimeOffset LastWriteTime { get; set; }

        public Guid BucketId { get; set; }

        public virtual Bucket Bucket { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
