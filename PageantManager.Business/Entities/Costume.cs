using System.Collections.Generic;

namespace PageantManager.Business.Entities
{
    public class Costume
    {
        public int CostumeId { get; set; }
		public int PageantId { get; set; }
		public string Description { get; set; }
        public List<GarmentType> GarmentTypes { get; set; }
    }
}
