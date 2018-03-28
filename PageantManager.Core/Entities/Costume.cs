using System.Collections.Generic;
using PageantManager.Business.Enums;

namespace PageantManager.Core.Entities
{
    public class Costume : Entity
    {
        public int CostumeId { get; set; }
        
        public string Name { get; set; }
        
		public string Description { get; set; }

        public string Photo { get; set; }

        public Gender Gender { get; set; }
        
        public List<CostumeGarment> CostumeGarments { get; set; }
    }
}
