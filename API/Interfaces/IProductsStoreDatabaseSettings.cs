namespace API.Interfaces
{
    public interface IProductsStoreDatabaseSettings
    {
        string ProductsStoreCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}