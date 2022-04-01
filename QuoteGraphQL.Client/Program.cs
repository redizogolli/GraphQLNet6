using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using QuoteGraphQL.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped(t => new GraphQLHttpClient(builder.Configuration["ApiURL"], new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<QuoteOfTheDayApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
