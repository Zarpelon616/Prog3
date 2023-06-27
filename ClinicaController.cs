using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Arquivos.Data;
using Arquivos.Model;

namespace Arquivos.Controllers
{
    
    public class ClinicaController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Clinica.txt"; // quando é privada somente a própria classe exerga ao contrario da publica

        public List<Clinica> List()//vai trazer uma lista Client
        {
            return DataSet.Clinicas;
        }


        //Bool é boleano
        public bool Insert(Clinica clinica)//
        {
            if( clinica == null)
                return false;

            if( clinica.ID <= 0)
                return false;
            
            if( string.IsNullOrWhiteSpace(clinica.FirstName) )//IsNullOsWhiteSpace é quando esta vazio
                return false;
            
            DataSet.Clinicas.Add(clinica);
            
            return true;//Se passa pelas outras opções retora true
        }

        public bool ExportToTextFile()
        {
            if(!Directory.Exists(directoryName))//o ! = not faz ele retornar falso se não existir
             Directory.CreateDirectory(directoryName);
            
            string fileContent = string.Empty;
            foreach(Client c in DataSet.Clients)// pega os clientes do dataset com a variavel c
            {
                fileContent +=$"{c.ID};{c.FirstName};{c.Email}";
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
                    Clinica clinica = new Clinica();
                    string[] clinicaData = line.Split(';');//cria um vetor de string usando[]//o Split que o line//usa aspas simples para caracteres 
                    clinica.ID = Convert.ToInt32( clinicaData[0] );//o [] é usado para determinar a string
                    clinica.FirstName = clinicaData[1];
                    clinica.Email = clinicaData[2];

                    DataSet.Clinicas.Add(clinica);

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
        public List<Clinica> SearchByName(string name) //Procura pelo nome
        {
            if ( string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name) ) //Vai checar que se esta vazio
            return null;

            List<Clinica> clinicas = new List<Clinica>();
            for(int i = 0; i < DataSet.Clinicas.Count; i++)
            {
                var c = DataSet.Clinicas[i]; //Percorre os elementos da lista e os coloca na variavel c
                if( c.FullName.ToLower().Contains(name.ToLower()) ) //Tolower faz com que independente do maiusculo ou minusculo a busca funcione igual
                {
                    clinicas.Add(c);
                }
            }
            return clinicas;
        }
        public int GetNextId() //int retorna um inteiro e GetNextId tras o proximo o id
        {
            int tam = DataSet.Clinicas.Count;
            if( tam > 0 )
                return DataSet.Clinicas[tam -1].ID + 1;
            else
                return 1;
        }
    }
}
