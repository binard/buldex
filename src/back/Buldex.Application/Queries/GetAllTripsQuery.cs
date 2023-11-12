using Buldex.Application.Dtos;
using MediatR;

namespace Buldex.Application.Queries
{
    public sealed record GetAllTripsQuery() : IRequest<IList<TripItemSummaryDto>>;
}
