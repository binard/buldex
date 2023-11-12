using Buldex.Application.Queries;
using Buldex.Domain.Repositories;
using Buldex.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults();

builder.ConfigureServices(services =>
{
    services.AddTransient<ITripRepository, TripRepository>();
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllTripsQuery).Assembly));
    services.Configure<JsonSerializerOptions>(options =>
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.Converters.Add(new JsonStringEnumConverter());
    });
});

var host = builder.Build();
host.Run();
