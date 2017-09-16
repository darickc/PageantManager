using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Entities
{
    public class Costume
    {
        [Key]
        public int CostumeId { get; set; }
		public int PageantId { get; set; }
        [StringLength(150)]
		public string Description { get; set; }
        public List<GarmentType> GarmentTypes { get; set; }
    }
}
