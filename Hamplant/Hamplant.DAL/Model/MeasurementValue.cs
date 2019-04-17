using System.ComponentModel.DataAnnotations.Schema;

namespace Hamplant.DAL.Model
{
    [Table("MeasurementValue")]
    public class MeasurementValue: BaseEntity
    {
        public int? Percentage { get; set; }

        public double? Quantity { get; set; }

        public double? Weight { get; set; }
    }
}
