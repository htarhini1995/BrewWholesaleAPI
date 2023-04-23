namespace BrewWholesaleAPI.Core.Interfaces
{
    internal interface IDbObject<T>
    {
        internal void Delete(int id);
        internal void Delete();
        internal T Find(int id);
        internal void Insert();
        internal List<T> List();
        internal void Update();
    }
}
