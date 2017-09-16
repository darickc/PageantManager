using System;
namespace PageantManager.Business.Models
{
    public class GarmentModel
    {
		public int GarmentId { get; set; }
		public int GarmentTypeId { get; set; }
		public decimal? ChestMin { get; set; }
		public decimal? ChestMax { get; set; }
		public decimal? WaistMin { get; set; }
		public decimal? WaistMax { get; set; }
		public decimal? InseamMin { get; set; }
		public decimal? InseamMax { get; set; }
		public decimal? HeadMin { get; set; }
		public decimal? HeadMax { get; set; }
		public DateTime AddedDate { get; set; }
		public DateTime? RetiredDate { get; set; }

    }
}
