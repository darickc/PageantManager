using PageantManager.Core.Entities;

namespace PageantManager.Core.Specifications
{
    public class GetCostumeByIdAndIncludeAll : GetCostumeByIdWithCostumeGarmentsAndsGarmentTypesSpecification
    {
        public GetCostumeByIdAndIncludeAll(int id)
            :base(id)
        {
            AddInclude($"{nameof(Costume.CostumeGarments)}" +
                       $".{nameof(CostumeGarment.GarmentType)}" + 
                       $".{nameof(GarmentType.Garments)}" + 
                       $".{nameof(Garment.GarmentMeasurements)}" + 
                       $".{nameof(GarmentMeasurement.MeasurementType)}");
        }
    }
}