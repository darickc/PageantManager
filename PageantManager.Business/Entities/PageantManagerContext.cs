using Microsoft.EntityFrameworkCore;

namespace PageantManager.Business.Entities
{
    public class PageantManagerContext : DbContext
    {
        public PageantManagerContext(DbContextOptions<PageantManagerContext> options)
        : base(options)
        { }

		public DbSet<Costume> Costumes { get; set; }
        public DbSet<CostumeGarment> CostumeGarments { get; set; }
        public DbSet<Garment> Garments { get; set; }
        public DbSet<GarmentMeasurement> GarmentMeasurements { get; set; }
        public DbSet<GarmentMeasurementType> GarmentMeasurementTypes { get; set; }
        public DbSet<GarmentType> GarmentTypes { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }

    }
}