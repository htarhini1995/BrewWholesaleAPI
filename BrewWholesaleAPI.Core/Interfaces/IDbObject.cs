namespace BrewWholesaleAPI.Core.Interfaces
{
    internal interface IDbObject<T>
    {
        void Delete(Guid id);
        void Delete();
        T Find(Guid id);
        void Insert();
        List<T> List();
        void Update();
    }
}
