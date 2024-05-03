namespace Users.Aplication.Features.Cities.Queries.GetCityByState ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetCityByStateHandler : IRequestHandler<GetCityByStateQuery, List<GetCityByStateResult>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public GetCityByStateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


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
