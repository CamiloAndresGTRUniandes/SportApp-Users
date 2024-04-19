namespace Users.Aplication.Features.Countries.Queries.GetAllCountry ;
using AutoMapper;
using Contracts.Persistence;
using Dominio;
using MediatR;

    public class GetAllCountryHandler(
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
