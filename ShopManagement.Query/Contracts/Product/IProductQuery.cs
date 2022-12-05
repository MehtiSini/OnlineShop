namespace ShopManagement.Query.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string Slug);
        public List<ProductQueryModel> GetlatestArrivals();
        public List<ProductQueryModel> Search(string Value);
    }
}
