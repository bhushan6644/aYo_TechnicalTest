using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aYo_TechnicalTest.Entites
{
    [Table("Measurement")]
    public class MeasurementDto
    {
        [Key]
        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }
        public string Active { get; set; }
    }
}
