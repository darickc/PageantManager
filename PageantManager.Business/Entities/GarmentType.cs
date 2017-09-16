using System;
using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Entities
{
    public class GarmentType
    {
        [Key]
        public int GarmentTypeId { get; set; }
        public int PageantId { get; set; }
        [StringLength(75)]
        public string Name { get; set; }
    }
}
