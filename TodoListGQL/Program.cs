using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using TodoListGQL.Data;
using TodoListGQL.GraphQL;
// https://dev.to/moe23/net-5-api-with-graphql-step-by-step-2b20;
// http://localhost:5229/graphql/
var builder = WebApplication.CreateBuilder(args);
//add db
builder.Services.AddDbContext<ApiDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ));

//add GraphQL
builder.Services.AddGraphQLServer()
                .AddQueryType<QueryGraphQL>();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//add seed DB
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(
   path: "/graphql-voyager",
   options: new VoyagerOptions() { GraphQLEndPoint = "/graphql" });

app.UseHttpsRedirection();

app.Run();