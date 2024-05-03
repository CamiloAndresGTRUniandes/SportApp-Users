namespace Users.Aplication.Features.Goals.Queries.GetAllGoals ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllGoalsHandler : IRequestHandler<GetAllGoalsQuery, List<GetAllGoalsResult>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGoalsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllGoalsResult>> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
        {
            var goals = await _unitOfWork.GoalRepository.GetAllAsync();
            return _mapper.Map<List<GetAllGoalsResult>>(goals);
        }
    }
