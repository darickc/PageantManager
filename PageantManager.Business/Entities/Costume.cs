using System;
namespace PageantManager.Business.Entities
{
    public class Costume
    {
        public int CostumeId { get; set; }
        public int PageantId { get; set; }
        public string Description { get; set; }
        public decimal ChestMin { get; set; }
        public decimal ChestMax { get; set; }
        public decimal WaistMin { get; set; }
        public decimal WaistMax { get; set; }
        public decimal InseamMin { get; set; }
        public decimal InseamMax { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? RetiredDate { get; set; }

	}
}
