using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamplant.DAL.Model
{
    [Table("Team")]
    public class Team : BaseEntity, IEntityWithWriteTime
    {
        public string Name { get; set; }

        public DateTimeOffset LastWriteTime { get; set; }

        public virtual List<TeamMemeber> TeamMemebers { get; set; }

        public virtual List<Bucket> Buckets { get; set; }
    }
}
