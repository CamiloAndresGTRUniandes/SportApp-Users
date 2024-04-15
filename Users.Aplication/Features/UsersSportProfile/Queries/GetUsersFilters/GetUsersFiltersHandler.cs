namespace Users.Application.Features.UsersSportProfile.Queries.GetUsersFilters ;
using Aplication.Contracts.Aplications;
using Aplication.Contracts.Persistence;
using Aplication.Models.Common.DTO;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

    public class GetUsersFiltersHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        UserManager<ApplicationUser> _userManager,
        IUtils _utils
        ) :
            IRequestHandler<GetUsersFiltersQuery, List<GetUsersFiltersResult>>
    {
        public async Task<List<GetUsersFiltersResult>> Handle(GetUsersFiltersQuery request, CancellationToken cancellationToken)
        {
            List<GetUsersFiltersResult> usersResponse = new();
            var usersId = await GetUserIds(request);
            var users = GetUsers(usersId);

            foreach (var user in users)
            {
                var userResult = new GetUsersFiltersResult();
                userResult.UserId = user.Id;
                userResult.Name = user.Name;
                userResult.LastName = user.LastName;
                userResult.Email = user.Email;
                userResult.PhoneNumber = user.PhoneNumber;
                userResult.DateOfBirth = user.DateOfBirth.Value;
                userResult.GenreId = user.GenreId.Value;
                userResult.CountryId = user.CountryId.Value;
                userResult.StateId = user.StateId.Value;
                userResult.CityId = user.CityId.Value;
                userResult.NutrionalProfile = _mapper.Map<NutrionalProfileDTO>(user.NutrionalProfile);
                userResult.NutricionalAllergies = user.NutricionalAllergies.Select(p => p.Id).ToList();
                userResult.Activities = user.Activities.Select(p => p.Id).ToList();
                userResult.Goals = user.Goals.Select(p => p.Id).ToList();
                userResult.SportProfile = _mapper.Map<SportProfileDTO>(user.SportProfile);
                if (userResult?.DateOfBirth.Year < 10)
                {
                    userResult.DateOfBirth = DateTime.Now.Date.AddYears(-19);
                }
                userResult.Age = _utils.CalculateAge(userResult.DateOfBirth);

                usersResponse.Add(userResult);
            }


            return usersResponse;
        }

        #region Queries

        public List<ApplicationUser> GetUsers(List<string> usersId)
        {
            var users = _userManager.Users
                .Include(p => p.Activities)
                .Include(p => p.NutricionalAllergies)
                .Include(p => p.Goals)
                .Include(p => p.NutrionalProfile)
                .Include(p => p.SportProfile)
                .Where(p => usersId.Contains(p.Id))
                .ToList();

            return users;
        }


        private async Task<List<string>> GetUserIds(GetUsersFiltersQuery request)
        {
            var usersAllergies =
                (
                    await
                        _unitOfWork.UserAllergyRepository.
                            GetAsync(x => request.NutritionalAllergies.Contains(x.NutricionalAllergyId))
                    ).Select(x => x.UsersId);
            var userActivities = (
                await
                    _unitOfWork.Repository<UserActivity>().
                        GetAsync(x => request.Activities.Contains(x.ActivityId))
                ).Select(x => x.UsersId);
            var userGoals = (
                await
                    _unitOfWork.Repository<UserGoal>().
                        GetAsync(x => request.Goals.Contains(x.GoalId))
                ).Select(x => x.UsersId);

            var usersProfile = (await _unitOfWork.Repository<SportProfile>().
                GetAsync(x => request.PhysicalLevels.Contains(x.PhysicalLevelId))
                ).Select(x => x.UserId);

            var users = _userManager
                .Users
                .Where(p => request.CountriesId.Contains(p.CountryId.Value)
                            || request.StatesId.Contains(p.StateId.Value)
                            || request.CitiesId.Contains(p.CityId.Value)
                )
                .Select(p => p.Id).ToList();

            var UsersId = new List<string>();
            UsersId.AddRange(usersAllergies);
            UsersId.AddRange(userActivities);
            UsersId.AddRange(userGoals);
            UsersId.AddRange(usersProfile);
            UsersId.AddRange(users);
            return UsersId.ToList();
        }

        #endregion
    }
