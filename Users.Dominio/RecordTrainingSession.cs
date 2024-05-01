namespace Users.Dominio ;
using Common;

    public class RecordTrainingSession : BaseDomainModel
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string UserId { get; set; }
        public TimeSpan TotalTime { get; set; }
        public int TotalCalories { get; set; }
        public Guid IntensityId { get; set; }
        public decimal FTP { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Intensity Intensity { get; set; }
    }
