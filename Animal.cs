using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Model
{//Inicio do Escopo do Namespace
    public class Animal
    {//Inicio do Escopo da Classe
        public int ID { get; set; } //Atributo Unico
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }

        public Animal()
        {
            
        }//Permite usar a variavel sem criar valor nenhum de 'id'

        //Método SEMPRE utiliza ()
        public Animal(
            int id
            , string? firstName
            , string? email
            , string? tipo
        )
        {//Inicio do Escopo deste método
            ID = ID;
            FirstName = firstName;
            Email = email;
            Tipo = tipo;
        }//Fim do Escopo deste método
    }//Fim do Escopo da Classe
}//Fim do Escopo do Namespace
