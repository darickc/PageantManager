using System;
using System.Linq;
using PageantManager.Core.Entities;

namespace PageantManager.Core.Specifications
{
    public class SearchCostumesByName : BaseSpecification<Costume>
    {
        public SearchCostumesByName(string search)
            : base(c=> string.IsNullOrEmpty(search) || c.Name.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) > -1)
        {
        }
        
    }
}