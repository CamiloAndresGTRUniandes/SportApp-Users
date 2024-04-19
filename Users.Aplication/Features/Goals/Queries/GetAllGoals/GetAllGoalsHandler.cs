namespace Users.Aplication.Features.Goals.Queries.GetAllGoals ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllGoalsHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper
        )
        : IRequestHandler<GetAllGoalsQuery, List<GetAllGoalsResult>>
    {
        public async Task<List<GetAllGoalsResult>> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
        {
            var goals = await _unitOfWork.GoalRepository.GetAllAsync();
            return _mapper.Map<List<GetAllGoalsResult>>(goals);
        }
    }
