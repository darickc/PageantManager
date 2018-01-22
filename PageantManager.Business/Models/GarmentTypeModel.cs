using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Models
{
    public class GarmentTypeModel
    {
		public int GarmentTypeId { get; set; }
		public int PageantId { get; set; }
		[StringLength(75)]
		public string Name { get; set; }
	    [StringLength(200)]
	    public string Description { get; set; }
        
	    public string Photo { get; set; }

//	    public List<CostumeGarmentModel> CostumeGarments { get; set; }
	    public List<GarmentModel> Garments { get; set; }
    }
}
