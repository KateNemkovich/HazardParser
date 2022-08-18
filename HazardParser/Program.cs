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
        if(name.Group == "ASCE 7-05") return true;
        return false;
    })
    .GroupBy(x=>x.Group)
    .ToList();
Console.WriteLine("Введите год.Доступный формат ввода: 2016,16, ASCE 7-16");
var isFound = false; // можно и  bool isFound;
List<NameAndUnitAndGroup> information;
while (!isFound)
{
   var enterInfo = Console.ReadLine();
   foreach (var groups in groupByYear)
   {
       if (groups.Key == enterInfo)
       {
           isFound = true;
           information=groups.ToList();
           break;
       }
       
       if (groups.Key.Substring(groups.Key.Length - 2)==enterInfo)
       {
           isFound = true; 
           information=groups.ToList();
           break;
       }

       if (groups.Key.Substring(groups.Key.Length - 2).Insert(0,"20")==enterInfo) // можно и "20"groups.Key.Substring... и $"20{groups.Key.Substring...}" ;
       {
           isFound = true;
           information=groups.ToList();
           break;
       }
   }
}
