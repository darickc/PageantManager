using System;
using System.Collections.Generic;

namespace PageantManager.Business.Models
{
    public class GarmentModel
    {
	    public int GarmentId { get; set; }
	    public int GarmentTypeId { get; set; }
	    public DateTime AddedDate { get; set; }
	    public DateTime? RetiredDate { get; set; }
	    public bool CheckedOut { get; set; }
	    public string Photo { get; set; }

//	    public GarmentTypeModel GarmentType { get; set; }
	    public List<GarmentMeasurementModel> GarmentMeasurements { get; set; }

    }
}
