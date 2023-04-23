namespace BrewWholesaleAPI.Core.Interfaces
{
    internal interface IDbObject<T>
    {
       void Delete(int id);
       T Find(int id);
       void Insert();
       List<T> List();
       void Update();
    }
}
