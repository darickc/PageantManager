namespace PageantManager.Core.Entities
{
    public class GarmentMeasurementType : Entity
    {
        public int GarmentMeasurementTypeId { get; set; }

        public int GarmentTypeId { get; set; }
        public int MeasurementTypeId { get; set; }

        public GarmentType GarmentType { get; set; }
        public MeasurementType MeasurementType { get; set; }
    }
}