using System.Data;
using HazardParser;
using Newtonsoft.Json;
using System.Linq;
using System.Linq.Expressions;


var text = File.ReadAllText(@"C:\Users\Cate\Desktop\Прога\HazardParser\HazardParser\windspeed.json");
var restoredWind = JsonConvert.DeserializeObject<InternalsForExtraction>(text)!;
var groupByYear=restoredWind.Datasets
    .Where(name=> //Это была строка .Where(name=>name.Group.StartsWith("Risk Category")||name=>name.Group==("ASCE 7-05"))
    {
        if (name.Name.StartsWith("Risk Category")) return true;
        if(name.Group == ("ASCE 7-05")) return true;
        return false;
    })
    .GroupBy(x=>x.Group)
    .ToList();
Console.ReadLine();