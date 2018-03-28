namespace PageantManager.Core.Entities
{
    public class GarmentMeasurement : Entity
    {
        public int GarmentMeasurementId { get; set; }
        public int GarmentId { get; set; }
        public int MeasurementTypeId { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }

        public MeasurementType MeasurementType { get; set; }
        public Garment Garment { get; set; }
    }
}