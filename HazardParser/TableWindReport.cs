namespace HazardParser;

public class TableWindReport
{
    public List<KeyValuePair<string, string>> _table;

    public void  AddRecord(string name,string info)
    {
        _table.Add(new KeyValuePair<string, string>(name, info));
    }
    public TableWindReport()
    {
        _table = new List<KeyValuePair<string, string>>();
       
    }

    
}