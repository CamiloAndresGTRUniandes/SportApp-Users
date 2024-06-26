﻿namespace Users.Application.Models.Common.DTO ;
using Aplication.Models.Common.DTO;
using Constans;
using Services.Domain.Core.Events;

    public class UserProfileEventBus : Event
    {
        public UserProfileEventBus()
        {
            Queue = Queues.UserUpdateQueue;
        }

        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }


        public ReferencialTableDTO Genre { get; set; }

        public int Age { get; set; }
        public ReferencialTableDTO Country { get; set; }

        //public Guid CountryId { get; set; }
        public ReferencialTableDTO State { get; set; }

        //public Guid StateId { get; set; }
        //  public Guid CityId { get; set; }
        public ReferencialTableDTO City { get; set; }

        public NutrionalProfileDTO NutrionalProfile { get; set; } = new();
        public ICollection<Guid> NutricionalAllergies { get; set; } = new HashSet<Guid>();
        public ICollection<Guid> Activities { get; set; } = new HashSet<Guid>();
        public ICollection<Guid> Goals { get; set; } = new HashSet<Guid>();
        public SportProfileDTO SportProfile { get; set; } = new();
        public ReferencialTableDTO PhisicalLevel { get; set; }
    }
