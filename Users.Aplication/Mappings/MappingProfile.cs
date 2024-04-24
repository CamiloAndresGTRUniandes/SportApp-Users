namespace Users.Aplication.Mappings ;

using Application.Features.EnrollServiceUsers.Commands.CreateEnrollServiceUser;
using Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationById;
using Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationsByAsociate;
using Application.Features.ProductEventSuscriptions.Commands.ProductEventSuscriptionSave;
using Application.Features.Recomendations.Query.GetRecomendationsById;
using Application.Features.Recomendations.Query.GetRecomendationsByUser;
using Application.Features.Recommendations.Command.CreateUserRecommendation;
using Application.Features.TypeOfRecomendations.Queries.GetAllTypeOfRecomendations;
using Application.Features.UserGoalTrackings.Command.UserGoalTrackingSave;
using Application.Features.UserGoalTrackings.Queries.UserGoalTrackingByUserId;
using Application.Features.UsersSportProfile.Queries.GetUsersFilters;
using Application.Models.Common.DTO;
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
            CreateMap<UserBasicInfo, ApplicationUser>().ReverseMap();
            CreateMap<GetCityByIdResult, City>().ReverseMap();
            CreateMap<UpdateUserSportProfileCommand, UserProfileEventBus>().ReverseMap();
            CreateMap<UserRecommendation, GetRecommendationsByUserResult>().ReverseMap();
            CreateMap<ReferencialTableDTO, TypeOfRecommendation>().ReverseMap();
            CreateMap<EnrollServiceUser, GetEnrollRecomendationsByAsociateResult>().ReverseMap();
            CreateMap<GetRecommendationsByIdResult, UserRecommendation>().ReverseMap();
            CreateMap<CreateEnrollServiceUserCommand, EnrollServiceUser>().ReverseMap();
            CreateMap<Plan, ReferencialTableDTO>().ReverseMap();
            CreateMap<GetEnrollRecomendationsByIdResult, EnrollServiceUser>().ReverseMap();
            CreateMap<RecommendationsDTO, UserRecommendation>().ReverseMap();
            CreateMap<CreateUserRecommendationCommand, UserRecommendation>().ReverseMap();
            CreateMap<UserGoalTrackingSaveCommand, UserGoalTracking>().ReverseMap();
            CreateMap<UserGoalTrackingByUserIdResult, UserGoalTracking>().ReverseMap();
            CreateMap<GetAllTypeOfRecomendationsResult, TypeOfRecommendation>().ReverseMap();
            CreateMap<ProductEventSuscriptionSaveCommnand, ProductEventSuscription>().ReverseMap();
        }
    }
