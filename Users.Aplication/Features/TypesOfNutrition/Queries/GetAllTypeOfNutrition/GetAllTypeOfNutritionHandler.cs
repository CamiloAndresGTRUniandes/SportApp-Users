namespace Users.Aplication.Features.TypesOfNutrition.Queries.GetAllTypeOfNutrition ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllTypeOfNutritionHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper
        ) : IRequestHandler<GetAllTypeOfNutritionQuery, List<GetAllTypeOfNutritionResult>>
    {
        public async Task<List<GetAllTypeOfNutritionResult>> Handle(GetAllTypeOfNutritionQuery request, CancellationToken cancellationToken)
        {
            var typesOfNutrition = await _unitOfWork.TypeOfNutritionRepository.GetAllAsync();
            return _mapper.Map<List<GetAllTypeOfNutritionResult>>(typesOfNutrition);
        }
    }
