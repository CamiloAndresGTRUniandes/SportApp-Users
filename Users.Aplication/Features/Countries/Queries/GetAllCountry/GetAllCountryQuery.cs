using MediatR;

namespace Users.Aplication.Features.Countries.Queries.GetAllCountry
{
    public class GetAllCountryQuery : IRequest<List<GetAllCountryResult>> { }

}
