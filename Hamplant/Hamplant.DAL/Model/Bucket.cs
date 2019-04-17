using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamplant.DAL.Model
{
    [Table("Bucket")]
    public class Bucket : BaseEntity, IEntityWithWriteTime
    {
        public string Name { get; set; }

        public Guid TeamId { get; set; }

        public virtual Team Team { get; set; }

        public DateTimeOffset LastWriteTime { get; set; }

        public virtual List<Supply> Supplies { get; set; }
    }
}
