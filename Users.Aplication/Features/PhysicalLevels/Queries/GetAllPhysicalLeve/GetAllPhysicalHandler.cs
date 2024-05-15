namespace Users.Aplication.Features.PhysicalLevels.Queries.GetAllPhysicalLeve ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllPhysicalHandler : IRequestHandler<GetAllPhysicalQuery, List<GetAllPhysicalResult>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPhysicalHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllPhysicalResult>> Handle(GetAllPhysicalQuery request, CancellationToken cancellationToken)
        {
            var physicalLeves = await _unitOfWork.PhysicalLevelRepository.GetAllAsync();
            return _mapper.Map<List<GetAllPhysicalResult>>(physicalLeves);
        }
    }
