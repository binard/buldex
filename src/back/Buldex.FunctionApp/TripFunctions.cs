using Buldex.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Buldex.FunctionApp
{
    public class TripFunctions
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;        

        public TripFunctions(IMediator mediator, ILoggerFactory loggerFactory)
        {
            _mediator = mediator;
            _logger = loggerFactory.CreateLogger<TripFunctions>();
        }

        [Function("GetTrips")]
        public async Task<IActionResult> GetAllTrips([HttpTrigger(AuthorizationLevel.Function, "get", Route = "trip")] HttpRequestData req)
        {
            var trips = await _mediator.Send(new GetAllTripsQuery());

            return new OkObjectResult(trips);
        }

        [Function("GetTripById")]
        public async Task<IActionResult> GetTripById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "trip/{id}")] HttpRequestData req, string id)
        {
            var trip = await _mediator.Send(new GetTripByIdQuery(id));

            if(trip == null)
            {
                return new NotFoundObjectResult(id);
            }

            return new OkObjectResult(trip);
        }
    }
}