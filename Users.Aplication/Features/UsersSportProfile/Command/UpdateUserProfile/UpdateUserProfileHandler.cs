namespace Users.Aplication.Features.UsersSportProfile.Command.UpdateUserProfile ;
using Application.Models.Common.DTO;
using AutoMapper;
using Contracts.Persistence;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Services.Domain.Core.Bus;

    public class UpdateUserProfileHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        UserManager<ApplicationUser> _userManager,
        IEventBus _bus
        )
        : IRequestHandler<UpdateUserSportProfileCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateUserSportProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                throw new Exception($"Usuario con email {request.Email} no existe");
            }

            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Email = request.Email.ToLower().Trim();
            user.UserName = request.Email.ToLower().Trim();
            user.PhoneNumber = request.PhoneNumber;
            user.DateOfBirth = request.DateOfBirth;
            user.GenreId = request.GenreId;

            // Geographic Profile
            user.CountryId = request.CountryId;
            user.StateId = request.StateId;
            user.CityId = request.CityId;
            await SaveNutricionalProfile(request, user);
            await SaveUserAllergies(request);
            await SaveUserActivities(request);
            await SaveUserGoals(request);
            await SaveSportProfile(request, user);
            await _userManager.UpdateAsync(user);
            var userProfileCommandBus = _mapper.Map<UserProfileEventBus>(request);
            await _bus.Publish(userProfileCommandBus);

            return Unit.Value;
        }

        private async Task SaveUserAllergies(UpdateUserSportProfileCommand request)
        {
            var nutProfileReq = request.NutricionalAllergies;
            var nutAllerDel = await _unitOfWork.UserAllergyRepository.GetAsync(x => x.UsersId == request.UserId);

            foreach (var aler in nutAllerDel)
            {
                await _unitOfWork.UserAllergyRepository.DeleteAsync(aler);
            }

            foreach (var newAler in nutProfileReq)
            {
                var allergie = new UserAllergy
                {
                    UsersId = request.UserId,
                    NutricionalAllergyId = newAler,
                    Enabled = true,
                    CreatedBy = request.UserId
                };

                await _unitOfWork
                    .UserAllergyRepository
                    .AddAsync(allergie);
            }
        }

        private async Task SaveNutricionalProfile(UpdateUserSportProfileCommand request, ApplicationUser user)
        {
            var nutProfileReq = request.NutrionalProfile;
            var nutrionalProfile =
                await _unitOfWork
                    .Repository<NutrionalProfile>()
                    .GetAsync(x =>
                        x.UserId == request.UserId
                        &&
                        x.Enabled == true
                    );

            if (nutrionalProfile.Count > 0)
            {
                var nutrionalProfileUpdate = nutrionalProfile[0];
                nutrionalProfileUpdate.AveragesCaloriesPerDay = nutProfileReq.AveragesCaloriesPerDay;
                nutrionalProfileUpdate.UpdateBy = request.UserId;
                nutrionalProfileUpdate.User = user;
                nutrionalProfileUpdate.HasAllergies = nutProfileReq.HasAllergies;
                nutrionalProfileUpdate.HasMedicalAllergies = nutProfileReq.HasMedicalAllergies;
                nutrionalProfileUpdate.TypeOfNutritionId = nutProfileReq.TypeOfNutritionId;
                await _unitOfWork.Repository<NutrionalProfile>().UpdateAsync(nutrionalProfileUpdate);
            }
            else
            {
                var nutrionalProfileCreate = _mapper.Map<NutrionalProfile>(nutProfileReq);
                nutrionalProfileCreate.UserId = request.UserId;
                nutrionalProfileCreate.CreatedBy = request.UserId;
                nutrionalProfileCreate.User = user;
                nutrionalProfileCreate.Enabled = true;
                await _unitOfWork
                    .Repository<NutrionalProfile>().AddAsync(nutrionalProfileCreate);
            }
        }

        private async Task SaveUserActivities(UpdateUserSportProfileCommand request)
        {
            var userActivitiesReq = request.Activities;
            var userActiDel = await _unitOfWork.Repository<UserActivity>().GetAsync(x => x.UsersId == request.UserId);

            foreach (var userAct in userActiDel)
            {
                await _unitOfWork.Repository<UserActivity>().DeleteAsync(userAct);
            }

            foreach (var newAler in userActivitiesReq)
            {
                var userActivityCreate = new UserActivity
                {
                    UsersId = request.UserId,
                    ActivityId = newAler,
                    Enabled = true,
                    CreatedBy = request.UserId
                };

                await _unitOfWork
                    .Repository<UserActivity>()
                    .AddAsync(userActivityCreate);
            }
        }

        private async Task SaveUserGoals(UpdateUserSportProfileCommand request)
        {
            var userGoalsReq = request.Goals;
            var userGoalsDel = await _unitOfWork.Repository<UserGoal>().GetAsync(x => x.UsersId == request.UserId);

            foreach (var userGoal in userGoalsDel)
            {
                await _unitOfWork.Repository<UserGoal>().DeleteAsync(userGoal);
            }

            foreach (var newAler in userGoalsReq)
            {
                var userGoalCreate = new UserGoal
                {
                    UsersId = request.UserId,
                    GoalId = newAler,
                    Enabled = true,
                    CreatedBy = request.UserId
                };

                await _unitOfWork
                    .Repository<UserGoal>()
                    .AddAsync(userGoalCreate);
            }
        }

        private async Task SaveSportProfile(UpdateUserSportProfileCommand request, ApplicationUser user)
        {
            var sportProfileReq = request.SportProfile;
            var sportProfile =
                await _unitOfWork
                    .Repository<SportProfile>()
                    .GetAsync(x =>
                        x.UserId == request.UserId
                        &&
                        x.Enabled == true
                    );

            if (sportProfile.Count > 0)
            {
                var sportProfileUpdate = sportProfile[0];
                sportProfileUpdate.ExcerciseByWeek = sportProfileReq.ExcerciseByWeek;
                sportProfileUpdate.PhysicalLevelId = sportProfileReq.PhysicalLevelId;
                sportProfileUpdate.HasInjuries = sportProfileReq.HasInjuries;
                sportProfileUpdate.WhatInjuries = sportProfileReq.WhatInjuries;
                sportProfileUpdate.Weight = sportProfileReq.Weight;
                sportProfileUpdate.Heigth = sportProfileReq.Heigth;
                sportProfileUpdate.UpdateBy = request.UserId;
                sportProfileUpdate.User = user;
                await _unitOfWork.Repository<SportProfile>().UpdateAsync(sportProfileUpdate);
            }
            else
            {
                var sportProfileCreate = _mapper.Map<SportProfile>(sportProfileReq);
                sportProfileCreate.UserId = request.UserId;
                sportProfileCreate.CreatedBy = request.UserId;
                sportProfileCreate.Enabled = true;
                sportProfileCreate.User = user;
                await _unitOfWork.Repository<SportProfile>().AddAsync(sportProfileCreate);
            }
        }
    }
