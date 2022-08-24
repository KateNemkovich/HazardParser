using Newtonsoft.Json;

namespace HazardParser;

public class InternalsForExtraction
{
    [JsonProperty("datasets")] public List<NameAndUnitAndGroup> Datasets { get; set; }
}

public class NameAndUnitAndGroup
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("group")] public string Group { get; set; }
    [JsonProperty("unit")] public string Unit { get; set; }
    [JsonProperty("data")] public DataValue Speed { get; set; }
}

public class DataValue
{
    [JsonProperty("value")] public double Value { get; set; }
}