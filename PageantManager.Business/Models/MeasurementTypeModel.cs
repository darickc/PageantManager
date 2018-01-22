using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Models
{
    public class MeasurementTypeModel
    {
        public int MeasurementTypeId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
    }
}