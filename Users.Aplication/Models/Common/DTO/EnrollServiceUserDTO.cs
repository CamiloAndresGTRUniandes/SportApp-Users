namespace Users.Application.Models.Common.DTO ;
using Aplication.Models.Common.DTO;

    public class EnrollServiceUserDTO
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string UserAsociateId { get; set; }
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public bool WasPayed { get; set; }
        public string CategoryName { get; set; }
        public ReferencialTableDTO Plan { get; set; }
        public UserBasicInfo User { get; set; }
        public DateTime? StartSuscription { get; set; }
        public DateTime? EndSuscription { get; set; }
    }
