using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Entities
{
    public class MeasurementType
    {
        [Key]
        public int MeasurementTypeId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
    }
}