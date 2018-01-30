using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using PageantManager.Business.Business;

namespace PageantManager.Business.Test.Tests
{
    public class CostumesBusinessTest : IClassFixture<Fixture>
    {
        private readonly CostumesBusiness _costumesBusiness;
        public CostumesBusinessTest(Fixture fixture)
        {
            _costumesBusiness = fixture.ServiceProvider.GetService<CostumesBusiness>();
        }
        
        [Fact]
        public async Task CheckCellPhoneAuthorizationAsyncTest()
        {
            var costumes = await _costumesBusiness.GetCostumes(null, 1, 25);
            Assert.NotNull(costumes);
        }
    }
}