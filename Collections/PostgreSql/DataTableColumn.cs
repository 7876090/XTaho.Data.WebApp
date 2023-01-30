namespace XTaho.Data.WebApp.Collections.PostgreSql
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataTableColumn : Attribute
    {
        public string Name { get; }
        public string DataType { get; }
        public DataTableColumn(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }
    }
}
