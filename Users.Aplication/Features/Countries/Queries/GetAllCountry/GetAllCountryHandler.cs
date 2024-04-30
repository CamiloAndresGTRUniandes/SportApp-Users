namespace Users.Aplication.Features.Countries.Queries.GetAllCountry ;
using AutoMapper;
using Contracts.Persistence;
using Dominio;
using MediatR;

    public class GetAllCountryHandler : IRequestHandler<GetAllCountryQuery, List<GetAllCountryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCountryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllCountryResult>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            var countries = await _unitOfWork.Repository<Country>().GetAllAsync();
            return _mapper.Map<List<GetAllCountryResult>>(countries);
        }
    }
