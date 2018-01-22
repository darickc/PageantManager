namespace PageantManager.Business.Models
{
    public class CostumeGarmentModel
    {
        public int CostumeGarmentId { get; set; }
        public int CostumeId { get; set; }
        public int GarmentTypeId { get; set; }

//        public CostumeModel Costume { get; set; }
        public GarmentTypeModel GarmentType { get; set; }
    }
}