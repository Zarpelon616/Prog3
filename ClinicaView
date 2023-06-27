using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Model;

namespace Arquivos.Views
{
    public class ClinicaView
    {
        private ClinicaController ClinicaController;
        public ClinicaView()
        {
            ClinicaController = new ClinicaController();
            this.Init();
        }

        public void Init()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("VOCE ESTA EM CLINICAS");
            Console.WriteLine("*********************");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir Clinica");
            Console.WriteLine("2 - Listar Clinica");
            Console.WriteLine("3 - Exportar Clinica");
            Console.WriteLine("4 - Importar Clinica");
            Console.WriteLine("5 - Pesquisar Clinica");
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
            List<Clinica> listagem =
                ClinicaController.List();

            for(int i = 0; i < listagem.Count; i ++)//+= e ++ são convençoes de variavel  
            {
                Console.WriteLine( Print(listagem[i]) );
            }//contador, acumulador e flag são metodos 
            //tembem poderia ser var cliente = listagem[i];
            //                       Print(cliente);


        }

        private string Print(Clinica clinica)//Vai imprimir os valores
        {
            string retorno = "";
            retorno += $"Id: {clinica.ID} \n";//\n serve pra quebrar linha que nem shift + Enter
            retorno += $"Nome: {clinica.FirstName} \n";
            retorno += "-------------------------------------------\n";

            return retorno;
        }

        private void Insert()
        {
            Clinica clinica = new Clinica();//Vai armazenar as imformações na lista client

            clinica.ID = ClinicaController.GetNextId();
            
            Console.WriteLine("Informe o primeiro nome");
            clinica.FirstName = Console.ReadLine();
            
            Console.WriteLine("Informe o email");
            clinica.Email = Console.ReadLine();

            bool retorno = ClinicaController.Insert(clinica);

            if( retorno )
                Console.WriteLine("Cliente inserido com sucesso!");
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if( ClinicaController.ExportToTextFile() )
            
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
            
                Console.WriteLine("Oooops.");    
        }

        private void Import()
        {
            if(ClinicaController.ImportFromTxtFile())
                Console.WriteLine("Dasos imporados com sucesso!");
            else
                Console.WriteLine("Oooooops.");
        }

        private void SearchByName()
        {
            Console.WriteLine("Pesquisar Cliente pelo nome");
            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine();

            foreach( Clinica c in ClinicaController.SearchByName(name) )
            {
                Console.WriteLine( c.ToString() );
            }
            
        }
        
    }
}
