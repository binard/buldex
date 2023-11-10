using Buldex.Application.Dtos;
using MediatR;

namespace Buldex.Application.Queries
{
    public record GetTripByIdQuery(string id) : IRequest<TripDetailsDto?>;
}