using Domain;
using Domain.GraphQl;
using Domain.GraphQl.CustomerAdresses;
using Domain.GraphQl.CustomerType;
using Domain.GraphQl.SalesOrderDetails;
using Domain.Test;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Voyager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Normal
//builder.Services.AddDbContext<AdventureWorksLT2019Context>(opt =>
//		opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));
#endregion

#region BooledDb
builder.Services.AddPooledDbContextFactory<AdventureWorksLT2019Context>(opt =>
						opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));
#endregion

builder.Services
.AddGraphQLServer()
.AddQueryType<RootQuery>()
.AddMutationType<RootMutaion>()
.AddType<CustomerType>()
.AddType<CustomerAdressType>()
//.AddTypeExtension<ExtendOfOrderDetails>()
.AddSubscriptionType<Subscribtion>()
.AddProjections()
.AddFiltering()
.AddSorting()
.AddDataLoader<SalesOrderDataLoader>()
.RegisterDbContext<AdventureWorksLT2019Context>()
.AddInMemorySubscriptions();

#region RegisterDbContext
//builder.Services
//.AddGraphQLServer()
//.AddQueryType<RootQuery>()
//.AddType<CustomerType>()
//.AddProjections().AddFiltering()
//.RegisterDbContext<AdventureWorksLT2019Context>(kind: HotChocolate.Data.DbContextKind.Pooled); 
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseWebSockets();

app.UseRouting();
app.UseEndpoints(endpoints =>endpoints.MapGraphQL());
app.UseVoyager(new VoyagerOptions
{
	Path = "/Ql/voyager",
	QueryPath = "/graphql"
});
//app.UseHttpsRedirection();
//app.UseStaticFiles();


app.Run();
