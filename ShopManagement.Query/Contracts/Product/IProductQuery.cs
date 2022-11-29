namespace ShopManagement.Query.Contracts.Product
{
    public interface IProductQuery
    {
        public List<ProductQueryModel> GetlatestArrivals();
        public List<ProductQueryModel> Search(string Value);
    }
}
