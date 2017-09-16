using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Models
{
    public class CostumeModel
    {
		public int CostumeId { get; set; }
		public int PageantId { get; set; }
		[StringLength(150)]
		public string Description { get; set; }
		public List<GarmentTypeModel> GarmentTypes { get; set; }
    }
}
