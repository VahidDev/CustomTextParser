namespace CustomTxtParser.Services.Abstraction
{
    public interface IRuntimeServices
    {
        T CreateCustomObject<T>(IDictionary<string, string> propNameAndValueDict);
    }
}
