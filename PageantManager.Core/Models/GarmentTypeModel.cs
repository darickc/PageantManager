using System.Collections.Generic;

namespace PageantManager.Core.Models
{
    public class GarmentTypeModel
    {
		public int GarmentTypeId { get; set; }
//		[StringLength(75)]
		public string Name { get; set; }
//	    [StringLength(200)]
	    public string Description { get; set; }
        
	    public string Photo { get; set; }

	    public List<GarmentModel> Garments { get; set; }

	    public List<GarmentMeasurementTypeModel> GarmentMeasurementTypes { get; set; }
    }
}
