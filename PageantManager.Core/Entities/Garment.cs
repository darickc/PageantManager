using System;
using System.Collections.Generic;

namespace PageantManager.Core.Entities
{
    public class Garment : Entity
    {
        public int GarmentId { get; set; }
        public int GarmentTypeId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? RetiredDate { get; set; }
        public bool CheckedOut { get; set; }
        public string Photo { get; set; }
        public string PhotoName { get; set; }


        public GarmentType GarmentType { get; set; }
        public List<GarmentMeasurement> GarmentMeasurements { get; set; }
    }
}
