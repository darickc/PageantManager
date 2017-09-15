using System;
namespace PageantManager.Business.Entities
{
    public class Garment
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

        public GarmentType GarmentType { get; set; }
    }
}
