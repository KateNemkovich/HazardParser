using HazardParser;
using Newtonsoft.Json;

var text = File.ReadAllText(@"C:\Users\Cate\Desktop\Прога\HazardParser\HazardParser\windspeed.json");
var restoredwind = JsonConvert.DeserializeObject<InternalsForExtraction>(text);
Console.ReadLine();