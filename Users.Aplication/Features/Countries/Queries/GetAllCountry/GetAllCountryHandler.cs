using AutoMapper;
using MediatR;
using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Aplication.Features.Countries.Queries.GetAllCountry
{

    public class GetAllCountryHandler
            (
                    IUnitOfWork _unitOfWork,
                    IMapper _mapper
        ) : IRequestHandler<GetAllCountryQuery, List<GetAllCountryResult>>

    {
        public async Task<List<GetAllCountryResult>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {

            var countries = await _unitOfWork.Repository<Country>().GetAllAsync();
            return _mapper.Map<List<GetAllCountryResult>>(countries);
        }
    }
}
