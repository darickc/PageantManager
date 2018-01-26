using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Entities
{
    public class Garment
    {
        [Key]
        public int GarmentId { get; set; }
        public int GarmentTypeId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? RetiredDate { get; set; }
        public bool CheckedOut { get; set; }
        public string Photo { get; set; }

        public GarmentType GarmentType { get; set; }
        public List<GarmentMeasurement> GarmentMeasurements { get; set; }
    }
}
