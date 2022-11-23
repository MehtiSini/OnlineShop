using MyFramework.Tools;
using ShopManagement.Contracts.Product;

namespace ShopManagement.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture Cmd);
        OperationResult Edit(EditProductPicture Cmd);
        OperationResult Remove(long Id);
        OperationResult Activate(long Id);
        EditProductPicture GetDetails(long Id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
