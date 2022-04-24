using MonolegalPreselectionTest.Connection;
using MonolegalPreselectionTest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<InvoiceDatabaseSettings>(
    builder.Configuration.GetSection("InvoiceDatabase")
);
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddSingleton<InvoiceService>();

builder.Services.AddSingleton<EmailService>();

builder.Services.AddControllersWithViews().AddJsonOptions(
    options => options.JsonSerializerOptions.PropertyNamingPolicy = null
);

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