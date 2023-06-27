using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Model
{//Inicio do Escopo do Namespace
    public class Clinica
    {//Inicio do Escopo da Classe
        public int ID { get; set; } //Atributo Unico
        public string FirstName { get; set; }
        public string Email { get; set; }


        //Os métodos construtores são responsaveis por instanciar 
        //uma variavel do tipo especificado pela classe.
        //A regra é de que o construtor tenha o mesmo nome
        //da Classe.
        public Clinica()
        {
            
        }//Permite usar a variavel sem criar valor nenhum de 'id'



        //Método SEMPRE utiliza ()
        public Clinica(
            int id
            , string? firstName
            , string? email
        )
        {//Inicio do Escopo deste método
            ID = id;
            FirstName = firstName;
            Email = email;
        }//Fim do Escopo deste método

        public string FullName => $"{this.FirstName}";//atirbuto com chamada funcional com nome e sobrenome

        public override string ToString()
        {
            return $"id: {this.ID}; Name: {this.FullName}";
        }

    }//Fim do Escopo da Classe
}//Fim do Escopo do Namespace
