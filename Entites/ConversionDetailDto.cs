using aYo_TechnicalTest.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aYo_TechnicalTest.Entites
{
    [Table("ConversionDetail")]
    public class ConversionDetailDto : BaseEntity
    {
        [Key]
        public int ConversionId { get; set; }
        public int MeasurementId { get; set; }
        public decimal ConversionRate { get; set; }
        public string MetricUnit { get; set; }
        public string ImperialUnit { get; set; }
        public string Active { get; set; }
    }
}
