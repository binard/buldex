using Buldex.Application.Queries;
using Buldex.Domain.Repositories;
using Buldex.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults();

builder.ConfigureServices(services =>
{
    services.AddTransient<ITripRepository, TripRepository>();
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllTripsQuery).Assembly));
});

var host = builder.Build();
host.Run();
