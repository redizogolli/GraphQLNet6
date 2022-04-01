using GraphQL;
using GraphQL.Types;
using QuoteGraphQL.Data;
using QuoteGraphQL.GraphQL.Types;

namespace QuoteGraphQL.GraphQL
{
    public class QuoteQuery:ObjectGraphType
    {
        public QuoteQuery(Defer<QuoteRepository> quoteRepository, Defer<CategoryRepository> categoryRepository)
        {
            Field<ListGraphType<QuoteType>>(
                "quotes",
                resolve: _ => quoteRepository.Value.GetAll());


            Field<QuoteType>("quote",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve:context =>
                {
                    var id = context.GetArgument<int>("id");
                    return quoteRepository.Value.GetById(id);
                });

            Field<ListGraphType<CategoryType>>("categories", resolve: _ => categoryRepository.Value.GetAll());
        }

    }
}
