using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hamplant.DAL.Model
{
    [Table("SupplyCategory")]
    public class SupplyCategory: BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
