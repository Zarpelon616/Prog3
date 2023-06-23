using Arquivos.Views; //Ele vai comunicar com o view

int option = 0;

do
{
    Console.WriteLine("*******************************************");
    Console.WriteLine("Programa para leitura e exportação de dados");
    Console.WriteLine("*******************************************");
    Console.WriteLine("");
    Console.WriteLine("1 - Clientes");

    option = Convert.ToInt32( Console.ReadLine() );

    switch(option)
    {
        case 1 :
        Console.WriteLine("OPÇÃO CLIENTES");
        ClientView clientView = new ClientView();
        break;
        

        case 2 :
        Console.WriteLine("OPÇÃO ANIMAIS");
        AnimalView animalView = new AnimalView();
        break;
    }
}
while( option > 0); //enquanto option for maior que zero
