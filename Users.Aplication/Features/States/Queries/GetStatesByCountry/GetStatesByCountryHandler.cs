namespace Users.Aplication.Features.States.Queries.GetStatesByCountry ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetStatesByCountryHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper
        ) : IRequestHandler<GetStatesByCountryQuery, List<GetStatesByCountryResult>>
    {
        public async Task<List<GetStatesByCountryResult>> Handle(GetStatesByCountryQuery request, CancellationToken cancellationToken)
        {
            var states = await _unitOfWork
                .StateRepository
                .GetStatesByCountry(request.CountryId);

            return _mapper.Map<List<GetStatesByCountryResult>>(states);
        }
    }
