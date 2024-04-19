namespace Users.Aplication.Features.NutritionalAllergies.Queries.GetAllNutionalAllergies ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllNutionalAllergiesHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper
        ) : IRequestHandler<GetAllNutionalAllergiesQuery, List<GetAllNutionalAllergiesResult>>
    {
        public async Task<List<GetAllNutionalAllergiesResult>> Handle(GetAllNutionalAllergiesQuery request, CancellationToken cancellationToken)
        {
            var alergies = await _unitOfWork.NutricionalAllergyRepository.GetAllAsync();
            return _mapper.Map<List<GetAllNutionalAllergiesResult>>(alergies);
        }
    }
