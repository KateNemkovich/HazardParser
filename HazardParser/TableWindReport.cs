namespace HazardParser;

public class TableWindReport
{
    public List<string> Headers //public List<string> Headers => _table.Select(x => x.Key).ToList();
    {
        get

        { 
            List<string> keys = new List<string>();
        foreach (var pair in _table)
        {
            keys.Add(pair.Key);
        }

        return keys;
    }

}

    public List<KeyValuePair<string, string>> _table;

    public void AddRecord(string name, string info)
    {
        _table.Add(new KeyValuePair<string, string>(name, info));
    }

    public TableWindReport()
    {
        _table = new List<KeyValuePair<string, string>>();

    }

}