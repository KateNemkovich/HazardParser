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

var standart = result[0].Group;
var year = result[0].Group.Substring(result[0].Group.Length - 2).Insert(0, "20") ;
var unit = result[0].Unit;
var riskCategoryI = result[0].Speed.Value;
double riskCategoryII = result.Count switch
{
    > 1 => result[1].Speed.Value,
    _ => result[0].Speed.Value
};
double riskCategoryIII = result.Count switch
{
    > 1 => result[2].Speed.Value,
    _ => result[0].Speed.Value
};
double riskCategoryIV;
if (result.Count == 1)
    riskCategoryIV = result[0].Speed.Value;
else if (result.Count == 3)
    riskCategoryIV = result[2].Speed.Value;
else if (result.Count == 4)
    riskCategoryIV = result[3].Speed.Value;
else
    throw new ArgumentOutOfRangeException(nameof(result.Count));

var report= new TableWindReport();
report.AddRecord("Standart",standart);
report.AddRecord("Year", year);
report.AddRecord("Risk Category I", riskCategoryI.ToString());
report.AddRecord("Risk Category II", Convert.ToString(riskCategoryII));
report.AddRecord("Risk Category III", Convert.ToString(riskCategoryIII));
report.AddRecord("Risk Category IV", Convert.ToString(riskCategoryIV));
report.AddRecord("Unit", unit);
PrintReport(report);
ExportReport(report);
    
 void PrintReport(TableWindReport report)
{
        
}
    
 void ExportReport(TableWindReport report)
{
        
}

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