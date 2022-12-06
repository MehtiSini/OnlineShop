using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Contracts.Product;
using ShopManagement.Contracts.ProductPicture;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        public SelectList Products;

        public ProductPictureSearchModel SearchModel { get; set; }

        public List<ProductPictureViewModel> ProductsPicture;

        private readonly IProductApplication _applicationProduct;

        private readonly IProductPictureApplication _applicationProductPicture;

        public IndexModel(IProductPictureApplication application, IProductApplication applicationProduct)
        {
            _applicationProductPicture = application;
            _applicationProduct = applicationProduct;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_applicationProduct.GetProducts(), "Id", "Name");
            ProductsPicture = _applicationProductPicture.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture
            {
                Products = _applicationProduct.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductPicture create)
        {
            var result = _applicationProductPicture.Create(create);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _applicationProductPicture.GetDetails(id);
            product.Products = _applicationProduct.GetProducts();
            return Partial("EditComment", product);
        }

        public JsonResult OnPostEdit(EditProductPicture cmd)
        {
            var result = _applicationProductPicture.Edit(cmd);
        
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long Id)
        {
            _applicationProductPicture.Remove(Id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetActivate(long Id)
        {
            _applicationProductPicture.Activate(Id);
            return RedirectToPage("./Index");
        }

    }
}
