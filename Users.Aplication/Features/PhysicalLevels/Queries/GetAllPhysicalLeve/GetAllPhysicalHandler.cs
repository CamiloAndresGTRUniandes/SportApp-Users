namespace Users.Aplication.Features.PhysicalLevels.Queries.GetAllPhysicalLeve ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllPhysicalHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper
        ) : IRequestHandler<GetAllPhysicalQuery, List<GetAllPhysicalResult>>
    {
        public async Task<List<GetAllPhysicalResult>> Handle(GetAllPhysicalQuery request, CancellationToken cancellationToken)
        {
            var physicalLeves = await _unitOfWork.PhysicalLevelRepository.GetAllAsync();
            return _mapper.Map<List<GetAllPhysicalResult>>(physicalLeves);
        }
    }
