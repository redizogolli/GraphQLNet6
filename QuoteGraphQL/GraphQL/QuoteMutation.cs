using GraphQL;
using GraphQL.Types;
using QuoteGraphQL.Data;
using QuoteGraphQL.Entities;
using QuoteGraphQL.GraphQL.Types;

namespace QuoteGraphQL.GraphQL
{
    public class QuoteMutation : ObjectGraphType
    {
        public QuoteMutation(Defer<QuoteRepository> quoteRepository)
        {
            Field<QuoteType>("createQuote", arguments:
                new QueryArguments(new QueryArgument<NonNullGraphType<QuoteInputType>> { Name = "quote" }),
                resolve: context =>
                {
                    var quote = context.GetArgument<Quote>("quote");
                    return quoteRepository.Value.AddQuote(quote);
                });
            Field<QuoteType>("updateQuote", arguments:
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }, new QueryArgument<NonNullGraphType<QuoteInputType>> { Name = "quote" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var quote = context.GetArgument<Quote>("quote");
                    return quoteRepository.Value.EditQuote(id, quote);
                });
            Field<StringGraphType>("deleteQuote", arguments:
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return quoteRepository.Value.DeleteQuote(id);
                });
        }
    }
}
