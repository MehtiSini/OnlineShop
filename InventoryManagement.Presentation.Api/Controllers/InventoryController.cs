using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Query.Contracts;

namespace InventoryManagement.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryQuery _invetorQuery;

        public InventoryController(IInventoryQuery invetorQuery)
        {
            _invetorQuery = invetorQuery;
        }

        [HttpPost]
        public StockStatus CheckStock(IsInStock Command)
        {
            return _invetorQuery.CheckStock(Command);
        }

    }
}
