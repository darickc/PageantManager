using PageantManager.Core.Entities;

namespace PageantManager.Core.Specifications
{
    public class GetCostumeByIdWithCostumeGarmentsAndsGarmentTypesSpecification : BaseSpecification<Costume>
    {
        public GetCostumeByIdWithCostumeGarmentsAndsGarmentTypesSpecification(int id)
            : base(c=>c.CostumeId == id)
        {
            AddInclude(c=>c.CostumeGarments);
            AddInclude($"{nameof(Costume.CostumeGarments)}.{nameof(CostumeGarment.GarmentType)}");
        }
    }
}