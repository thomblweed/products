using API.Interfaces;

namespace API.Config
{
    public class ProductsStoreDatabaseSettings : IProductsStoreDatabaseSettings
    {
        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}