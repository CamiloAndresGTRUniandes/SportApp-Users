namespace Users.Aplication.Features.Cities.Queries.GetCityById ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetCityByIdHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper
        ) : IRequestHandler<GetCityByIdQuery, List<GetCityByIdResult>>
    {
        public async Task<List<GetCityByIdResult>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var cities = await _unitOfWork
                .CityRepository
                .GetAsync(x =>
                    x.Id == request.CityId
                    &&
                    x.Enabled == true);

            return _mapper.Map<List<GetCityByIdResult>>(cities);
        }
    }
