using System.Data;
using HazardParser;
using Newtonsoft.Json;
using System.Linq;
using System.Linq.Expressions;


var text = File.ReadAllText(@"C:\Users\Cate\Desktop\Прога\HazardParser\HazardParser\windspeed.json");
var restoredWind = JsonConvert.DeserializeObject<InternalsForExtraction>(text)!;
var groupByYear = restoredWind.Datasets
    .Where(
        name => //Это была строка .Where(name=>name.Group.StartsWith("Risk Category")||name=>name.Group==("ASCE 7-05"))
        {
            if (name.Name.StartsWith("Risk Category")) return true;
            if (name.Group == "ASCE 7-05") return true;
            return false;
        })
    .GroupBy(x => x.Group)
    .ToList();
Console.WriteLine("Введите год.Доступный формат ввода: 2016,16, ASCE 7-16");
List<NameAndUnitAndGroup> result;
while (true)
{
    var query = Console.ReadLine();
    if (TryFindRecords(groupByYear, query, out result)) break;
}

Console.WriteLine(result.Count);

bool TryFindRecords(List<IGrouping<string, NameAndUnitAndGroup>> records, string query,
    out List<NameAndUnitAndGroup> result)
{
    foreach (var groups in records)
    {
        if (groups.Key == query)//Эти три условия можно записать через оператор ||
        {
            result = groups.ToList();
            return true;
        }

        if (groups.Key.Substring(groups.Key.Length - 2) == query)
        {
            result = groups.ToList();
            return true;
        }

        if (groups.Key.Substring(groups.Key.Length - 2).Insert(0, "20") ==
            query) // можно и "20"groups.Key.Substring... и $"20{groups.Key.Substring...}" ;
        {
            result = groups.ToList();
            return true;
        }
    }
    result = null;
    return false;
}