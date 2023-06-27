using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Arquivos.Data;
using Arquivos.Model;

namespace Arquivos.Controllers
{
    public class AnimalController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Animal.txt";

        public List<Animal> List()//vai trazer uma lista Animal
        {
            return DataSet.Animals;
        }


        //Bool é boleano
        public bool Insert(Animal animal)//
        {
            if( animal == null)
                return false;

            if( string.IsNullOrWhiteSpace(animal.FirstName) )//IsNullOsWhiteSpace é quando esta vazio
                return false;
            
            DataSet.Animals.Add(animal);
            
            return true;//Se passa pelas outras opções retora true
        }

         public bool ExportToTextFile()
        {
            if(!Directory.Exists(directoryName))//o ! = not faz ele retornar falso se não existir
             Directory.CreateDirectory(directoryName);
            
            string fileContent = string.Empty;
            foreach(Animal c in DataSet.Animals)// pega os clientes do dataset com a variavel c
            {
                fileContent +=$"{c.ID};{c.FirstName};{c.Email};{c.Tipo}";
                fileContent += "\n";
            }

        try
        {
            StreamWriter sw = File.CreateText( $"{directoryName}\\{fileName}" );

            sw.Write(fileContent);
            sw.Close();
        }
        catch(IOException ioEx)//caso ocorra algum erro dentro desso processo vai agir
        {
            Console.WriteLine("Erro ao manipular o arquivo.");
            Console.WriteLine(ioEx.Message);
            return false;
        }

        return true;
        }

        public bool ImportFromTxtFile()
        {
            try
            {
                StringReader sr = new StringReader($"{directoryName}\\{fileName}");

                string line = string.Empty;
                line = sr.ReadLine();
                while(line != null)//!= significa 'diferente'//significa enquanto line for diferente de null ele segue em frente
                {
                    Animal animal = new Animal();
                    string[] animalData = line.Split(';');//cria um vetor de string usando[]//o Split que o line//usa aspas simples para caracteres 
                    animal.ID = Convert.ToInt32( animalData[0] );//o [] é usado para determinar a string
                    animal.FirstName = animalData[1];
                    animal.Email = animalData[2];
                    animal.Tipo = animalData[3];

                    DataSet.Animals.Add(animal);

                    line = sr.ReadLine(); //Vai fazer ele ler cada linha            
                }

                return true;
            }
            catch(Exception ex)//ex é exeption
            {
                Console.WriteLine("Oooops. Ocorreu um erro ao tentar importar os dados!");
                Console.WriteLine(ex.Message);//ex.Message vai emviar uma mensagem
                return false;
            }


            

        }

        public List<Animal> SearchByName(string name) //Procura pelo nome
        {
            if ( string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name) ) //Vai checar que se esta vazio
            return null;

            List<Animal> animals = new List<Animal>();
            for(int i = 0; i < DataSet.Clients.Count; i++)
            {
                var c = DataSet.Animals[i]; //Percorre os elementos da lista e os coloca na variavel c
                if( c.FullName.ToLower().Contains(name.ToLower()) ) //Tolower faz com que independente do maiusculo ou minusculo a busca funcione igual
                {
                    animals.Add(c);
                }
            }
            return animals;
        }
       
        public int GetNextId() //int retorna um inteiro e GetNextId tras o proximo o id
        {
            int tam = DataSet.Animals.Count;
            if( tam > 0 )
                return DataSet.Animals[tam -1].ID + 1;
            else
                return 1;
        }

    }
}
