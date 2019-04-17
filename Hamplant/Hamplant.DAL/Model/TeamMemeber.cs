using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamplant.DAL.Model
{
    [Table("TeamMemeber")]
    public class TeamMemeber: BaseEntity
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
