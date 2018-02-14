using PageantManager.Business.Enums;

namespace PageantManager.Console
{
    public class CsvData
    {
        public int Id { get; set; }
        public string Scene { get; set; }
        public string Name { get; set; }
        public float BustMin { get; set; }
        public float BustMax { get; set; }
        public float WaistMin { get; set; }
        public float WaistMax { get; set; }
        public float LengthMin { get; set; }
        public float LengthMax { get; set; }
        public int DateIn { get; set; }
        public string PhotoName { get; set; }
        public Gender Gender { get; set; }
    }
}