using DiscountManagement.Contracts.CollegueDiscount;
using InventoryManagement.Conracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        public SelectList Products;

        public InventorySearchModel SearchModel { get; set; }

        public List<InventoryViewModel> Inventories;

        private readonly IInventoryApplication _inventoryapplication;

        private readonly IProductApplication _productapplication;

        public IndexModel(IProductApplication productapplication, IInventoryApplication inventoryapplication)
        {
            _productapplication = productapplication;
            _inventoryapplication = inventoryapplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productapplication.GetProducts(), "Id", "Name");

            Inventories = _inventoryapplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory
            {
                Products = _productapplication.GetProducts()
            };
            return Partial("./Register", command);
        }

        public JsonResult OnPostCreate(CreateInventory create)
        {
            var result = _inventoryapplication.Create(create);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Inventory = _inventoryapplication.GetDetails(id);
            Inventory.Products = _productapplication.GetProducts();
            return Partial("Edit", Inventory);
        }

        public JsonResult OnPostEdit(EditInventory cmd)
        {
            var result = _inventoryapplication.Edit(cmd);
            return new JsonResult(result);
        }


        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryId = id
            };

            return Partial("Increase", command);

        }

        public JsonResult OnPostIncrease(IncreaseInventory increase)
        {
            var result = _inventoryapplication.Increase(increase);

            return new JsonResult(result);
        }

        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventory()
            {
                InventoryId = id
            };

            return Partial("Reduce", command);
        }

        public JsonResult OnPostReduce(ReduceInventory reduce)
        {
            var result = _inventoryapplication.Reduce(reduce);

            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var operations = _inventoryapplication.GetOperationLog(id);

            return Partial("OperationLog", operations);
        }

    }
}
