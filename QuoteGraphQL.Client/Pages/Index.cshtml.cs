using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuoteGraphQL.Client.Types;

namespace QuoteGraphQL.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly QuoteOfTheDayApiClient _quoteClient;
        public ICollection<Quote> Quotes { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public IndexModel(QuoteOfTheDayApiClient quoteClient)
        {
            _quoteClient = quoteClient;
        }

        public async Task OnGet()
        {
            Quotes = await _quoteClient.GetQuotesAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            await _quoteClient.DeleteQuoteAsync(Id);
            return Redirect("/");
        }
    }
}