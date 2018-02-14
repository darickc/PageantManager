using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PageantManager.Business.Entities;
using PageantManager.Business.Enums;

namespace PageantManager.Console
{
    public class DataImport
    {
        private readonly PageantManagerContext _ctx;
        private const string Csv = "YW_Manti_Final2.csv";

        public DataImport(PageantManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Import()
        {
            var csvDatas = new List<CsvData>();
            
            var lines = File.ReadAllLines(Csv);
            int i = 0;
            foreach (var line in lines)
            {
                //System.Console.WriteLine($"{i++}={line}");
                var columns = line.Split(',');
                csvDatas.Add(new CsvData
                {
                    Id = int.Parse(columns[0]),
                    Scene = columns[1].Trim().ToUpper(),
                    Name = columns[3].Trim(),
                    BustMin = float.Parse(columns[4]),
                    BustMax = float.Parse(columns[6]),
                    WaistMin = float.Parse(columns[7]),
                    WaistMax = float.Parse(columns[9]),
                    LengthMin = float.Parse(columns[10]),
                    LengthMax = float.Parse(columns[12]),
                    DateIn = int.Parse(columns[13]),
                    PhotoName = columns[14].Trim(),
                    Gender = (Gender) Enum.Parse(typeof(Gender), columns[2])
                });
            }

            var groups = csvDatas.GroupBy(c => new { c.Scene, c.Gender, c.Name});
            foreach (var @group in groups)
            {
                System.Console.WriteLine($"{@group.Key.Gender} {@group.Key.Name} {@group.Key.Scene} {@group.Count()}");
            }
        }
    }
}