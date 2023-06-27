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

        public List<Animal> List()
        {
            return DataSet.Animals;
        }


        //Bool é boleano
        public bool Insert(Animal animal)
        {
            if( animal == null)
                return false;

            if( string.IsNullOrWhiteSpace(animal.FirstName) )
                return false;
            
            DataSet.Animals.Add(animal);
            
            return true;//Se passa pelas outras opções retora true
        }

         public bool ExportToTextFile()
        {
            if(!Directory.Exists(directoryName))
             Directory.CreateDirectory(directoryName);
            
            string fileContent = string.Empty;
            foreach(Animal c in DataSet.Animals)
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
        catch(IOException ioEx)
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
                while(line != null)
                {
                    Animal animal = new Animal();
                    string[] animalData = line.Split(';');
                    animal.ID = Convert.ToInt32( animalData[0] );
                    animal.FirstName = animalData[1];
                    animal.Email = animalData[2];
                    animal.Tipo = animalData[3];

                    DataSet.Animals.Add(animal);

                    line = sr.ReadLine();             
                }

                return true;
            }
            catch(Exception ex)//ex é exeption
            {
                Console.WriteLine("Oooops. Ocorreu um erro ao tentar importar os dados!");
                Console.WriteLine(ex.Message);
                return false;
            }


            

        }

       
        public int GetNextId() 
        {
            int tam = DataSet.Animals.Count;
            if( tam > 0 )
                return DataSet.Animals[tam -1].ID + 1;
            else
                return 1;
        }

    }
}
