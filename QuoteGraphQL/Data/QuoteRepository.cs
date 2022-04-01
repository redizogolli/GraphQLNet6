using Microsoft.EntityFrameworkCore;
using QuoteGraphQL.Entities;

namespace QuoteGraphQL.Data
{
    public class QuoteRepository
    {
        private readonly QuoteOfTheDayDbContext _dbContext;

        public QuoteRepository(QuoteOfTheDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Quote> GetAll()
        {
           return _dbContext.Quotes.Include(q=>q.Category);
        }

        public Quote GetById(int id)
        {
            return _dbContext.Quotes.Include(q => q.Category).FirstOrDefault(x=>x.Id == id);
        }

        public Quote AddQuote(Quote quote)
        {
            _dbContext.Add(quote);
            _dbContext.SaveChanges();

            _dbContext.Entry(quote)
                .Reference(q => q.Category)
                .Load();

            return quote;
        }

        public Quote EditQuote(int id,Quote quote)
        {
            var existingQuote = _dbContext.Quotes.First(q => q.Id == id);
            existingQuote.Author = quote.Author;
            existingQuote.Text = quote.Text;
            existingQuote.CategoryId = quote.CategoryId;
            _dbContext.SaveChanges();

            return quote;
        }

        public string DeleteQuote(int id)
        {
            var existingQuote = _dbContext.Quotes.FirstOrDefault(q => q.Id == id);
            if (existingQuote == null)
                return null;
            _dbContext.Remove(existingQuote);
            _dbContext.SaveChanges();
            return existingQuote.Id.ToString();
        }
    }
}
