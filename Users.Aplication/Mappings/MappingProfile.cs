namespace Users.Aplication.Mappings ;
using Application.Features.UsersSportProfile.Queries.GetUsersFilters;
using AutoMapper;
using Dominio;
using Features.Activities.Queries.GetAllActivities;
using Features.Cities.Queries.GetCityById;
using Features.Cities.Queries.GetCityByState;
using Features.Countries.Queries.GetAllCountry;
using Features.Genres.Queries.GetAllGenre;
using Features.Goals.Queries.GetAllGoals;
using Features.NutritionalAllergies.Queries.GetAllNutionalAllergies;
using Features.PhysicalLevels.Queries.GetAllPhysicalLeve;
using Features.States.Queries.GetStatesByCountry;
using Features.TypesOfNutrition.Queries.GetAllTypeOfNutrition;
using Features.UsersSportProfile.Command.UpdateUserProfile;
using Features.UsersSportProfile.Queries.GetUserById;
using Models.Common.DTO;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GetAllGenresResult>().ReverseMap();
            CreateMap<Country, GetAllCountryResult>().ReverseMap();
            CreateMap<State, GetStatesByCountryResult>().ReverseMap();
            CreateMap<City, GetCityByStateResult>().ReverseMap();
            CreateMap<TypeOfNutrition, GetAllTypeOfNutritionResult>().ReverseMap();
            CreateMap<NutricionalAllergy, GetAllNutionalAllergiesResult>().ReverseMap();
            CreateMap<PhysicalLevel, GetAllPhysicalResult>().ReverseMap();
            CreateMap<Activity, GetAllActivitiesResult>().ReverseMap();
            CreateMap<Goal, GetAllGoalsResult>().ReverseMap();
            CreateMap<NutrionalProfileDTO, NutrionalProfile>().ReverseMap();
            CreateMap<SportProfileDTO, SportProfile>().ReverseMap();
            CreateMap<UpdateUserSportProfileCommand, ApplicationUser>().ReverseMap();
            CreateMap<SportProfile, SportProfileDTO>().ReverseMap();
            CreateMap<GetUserByIdQueryResult, ApplicationUser>().ReverseMap();
            CreateMap<GetUsersFiltersResult, ApplicationUser>().ReverseMap();
            CreateMap<GetCityByIdResult, City>().ReverseMap();
        }
    }
