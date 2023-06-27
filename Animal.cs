using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Model
{
    public class Animal
    {
        public int ID { get; set; } 
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }

        public Animal()
        {
            
        }

        
        public Animal(
            int id
            , string? firstName
            , string? email
            , string? tipo
        )
        {
            ID = ID;
            FirstName = firstName;
            Email = email;
            Tipo = tipo;
        }
    }
}
