namespace PageantManager.Business.Models
{
    public class GarmentMeasurementModel
    {
        public int GarmentMeasurementId { get; set; }
        public int GarmentId { get; set; }
        public int MeasurementTypeId { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }

        public MeasurementTypeModel MeasurementType { get; set; }
//        public GarmentModel Garment { get; set; }
    }
}