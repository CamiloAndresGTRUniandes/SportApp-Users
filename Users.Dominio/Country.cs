﻿using Users.Dominio.Common;
namespace Users.Dominio
{
    public class Country:BaseDomainModel
    {
        public Country()
        {
            States= new HashSet<State>();
        }
        public string Name { get; set; } = string.Empty;
        public ICollection<State> States { get; set; }
        public ICollection<ApplicationUser>? users { get; set; }
    }
}
