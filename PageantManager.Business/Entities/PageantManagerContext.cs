using Microsoft.EntityFrameworkCore;

namespace PageantManager.Business.Entities
{
    public class PageantManagerContext : DbContext
    {
        public PageantManagerContext(DbContextOptions<PageantManagerContext> options)
        : base(options)
        { }

		//public DbSet<Applicant> Applicants { get; set; }
		public DbSet<Costume> Costumes { get; set; }
        public DbSet<Garment> Garments { get; set; }
        public DbSet<GarmentType> GarmentTypes { get; set; }
        public DbSet<Pageant> Pageants { get; set; }
        public DbSet<Performance> Performances { get; set; }
    }
}