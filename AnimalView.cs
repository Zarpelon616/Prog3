using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Model;

namespace Arquivos.Views
{
    public class AnimalView
    {
        private AnimalController AnimalController;
        public AnimalView()
        {
            AnimalController = new AnimalController();
            this.Init();
        }

        public void Init()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("VOCE ESTA EM ANIMA");
            Console.WriteLine("*********************");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir Animal");
            Console.WriteLine("2 - Listar Animal");
            Console.WriteLine("3 - Exportar Animal");
            Console.WriteLine("4 - Importar Animal");
            Console.WriteLine("5 - Pesquisar Animal");
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
            List<Animal> listagem =
                AnimalController.List();

            for(int i = 0; i < listagem.Count; i ++)//+= e ++ são convençoes de variavel  
            {
                Console.WriteLine( Print(listagem[i]) );
            }//contador, acumulador e flag são metodos 
            //tembem poderia ser var cliente = listagem[i];
            //                       Print(cliente);


        }

        private string Print(Animal animal)//Vai imprimir os valores
        {
            string retorno = "";
            retorno += $"Dono: {animal.ID} \n";//\n serve pra quebrar linha que nem shift + Enter
            retorno += $"Nome: {animal.FirstName} \n";
            retorno += $"Tipo de Animal: {animal.Tipo} \n";
            retorno += "-------------------------------------------\n";

            return retorno;
        }

        private void Insert()
        {
            Animal animal = new Animal();//Vai armazenar as imformações na lista client

            animal.ID = AnimalController.GetNextId();//caso o 'id'seja uma string deve colocar ToString()
            
            Console.WriteLine("Informe o primeiro nome");
            animal.FirstName = Console.ReadLine();
            
            Console.WriteLine("Informe o email");
            animal.Email = Console.ReadLine();
            
            Console.WriteLine("Informe o tipo de animal");
            animal.Tipo = Console.ReadLine();

            bool retorno = AnimalController.Insert(animal);

            if( retorno )
                Console.WriteLine("Cliente inserido com sucesso!");
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if( AnimalController.ExportToTextFile() )
            
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
            
                Console.WriteLine("Amigo deu erro.");    
        }

        private void Import()
        {
            if(AnimalController.ImportFromTxtFile())
                Console.WriteLine("Dasos imporados com sucesso!");
            else
                Console.WriteLine("Amigo deu erro.");
        }

                private void SearchByName()
        {
            Console.WriteLine("Pesquisar Cliente pelo nome");
            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine();  

            
            foreach( Animal c in AnimalController.SearchByName(name) )
            {
                Console.WriteLine( c.ToString() );
            }

        }
    }
}
