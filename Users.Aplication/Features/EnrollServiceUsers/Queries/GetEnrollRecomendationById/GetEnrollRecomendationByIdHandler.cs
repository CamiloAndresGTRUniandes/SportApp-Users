namespace Users.Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationById ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using MediatR;

    public class GetEnrollRecomendationByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IRequestHandler<GetEnrollRecomendationsByIdQuery, GetEnrollRecomendationsByIdResult>
    {
        public async Task<GetEnrollRecomendationsByIdResult> Handle(GetEnrollRecomendationsByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.EnrollServiceUserRepository.GetEnrollsByIdAsync(request.Id);
            return _mapper.Map<GetEnrollRecomendationsByIdResult>(result);
        }
    }
