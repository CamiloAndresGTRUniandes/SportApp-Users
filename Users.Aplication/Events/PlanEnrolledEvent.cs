namespace Users.Application.Events ;
using Constans;
using Services.Domain.Core.Events;

    public class PlanEnrolledEvent : Event
    {
        public PlanEnrolledEvent(string userId, DateTime startSuscription, DateTime endSuscription, PlanEvent plan)
        {
            UserId = userId;
            StartDate = startSuscription;
            EndDate = endSuscription;
            Plan = plan;
            Queue = Queues.PlanEnrolledQueue;
        }

        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PlanEvent Plan { get; set; }
    }

    public class PlanEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
    }
