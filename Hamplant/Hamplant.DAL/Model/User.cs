using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Hamplant.Common.Enums.GeneralEnums;

namespace Hamplant.DAL.Model
{
    [Table("User")]
    public class User : BaseEntity, IEntityWithWriteTime
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string EmailAddress { get; set; }

        public Gender? Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTimeOffset LastWriteTime { get; set; }

        public virtual List<TeamMemeber> TeamMemebers { get; set; }
    }
}
