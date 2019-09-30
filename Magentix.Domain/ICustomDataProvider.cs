namespace Magentix.Domain
{
    public interface ICustomDataProvider
    {
        string GetCustomData(string fieldName);
    }
}