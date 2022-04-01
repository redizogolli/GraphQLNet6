using QuoteGraphQL.Entities;

namespace QuoteGraphQL.Data
{
    public class CategoryRepository
    {
        private readonly QuoteOfTheDayDbContext _dbContext;

        public CategoryRepository(QuoteOfTheDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories;
        }

    }
}
