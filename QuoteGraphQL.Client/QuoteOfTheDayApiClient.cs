using GraphQL;
using GraphQL.Client.Http;
using QuoteGraphQL.Client.Types;

namespace QuoteGraphQL.Client
{
    public class QuoteOfTheDayApiClient
    {
        private readonly GraphQLHttpClient _graphQLHttpClient;

        public QuoteOfTheDayApiClient(GraphQLHttpClient graphQLHttpClient)
        {
            _graphQLHttpClient = graphQLHttpClient;
        }

        public async Task<ICollection<Quote>> GetQuotesAsync()
        {
            var query = @"{quotes{
                            id
                            author
                            text
                            category{
                                name
                            }
                        }}";
            var request = new GraphQLRequest
            {
                Query = query
            };

            var response = await _graphQLHttpClient.SendQueryAsync<QuoteCollectionResponse>(request);
            return response.Data.Quotes;
        }

        public async Task<Quote> GetQuoteAsync(int id)
        {
            var query = @"query($id:ID!){
                              quote(id: $id){
                                id
                                author
                                text
                                category{
                                  id
                                  name
                                }
                              }
                            }";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { id }
              
            };

            var response = await _graphQLHttpClient.SendQueryAsync<QuoteResponse>(request);
            return response.Data.Quote;
        }

        public async Task<Quote> CreateQuoteAsync(QuoteInput quote)
        {
            var query = @"mutation($quote: quoteInput!) {
                          createQuote(quote: $quote) {
                            id
                            author
                            text
                            category {
                              name
                            }
                          }
                        }";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new {quote}
            };
            var response = await _graphQLHttpClient.SendQueryAsync<QuoteResponse>(request);
            return response.Data.Quote;
        }

        public async Task<Quote> UpdateQuoteAsync(int id,QuoteInput quote)
        {
            var query = @"mutation($id: Int!, $quote: quoteInput!) {
                          updateQuote(id: $id, quote: $quote) {
                            id
                            author
                            text
                            category {
                              name
                            }
                          }
                        }";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { quote,id }
            };
            var response = await _graphQLHttpClient.SendQueryAsync<QuoteResponse>(request);
            return response.Data.Quote;
        }
        public async Task DeleteQuoteAsync(int id)
        {
            var query = @"mutation($id: Int!) {
                          deleteQuote(id: $id)
                        }";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { id }
            };
            await _graphQLHttpClient.SendQueryAsync<StringResponse>(request);
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            var query = @"{categories{
                            id
                            name
                        }}";
            var request = new GraphQLRequest
            {
                Query = query
            };

            var response = await _graphQLHttpClient.SendQueryAsync<CategoryCollectionResponse>(request);
            return response.Data.Categories;
        }

    }
}
