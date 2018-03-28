using System.Collections.Generic;
using System.Linq;
using PageantManager.Core.Entities;
using PageantManager.Core.Models;

namespace PageantManager.Core.Specifications
{
    public class SearchCostumesByMeasurements : BaseSpecification<Costume>
    {
        public SearchCostumesByMeasurements(List<MeasurementModel> measurements)
        {
            Predicate = c =>
                c.CostumeGarments.Count > 0 &&
                c.CostumeGarments.All(cg => cg.GarmentType.Garments.Any(g =>
                    !g.CheckedOut &&
                    !g.RetiredDate.HasValue &&
                    g.GarmentMeasurements.All(m =>
                        measurements.Any(m2 =>
                            m.MeasurementTypeId == m2.MeasurementType.MeasurementTypeId &&
                            m.Min <= m2.Value &&
                            m2.Value <= m.Max))));
            
            
        }
    }
}