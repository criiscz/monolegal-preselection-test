using MongoDB.Driver;
using MonolegalPreselectionTest;
using MonolegalPreselectionTest.Connection;
using MonolegalPreselectionTest.Data;
using MonolegalPreselectionTest.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDb initialization
// Email initialization
builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddEmailService(builder.Configuration);

builder.Services.AddControllersWithViews().AddJsonOptions(
    options => options.JsonSerializerOptions.PropertyNamingPolicy = null
);
builder.Services.AddTransient<IClientDataStore, ClientService>();
// builder.Services.AddTransient<IInvoiceDataStore, InvoiceService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}"
);
app.MapFallbackToFile("index.html");
app.Run();