using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Model
{
    public class Veterinario
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CPF { get; set; }
        public string Email { get; set; }

        public Veterinario()
        {

        }


        public Veterinario(
            int id
            , string? firstName
            , string? lastName
            , string? cPF
            , string? email
        )
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            CPF = cPF;
            Email = email;
        }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public override string ToString()
        {
            return $"id: {this.ID}; Name: {this.FullName}";
        }

    }
}
