namespace Users.Dominio ;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

    public class UserAllergy : BaseDomainModel
    {
        [ForeignKey("AspNetUsers")]
        public string UsersId { get; set; }

        public Guid NutricionalAllergyId { get; set; }
    }
