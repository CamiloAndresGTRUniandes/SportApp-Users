namespace Users.Aplication.Features.UsersSportProfile.Queries.GetUserById ;
using AutoMapper;
using Contracts.Aplications;
using Contracts.Persistence;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Models.Common.DTO;

    public class GetUserByIdQueryHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        UserManager<ApplicationUser> _userManager,
        IUtils _utils
        )
        : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users
                .Where(p => p.Id == request.UserId)
                .FirstOrDefault();
            if (user == null)
            {
                throw new Exception($"Usuario con id {request.UserId} no existe");
            }

            var userResult = _mapper.Map<GetUserByIdQueryResult>(user);

            userResult.UserId = request.UserId;

            var nutrionalProfileResult = (await _unitOfWork.NutrionalProfileRepository.GetAsync(x => x.UserId == request.UserId)).FirstOrDefault();
            userResult.NutrionalProfile = _mapper.Map<NutrionalProfileDTO>(nutrionalProfileResult);


            var nutricionalAllergiesResult = (await _unitOfWork.UserAllergyRepository.GetAsync(x => x.UsersId == request.UserId)).ToList();

            userResult.NutricionalAllergies = nutricionalAllergiesResult.Select(p => p.NutricionalAllergyId).ToList();

            var activitiesResult = (await _unitOfWork.Repository<UserActivity>().GetAsync(x => x.UsersId == request.UserId)).ToList();
            userResult.Activities = activitiesResult.Select(p => p.ActivityId).ToList();

            var goalsResult = (await _unitOfWork.Repository<UserGoal>().GetAsync(x => x.UsersId == request.UserId)).ToList();
            userResult.Goals = goalsResult.Select(p => p.GoalId).ToList();

            var sportProfileResult = (await _unitOfWork.Repository<SportProfile>().GetAsync(x => x.UserId == request.UserId)).FirstOrDefault();
            userResult.SportProfile = _mapper.Map<SportProfileDTO>(sportProfileResult);
            if (userResult?.DateOfBirth.Year < 10)
            {
                userResult.DateOfBirth = DateTime.Now.Date.AddYears(-19);
            }
            userResult.Age = _utils.CalculateAge(userResult.DateOfBirth);


            return userResult!;
        }
    }
