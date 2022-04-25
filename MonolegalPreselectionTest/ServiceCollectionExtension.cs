using MongoDB.Driver;
using MonolegalPreselectionTest.Connection;
using MonolegalPreselectionTest.Services;

namespace MonolegalPreselectionTest;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DatabaseSettings>(configuration.GetSection("InvoiceDatabase"));
        services.AddSingleton<IMongoClient>(_ =>
            new MongoClient(configuration.GetSection("InvoiceDatabase").Get<DatabaseSettings>().ConnectionString));
        services.AddSingleton<IMongoDatabase>(provider =>
            provider.GetService<IMongoClient>()!.GetDatabase(configuration.GetSection("InvoiceDatabase").Get<DatabaseSettings>().DatabaseName));
        return services;
    }

    public static IServiceCollection AddEmailService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddSingleton<IEmailService, GmailService>();
        return services;
    }
}