using System.Collections.Generic;

namespace PageantManager.Core.Entities
{
    public class GarmentType : Entity
    {
        public int GarmentTypeId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Photo { get; set; }

        public List<CostumeGarment> CostumeGarments { get; set; }
        public List<Garment> Garments { get; set; }
        public List<GarmentMeasurementType> GarmentMeasurementTypes { get; set; }
    }
}
