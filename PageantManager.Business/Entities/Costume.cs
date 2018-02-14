using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PageantManager.Business.Enums;

namespace PageantManager.Business.Entities
{
    public class Costume
    {
        [Key]
        public int CostumeId { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(150)]
		public string Description { get; set; }

        public string Photo { get; set; }

        public Gender Gender { get; set; }
        
        public List<CostumeGarment> CostumeGarments { get; set; }
    }
}
