namespace Users.Aplication.Features.Cities.Queries.GetCityByState ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetCityByStateHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper
        ) : IRequestHandler<GetCityByStateQuery, List<GetCityByStateResult>>
    {
        public async Task<List<GetCityByStateResult>> Handle(GetCityByStateQuery request, CancellationToken cancellationToken)
        {
            var cities = await _unitOfWork
                .CityRepository
                .GetAsync(x =>
                    x.StateId == request.StateId
                    &&
                    x.Enabled == true);

            return _mapper.Map<List<GetCityByStateResult>>(cities);
        }
    }
