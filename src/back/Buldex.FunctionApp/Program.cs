using Buldex.Application.Queries;
using Buldex.Domain.Repositories;
using Buldex.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using System.Text.Json;
using Buldex.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

var builder = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults();



builder.ConfigureServices(services =>
{
    services.AddTransient<ITripRepository, TripRepository>();
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllTripsQuery).Assembly));
    services.AddDbContext<BuldexDbContext>(options =>
    {
        var connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_Buldex");
        options.UseSqlServer(connectionString);
    });
    services.Configure<JsonSerializerOptions>(options =>
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.Converters.Add(new JsonStringEnumConverter());
    });
});

var host = builder.Build();
host.Run();
