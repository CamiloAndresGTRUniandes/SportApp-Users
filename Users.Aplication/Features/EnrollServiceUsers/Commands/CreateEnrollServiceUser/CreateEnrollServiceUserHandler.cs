namespace Users.Application.Features.EnrollServiceUsers.Commands.CreateEnrollServiceUser ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using Dominio;
using MediatR;

    public class CreateEnrollServiceUserHandler(IMapper _mapper, IUnitOfWork _unitOfWork) :
        IRequestHandler<CreateEnrollServiceUserCommand, CreateEnrollServiceUserResult>
    {
        public async Task<CreateEnrollServiceUserResult> Handle(CreateEnrollServiceUserCommand command, CancellationToken cancellationToken)
        {
            var requestValidator = await _unitOfWork.Repository<EnrollServiceUser>()
                .GetAsync(x =>
                    x.PlanId == command.PlanId
                    &&
                    x.ServiceId == command.ServiceId
                    &&
                    x.UserId == command.UserId
                    &&
                    x.UserAsociateId == command.UserAsociateId
                );
            if (requestValidator.Count > 0)
            {
                return new CreateEnrollServiceUserResult
                {
                    Created = false,
                    Message = "Este usuario ya tenia este servicio asociado"
                };
            }

            var enrollToCreate = _mapper.Map<EnrollServiceUser>(command);
            await _unitOfWork.Repository<EnrollServiceUser>().AddAsync(enrollToCreate);

            return new CreateEnrollServiceUserResult
            {
                Created = true,
                Message = "El usuario se le asocio el servicio"
            };
        }
    }
