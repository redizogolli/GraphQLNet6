using GraphQL.Types;
using QuoteGraphQL.Entities;

namespace QuoteGraphQL.GraphQL.Types
{
    public class CategoryType: ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("Category Name");
        }
    }
}
