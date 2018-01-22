namespace PageantManager.Business.Models
{
    public class GarmentMeasurementTypeModel
    {
        public int GarmentMeasurementTypeId { get; set; }

        public int GarmentTypeId { get; set; }
        public int MeasurementTypeId { get; set; }

        public MeasurementTypeModel MeasurementType { get; set; }
    }
}