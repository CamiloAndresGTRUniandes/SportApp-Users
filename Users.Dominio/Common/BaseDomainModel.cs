namespace Users.Dominio.Common ;

    public class BaseDomainModel
    {
        public Guid Id { get; init; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdateAt { get; set; }

        public string? UpdateBy { get; set; }

        public bool Enabled { get; set; }
    }
