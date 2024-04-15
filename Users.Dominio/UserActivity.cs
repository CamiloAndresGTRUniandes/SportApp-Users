namespace Users.Dominio ;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

    public class UserActivity : BaseDomainModel
    {
        [ForeignKey("AspNetUsers")]
        public string UsersId { get; set; }

        public Guid ActivityId { get; set; }
    }
