using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuoteGraphQL.Client.Types;

namespace QuoteGraphQL.Client.Pages
{
    public class CreateQuoteModel : PageModel
    {
        private readonly QuoteOfTheDayApiClient _quoteClient;
        public CreateQuoteModel(QuoteOfTheDayApiClient quoteClient)
        {
            _quoteClient = quoteClient;
        }

        public List<SelectListItem> Categories { get; set; }
        [BindProperty]
        public QuoteInput Quote { get; set; }

        public async Task OnGet()
        {
            var categories = await _quoteClient.GetCategoriesAsync();

            Categories = categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            await _quoteClient.CreateQuoteAsync(Quote);
            return Redirect("/");
        }
    }
}
