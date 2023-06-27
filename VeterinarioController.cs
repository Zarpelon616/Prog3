using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Arquivos.Data;
using Arquivos.Model;

namespace Arquivos.Controllers
{
    
    public class VeterinarioController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Doctor.txt"; // quando é privada somente a própria classe exerga ao contrario da publica

        public List<Veterinario> List()//vai trazer uma lista Client
        {
            return DataSet.Veterinarios;
        }


        //Bool é boleano
        public bool Insert(Veterinario veterinarios)
        {
            if( veterinarios == null)
                return false;

            if( veterinarios.ID <= 0)
                return false;
            
            if( string.IsNullOrWhiteSpace(veterinarios.FirstName) )//IsNullOsWhiteSpace é quando esta vazio
                return false;
            
            DataSet.Veterinarios.Add(veterinarios);
            
            return true;//Se passa pelas outras opções retora true
        }

        public bool ExportToTextFile()
        {
            if(!Directory.Exists(directoryName))//o ! = not faz ele retornar falso se não existir
             Directory.CreateDirectory(directoryName);
            
            string fileContent = string.Empty;
            foreach(Veterinario a in DataSet.Veterinarios)// pega os clientes do dataset com a variavel a
            {
                fileContent +=$"{a.ID};{a.CPF};{a.FirstName};{a.LastName};{a.Email}";
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
                    Veterinario doctor = new Veterinario();
                    string[] doctorData = line.Split(';');//cria um vetor de string usando[]//o Split que o line//usa aspas simples para caracteres 
                    doctor.ID = Convert.ToInt32( doctorData[0] );//o [] é usado para determinar a string
                    doctor.CPF = doctorData[1];
                    doctor.FirstName = doctorData[2];
                    doctor.LastName = doctorData[3];
                    doctor.Email = doctorData[4];

                    DataSet.Veterinarios.Add(doctor);

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

        public List<Veterinario> SearchByName(string name) //Procura pelo nome
        {
            if ( string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name) ) //Vai checar que se esta vazio
            return null;

            List<Veterinario> veterinarios = new List<Veterinario>();
            for(int i = 0; i < DataSet.Veterinarios.Count; i++)
            {
                var c = DataSet.Veterinarios[i]; //Percorre os elementos da lista e os coloca na variavel c
                if( c.FullName.ToLower().Contains(name.ToLower()) ) //Tolower faz com que independente do maiusculo ou minusculo a busca funcione igual
                {
                    veterinarios.Add(c);
                }
            }
            return veterinarios;
        }

        public int GetNextId() //int retorna um inteiro e GetNextId tras o proximo o id
        {
            int tam = DataSet.Veterinarios.Count;
            if( tam > 0 )
                return DataSet.Veterinarios[tam -1].ID + 1;
            else
                return 1;
        }
    }
}
