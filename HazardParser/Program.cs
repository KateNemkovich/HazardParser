using HazardParser;
using Newtonsoft.Json;

var text = File.ReadAllText("windspeed.json");
var restoredwind = JsonConvert.DeserializeObject<InternalsForExtraction>(text);
Console.ReadLine();