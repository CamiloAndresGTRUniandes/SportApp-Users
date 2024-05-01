namespace Users.Application.Features.RecordTrainingSessions.Commads ;
using MediatR;

    public class RecordTrainingSessionsCreateCommand : IRequest<Unit>
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string UserId { get; set; }
        public string TotalTimeExcercise { get; set; }
        public int TotalCalories { get; set; }
        public Guid IntensityId { get; set; }
        public decimal FTP { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
