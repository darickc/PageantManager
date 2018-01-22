using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Models
{
    public class CostumeModel
    {
		public int CostumeId { get; set; }
	    
	    [StringLength(50)]
	    public string Name { get; set; }
	    
		[StringLength(150)]
		public string Description { get; set; }
	    
	    public string Photo { get; set; }
	    
		public List<CostumeGarmentModel> CostumeGarments { get; set; }
    }
}
