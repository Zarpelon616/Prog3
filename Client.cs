using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Model
{//Inicio do Escopo do Namespace
    public class Client
    {//Inicio do Escopo da Classe
        public int ID { get; set; } //Atributo Unico
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CPF { get; set; } //O ? diz que não é brigatório
        public string Email { get; set; }


        //Os métodos construtores são responsaveis por instanciar 
        //uma variavel do tipo especificado pela classe.
        //A regra é de que o construtor tenha o mesmo nome
        //da Classe.
        public Client()
        {
            
        }//Permite usar a variavel sem criar valor nenhum de 'id'



        //Método SEMPRE utiliza ()
        public Client(
            int id
            , string? firstName
            , string? lastName
            , string? cPF
            , string? email
        )
        {//Inicio do Escopo deste método
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            CPF = cPF;
            Email = email;
        }//Fim do Escopo deste método
    }//Fim do Escopo da Classe
}//Fim do Escopo do Namespace
