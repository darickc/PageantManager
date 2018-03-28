namespace PageantManager.Core.Entities
{
    public class CostumeGarment : Entity
    {
        public int CostumeGarmentId { get; set; }
        public int CostumeId { get; set; }
        public int GarmentTypeId { get; set; }

        public Costume Costume { get; set; }
        public GarmentType GarmentType { get; set; }
    }
}