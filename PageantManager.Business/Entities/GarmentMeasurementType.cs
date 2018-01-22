using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Entities
{
    public class GarmentMeasurementType
    {
        [Key]
            public int GarmentMeasurementTypeId { get; set; }
    
            public int GarmentTypeId { get; set; }
            public int MeasurementTypeId { get; set; }
    
            public GarmentType GarmentType { get; set; }
            public MeasurementType MeasurementType { get; set; }
    }
}