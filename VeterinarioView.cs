using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Model;

namespace Arquivos.Views
{
    public class VeterinarioView
    {
        private VeterinarioController veterinarioController;
        public VeterinarioView()
        {
            veterinarioController = new VeterinarioController();
            this.Init();
        }

        public void Init()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("VOCE ESTA EM VETERINARIO");
            Console.WriteLine("*********************");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir médico");
            Console.WriteLine("2 - Listar médico");
            Console.WriteLine("3 - Exportar médico");
            Console.WriteLine("4 - Importar médico");
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

                default:
                break;
            }
        }
        //Void é quando o método é vazio ele não da retorno o retorno é vazio
        private void List()
        {//listagem é a variavel
            List<Veterinario> listagem =
                VeterinarioController.List();

            for(int i = 0; i < listagem.Count; i ++)//+= e ++ são convençoes de variavel  
            {
                Console.WriteLine( Print(listagem[i]) );
            }//contador, acumulador e flag são metodos 
            //tembem poderia ser var cliente = listagem[i];
            //                       Print(cliente);


        }

        private string Print(Veterinario veterinario)//Vai imprimir os valores
        {
            string retorno = "";
            retorno += $"Id: {veterinario.ID} \n";//\n serve pra quebrar linha que nem shift + Enter
            retorno += $"Nome: {veterinario.FirstName}\\{veterinario.LastName} \n";
            retorno += "-------------------------------------------\n";

            return retorno;
        }

        private void Insert()
        {
            Veterinario veterinario = new Veterinario();//Vai armazenar as imformações na lista client

            veterinario.ID = VeterinarioController.GetNextId();
            
            Console.WriteLine("Informe o primeiro nome");
            veterinario.FirstName = Console.ReadLine();

            Console.WriteLine("Informe o sobrenome");
            veterinario.FirstName = Console.ReadLine();
            
            Console.WriteLine("Informe o email");
            veterinario.Email = Console.ReadLine();
            
            Console.WriteLine("Informe o Cpf");
            veterinario.CPF = Console.ReadLine(); 

            bool retorno = VeterinarioController.Insert(veterinario);

            if( retorno )
                Console.WriteLine("Médico inserido com sucesso!");
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if( VeterinarioController.ExportToTextFile() )
            
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
            
                Console.WriteLine("DEU ERRO.");    
        }

        private void Import()
        {
            if(VeterinarioController.ImportFromTxtFile())
                Console.WriteLine("Dasos imporados com sucesso!");
            else
                Console.WriteLine("DEU ERRO.");
        }
    }
}
