using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuoteGraphQL.Client.Types;

namespace QuoteGraphQL.Client.Pages
{
    public class UpdateQuoteModel : PageModel
    {
        private readonly QuoteOfTheDayApiClient _quoteClient;

        public UpdateQuoteModel(QuoteOfTheDayApiClient quoteClient)
        {
            _quoteClient = quoteClient;
        }
        [BindProperty]
        public QuoteInput Quote { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public async Task OnGet(int id)
        {
            var categories = await _quoteClient.GetCategoriesAsync();
            Categories = categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name, Selected = c.Id == id })
                .ToList();

            //Get quote
            var quote = await _quoteClient.GetQuoteAsync(id);
            Id = quote.Id;
            Quote = new QuoteInput
            {
                Author = quote.Author,
                CategoryId = quote.Category.Id,
                Text = quote.Text
            };

        }

        public async Task<IActionResult> OnPost()
        {
            await _quoteClient.UpdateQuoteAsync(Id, Quote);
            return Redirect("/");
        }
    }
}
