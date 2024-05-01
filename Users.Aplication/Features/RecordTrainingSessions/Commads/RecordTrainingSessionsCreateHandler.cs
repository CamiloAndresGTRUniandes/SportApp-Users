namespace Users.Application.Features.RecordTrainingSessions.Commads ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using Dominio;
using MediatR;

    public class RecordTrainingSessionsCreateHandler : IRequestHandler<RecordTrainingSessionsCreateCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RecordTrainingSessionsCreateHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RecordTrainingSessionsCreateCommand request, CancellationToken cancellationToken)
        {
            var recordToCreate = _mapper.Map<RecordTrainingSession>(request);
            recordToCreate.CreatedBy = request.UserId;
            recordToCreate.TotalTime = TimeSpan.Parse(request.TotalTimeExcercise);
            await _unitOfWork.RecordTrainingSessionRepository.AddAsync(recordToCreate);
            return Unit.Value;
        }
    }
