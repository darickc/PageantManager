using System;
namespace PageantManager.Business.Entities
{
    public class Performance
    {
        public int PerformanceId { get; set; }
        public int PageantId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ApplicationStartDate { get; set; }

        public DateTime ApplicationEndDate { get; set; }

        public string Description { get; set; }

	}
}
