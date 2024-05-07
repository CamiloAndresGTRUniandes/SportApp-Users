namespace Users.Application.Events ;
using Constans;
using Services.Domain.Core.Events;

    public class PlanEnrolledEvent : Event
    {
        public PlanEnrolledEvent(string userId, DateTime startSuscription, DateTime endSuscription, Guid planId)
        {
            UserId = userId;
            StartSuscription = startSuscription;
            EndSuscription = endSuscription;
            PlandId = planId;
            Queue = Queues.PlanEnrolledQueue;
        }

        public string UserId { get; set; }
        public DateTime StartSuscription { get; set; }
        public DateTime EndSuscription { get; set; }
        public Guid PlandId { get; set; }
    }
