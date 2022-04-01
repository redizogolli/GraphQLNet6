using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
using QuoteGraphQL.Data;
using QuoteGraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("Default");
//Registering services
builder.Services.AddDbContext<QuoteOfTheDayDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<QuoteRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddDefer();
builder.Services.AddHttpScope();
builder.Services.AddSingleton<QuoteOfTheDaySchema>()
    .AddSingleton<QuoteQuery>()
    .AddGraphQL(options => options.EnableMetrics = false)
    .AddSystemTextJson()
    .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
    .AddGraphTypes(typeof(QuoteOfTheDaySchema));
//


var app = builder.Build();

app.UseGraphQL<QuoteOfTheDaySchema>();
app.UseGraphQLPlayground();

app.MapGet("/", () => "Hello World!");

app.Run();
