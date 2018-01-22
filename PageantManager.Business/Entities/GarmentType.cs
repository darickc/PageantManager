using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Entities
{
    public class GarmentType
    {
        [Key]
        public int GarmentTypeId { get; set; }
        
        [StringLength(75)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        
        public string Photo { get; set; }

        public List<CostumeGarment> CostumeGarments { get; set; }
        public List<Garment> Garments { get; set; }
    }
}
