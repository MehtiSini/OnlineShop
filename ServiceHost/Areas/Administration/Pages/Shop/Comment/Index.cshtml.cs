using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Contracts.Comment;
using ShopManagement.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Shop.Comment
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> Comments;

        public CommentSearchModel SearchModel { get; set; }

        private readonly ICommentApplication? _application;

        public IndexModel(ICommentApplication application)
        {
            _application = application;
        }

        public void OnGet(CommentSearchModel searchModel)
        {
            Comments = _application.Search(searchModel);
        }

        public IActionResult OnGetConfirm(long Id)
        {
            _application.Confirm(Id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetCancel(long Id)
        {
            _application.Cancel(Id);
            return RedirectToPage("./Index");
        }

    }
}
