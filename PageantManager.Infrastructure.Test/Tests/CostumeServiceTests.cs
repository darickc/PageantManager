using System.Collections.Generic;
using System.Threading.Tasks;
using PageantManager.Core.Interfaces;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using PageantManager.Core.Models;

namespace PageantManager.Infrastructure.Test.Tests
{
    public class CostumeServiceTests : IClassFixture<TestFixture>
    {
        private readonly ICostumeService _costumeService;
        public CostumeServiceTests(TestFixture fixture)
        {
            _costumeService = fixture.ServiceProvider.GetService<ICostumeService>();
        }

        [Fact]
        public async Task SearchCostumesTest()
        {
            var costumes = await _costumeService.SearchCostumes(new List<MeasurementModel>());
        }
        
        [Fact]
        public async Task GetCostumesTest()
        {
            var costumes = await _costumeService.GetCostumes("dress", 1, 20);
        }
    }
}