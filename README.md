# Prog3
programação
Console.WriteLine("***************************");
Console.WriteLine("Excrever Número Por Extenso"); 
Console.WriteLine("***************************");

Console.WriteLine("Informe um Número:");
string numero = Console.ReadLine();
int nro=0;
try
{
    nro = Convert.ToInt32(numero);
}
catch
{
    Console.WriteLine("O Número Não é valido.");
}
string retorno = "";

switch(numero.Length)
{
    case 1 :
        Unidade unidade = new Unidade();
        retorno = unidade.UnidadePorExtenso(nro);
    break;
}

switch(numero.Length)
{
    case 2 :
        Dezena dezena = new Dezena();
        retorno = dezena.DezenaPorExtenso(nro);
    break;
}

switch(numero.Length)
{
    case 3 :
        Centena centena  = new Centena();
        retorno = centena.CentenaPorExtenso(nro);
    break;
}

        
Console.WriteLine(retorno);

