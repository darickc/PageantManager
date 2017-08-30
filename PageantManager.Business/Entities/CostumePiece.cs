using System;
namespace PageantManager.Business.Entities
{
    public class CostumePiece
    {
        public int CostumePieceId { get; set; }
        public int CostumePieceTypeId { get; set; }
        public decimal ChestMin { get; set; }
        public decimal ChestMax { get; set; }
        public decimal WaistMin { get; set; }
        public decimal WaistMax { get; set; }
        public decimal InseamMin { get; set; }
        public decimal InseamMax { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? RetiredDate { get; set; }

        public CostumePieceType CostumePieceType { get; set; }
    }
}
