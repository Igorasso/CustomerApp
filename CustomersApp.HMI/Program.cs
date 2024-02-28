using BlazorBootstrap;
using CustomersApp.Common.Data.Extensions;
using CustomersApp.Database.Extensions;
using CustomersApp.Database.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddCommon(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddBlazorBootstrap();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<CustomerSeeder>();
seeder.Seed();


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
