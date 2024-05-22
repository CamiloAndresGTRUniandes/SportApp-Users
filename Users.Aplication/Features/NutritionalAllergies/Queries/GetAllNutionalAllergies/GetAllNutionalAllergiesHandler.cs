namespace Users.Aplication.Features.NutritionalAllergies.Queries.GetAllNutionalAllergies ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllNutionalAllergiesHandler : IRequestHandler<GetAllNutionalAllergiesQuery, List<GetAllNutionalAllergiesResult>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public GetAllNutionalAllergiesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllNutionalAllergiesResult>> Handle(GetAllNutionalAllergiesQuery request, CancellationToken cancellationToken)
        {
            var alergies = await _unitOfWork.NutricionalAllergyRepository.GetAllAsync();
            return _mapper.Map<List<GetAllNutionalAllergiesResult>>(alergies);
        }
    }
