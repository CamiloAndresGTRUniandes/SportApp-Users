namespace Users.Dominio ;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

    public class UserGoal : BaseDomainModel
    {
        public Guid GoalId { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UsersId { get; set; }
    }
