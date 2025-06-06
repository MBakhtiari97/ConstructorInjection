using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Service.UserAddressServices;
using Service.UserServices;

namespace ConstructorInjection;

public class Program
{
    private static string GetSecret()
    {
        var userSecretId = typeof(Program).Assembly
                        .GetCustomAttributes(typeof(UserSecretsIdAttribute), false)
                        .OfType<UserSecretsIdAttribute>()
                        .FirstOrDefault()?.UserSecretsId;
        if (userSecretId == null)
            throw new Exception("Init Application Configuration File Has Not Set Yet!");
        return userSecretId!;
    }

    private static void AddConnectionStrings(WebApplicationBuilder builder)
    {
        var userSecretId = GetSecret();
        builder.Configuration.AddUserSecrets(userSecretId);
        var masterConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                                         options.UseSqlServer(masterConnectionString)
                                                         .EnableSensitiveDataLogging());
    }

    private static void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserReader, UserReader>();
        builder.Services.AddScoped<IUserSaver, UserSaver>();
        builder.Services.AddScoped<IUserRemover, UserRemover>();
        builder.Services.AddScoped<IUserServices, UserServices>();
        builder.Services.AddScoped<IUserAddressRemover, UserAddressRemover>();
        builder.Services.AddScoped<IUserAddressServices, UserAddressServices>();
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AddConnectionStrings(builder);

        RegisterServices(builder);

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
