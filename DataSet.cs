using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Model; //permite usar Clients

namespace Arquivos.Data
{
    public static class DataSet //O static serve porque ela não se altera
    {//possibilita pegar dados
        public static List<Client> Clients//tambem podia se Client[] que denota valor
            = new List<Client>(); 
        
        public static List<Animal> Animals
            = new List<Animal>();
        
        public static List<Veterinario> Veterinarios
            = new List<Veterinario>();
    }
}
