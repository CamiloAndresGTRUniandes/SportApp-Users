using AutoMapper;
using MediatR;
using Users.Aplication.Contracts.Persistence;

namespace Users.Aplication.Features.NutritionalAllergies.Queries.GetAllNutionalAllergies
{
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
}
