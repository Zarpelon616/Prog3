using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Model;

namespace Arquivos.Views
{
    public class ClientView
    {
        private ClientController ClientController;
        public ClientView()
        {
            ClientController = new ClientController();
            this.Init();
        }

        public void Init()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("VOCE ESTA EM CLIENTES");
            Console.WriteLine("*********************");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir Clientes");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Exportar Clientes");
            Console.WriteLine("4 - Importar Clientes");
            Console.WriteLine("5 - Pesquisar Clientes");
            Console.WriteLine("");

            int option = 0;
            option = Convert.ToInt32( Console.ReadLine() );
            
            switch(option)
            {
                case 1 :
                    Insert();
                break;

                case 2 :
                    List();
                break;

                case 3 :
                    Export();
                break;

                case 4 :
                    Import();
                break;

                case 5 :
                    SearchByName();
                break;

                default:
                break;
            }
        }
        //Void é quando o método é vazio ele não da retorno o retorno é vazio
        private void List()
        {//listagem é a variavel
            List<Client> listagem =
                ClientController.List();

            for(int i = 0; i < listagem.Count; i ++)//+= e ++ são convençoes de variavel  
            {
                Console.WriteLine( Print(listagem[i]) );
            }//contador, acumulador e flag são metodos 
            //tembem poderia ser var cliente = listagem[i];
            //                       Print(cliente);


        }

        private string Print(Client client)//Vai imprimir os valores
        {
            string retorno = "";
            retorno += $"Id: {client.ID} \n";//\n serve pra quebrar linha que nem shift + Enter
            retorno += $"Nome: {client.FirstName}\\{client.LastName} \n";
            retorno += "-------------------------------------------\n";

            return retorno;
        }

        private void Insert()
        {
            Client client = new Client();//Vai armazenar as imformações na lista client

            client.ID = ClientController.GetNextId();
            
            Console.WriteLine("Informe o primeiro nome");
            client.FirstName = Console.ReadLine();

            Console.WriteLine("Informe o sobrenome");
            client.LastName = Console.ReadLine();
            
            Console.WriteLine("Informe o email");
            client.Email = Console.ReadLine();
            
            Console.WriteLine("Informe o Cpf");
            client.CPF = Console.ReadLine(); 

            bool retorno = ClientController.Insert(client);

            if( retorno )
                Console.WriteLine("Cliente inserido com sucesso!");
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if( ClientController.ExportToTextFile() )
            
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
            
                Console.WriteLine("Oooops.");    
        }

        private void Import()
        {
            if(ClientController.ImportFromTxtFile())
                Console.WriteLine("Dasos imporados com sucesso!");
            else
                Console.WriteLine("Oooooops.");
        }

        private void SearchByName()
        {
            Console.WriteLine("Pesquisar Cliente pelo nome");
            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine();

            foreach( Client c in ClientController.SearchByName(name) )
            {
                Console.WriteLine( c.ToString() );
            }
            
        }
        
    }
}
