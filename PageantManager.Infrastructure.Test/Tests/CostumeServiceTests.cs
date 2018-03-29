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
            var costumes = await _costumeService.SearchCostumesByMeasurement(new List<MeasurementModel>());
        }
        
        [Fact]
        public async Task GetCostumesTest()
        {
            var costumes = await _costumeService.SearchCostumesByNameAndPage("dress", 1, 20);
            Assert.NotNull(costumes);
            Assert.NotEmpty(costumes.Items);
        }

        [Fact]
        public async Task GetCostumeByIdAndFilterGarmentsByMeasurement()
        {
            var measurements = new List<MeasurementModel>
            {
                new MeasurementModel
                {
                    MeasurementType = new MeasurementTypeModel
                    {
                        MeasurementTypeId = 1
                    },
                    Value = 37
                },
                new MeasurementModel
                {
                    MeasurementType = new MeasurementTypeModel
                    {
                        MeasurementTypeId = 2
                    },
                    Value = 37
                },
                new MeasurementModel
                {
                    MeasurementType = new MeasurementTypeModel
                    {
                        MeasurementTypeId = 3
                    },
                    Value = 37
                }
            };
            var costume = await _costumeService.GetCostumeByIdAndFilterGarmentsByMeasurement(2, measurements);
            Assert.NotNull(costume);
            Assert.NotEmpty(costume.CostumeGarments);
        }
    }
}