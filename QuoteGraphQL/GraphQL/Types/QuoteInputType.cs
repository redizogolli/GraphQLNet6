using GraphQL.Types;

namespace QuoteGraphQL.GraphQL.Types
{
    public class QuoteInputType : InputObjectGraphType
    {
        public QuoteInputType()
        {
            Name = "quoteInput";
            Field<NonNullGraphType<StringGraphType>>("author");
            Field<NonNullGraphType<StringGraphType>>("text");
            Field<NonNullGraphType<IntGraphType>>("categoryId");
        }
    }
}
