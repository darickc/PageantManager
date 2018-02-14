using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PageantManager.Business.Entities;
using PageantManager.Business.Enums;

namespace PageantManager.Console
{
    public class DataImport
    {
        private readonly PageantManagerContext _ctx;
        private const string Csv = "YW_Manti_Final2.csv";
        private const string Length = "Length";
        private const string Waist = "Waist";
        private const string Bust = "Bust";
        
        private MeasurementType lengthMeasurementType;
        private MeasurementType waistMeasurementType;
        private MeasurementType bustmeMeasurementType;

        public DataImport(PageantManagerContext ctx)
        {
            _ctx = ctx;
            
//            lengthMeasurementType = new MeasurementType
//            {
//                Name = Length
//            };
//            waistMeasurementType = new MeasurementType
//            {
//                Name = Waist
//            };
//            bustmeMeasurementType = new MeasurementType
//            {
//                Name = Bust
//            };
//
//            _ctx.MeasurementTypes.Add(lengthMeasurementType);
//            _ctx.MeasurementTypes.Add(waistMeasurementType);
//            _ctx.MeasurementTypes.Add(bustmeMeasurementType);

            var measurementTypes = _ctx.MeasurementTypes.ToList();
            lengthMeasurementType = measurementTypes.SingleOrDefault(m => m.Name == Length);
            waistMeasurementType = measurementTypes.SingleOrDefault(m => m.Name == Waist);
            bustmeMeasurementType = measurementTypes.SingleOrDefault(m => m.Name == Bust);
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
                AddGroup(@group.Key.Scene, @group.Key.Gender, @group.Key.Name, @group.ToList());
            }

            await _ctx.SaveChangesAsync();

        }

        private void AddGroup(string scene, Gender gender, string name, List<CsvData> data)
        {
            var costume = new Costume
            {
                Name = $"{scene} {name}",
                Gender = gender,
                CostumeGarments = new List<CostumeGarment>()
            };

            _ctx.Costumes.Add(costume);
            
            var garmentType = new GarmentType
            {
                Name = $"{scene} {name}",
                GarmentMeasurementTypes = new List<GarmentMeasurementType>(),
                Garments = new List<Garment>()
            };

            if (data.Any(d => d.BustMax > 0 && d.BustMin > 0))
            {
                garmentType.GarmentMeasurementTypes.Add(new GarmentMeasurementType
                {
                    MeasurementType = bustmeMeasurementType
                });
            }
            
            if (data.Any(d => d.WaistMin > 0 && d.WaistMax > 0))
            {
                garmentType.GarmentMeasurementTypes.Add(new GarmentMeasurementType
                {
                    MeasurementType = waistMeasurementType
                });
            }
            
            if (data.Any(d => d.LengthMin > 0 && d.LengthMax > 0))
            {
                garmentType.GarmentMeasurementTypes.Add(new GarmentMeasurementType
                {
                    MeasurementType = lengthMeasurementType
                });
            }

            foreach (var csvData in data)
            {
                var garment = new Garment
                {
                    AddedDate = DateTime.Now,
                    GarmentMeasurements = new List<GarmentMeasurement>()
                };
                if (garmentType.GarmentMeasurementTypes.Any(m => m.MeasurementType.Name == Bust))
                {
                    garment.GarmentMeasurements.Add(new GarmentMeasurement
                    {
                        Max = csvData.BustMax,
                        Min = csvData.BustMin,
                        MeasurementType = bustmeMeasurementType
                    });
                }
                
                if (garmentType.GarmentMeasurementTypes.Any(m => m.MeasurementType.Name == Waist))
                {
                    garment.GarmentMeasurements.Add(new GarmentMeasurement
                    {
                        Max = csvData.WaistMax,
                        Min = csvData.WaistMin,
                        MeasurementType = waistMeasurementType
                    });
                }
                
                if (garmentType.GarmentMeasurementTypes.Any(m => m.MeasurementType.Name == Length))
                {
                    garment.GarmentMeasurements.Add(new GarmentMeasurement
                    {
                        Max = csvData.LengthMax,
                        Min = csvData.LengthMin,
                        MeasurementType = lengthMeasurementType
                    });
                }
                
                garmentType.Garments.Add(garment);
            }
            
            costume.CostumeGarments.Add(new CostumeGarment
            {
                GarmentType = garmentType
            });
            
            
            
        }
    }
}