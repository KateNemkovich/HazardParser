using Newtonsoft.Json;

namespace HazardParser;

public class InternalsForExtraction
{
    [JsonProperty(propertyName: "datasets")]
    public List<NameAndUnitAndGroup> Datasets { get; set; }
}

public class NameAndUnitAndGroup
{
    [JsonProperty(propertyName: "name")] public string Name { get; set; }
    [JsonProperty(propertyName: "group")] public string Group { get; set; }
    [JsonProperty(propertyName: "unit")] public string Unit { get; set; }
    [JsonProperty(propertyName: "data")] public DataValue DValue { get; set; }
}

public class DataValue
{
    [JsonProperty(propertyName: "value")] public double Value { get; set; }
}