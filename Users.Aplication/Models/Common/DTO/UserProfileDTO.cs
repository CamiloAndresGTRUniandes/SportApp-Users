namespace Users.Aplication.Models.Common.DTO ;

    public class UserProfileDTO
    {
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Guid GenreId { get; set; }
        public int Age { get; set; }
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public Guid CityId { get; set; }
        public NutrionalProfileDTO NutrionalProfile { get; set; } = new();
        public ICollection<Guid> NutricionalAllergies { get; set; } = new HashSet<Guid>();
        public ICollection<Guid> Activities { get; set; } = new HashSet<Guid>();
        public ICollection<Guid> Goals { get; set; } = new HashSet<Guid>();
        public SportProfileDTO SportProfile { get; set; } = new();
    }
