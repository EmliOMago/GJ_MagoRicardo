using System; // Importa o namespace System para usar funcionalidades básicas como Console

namespace MagoRicardo
{
    class Program
    {

        static void Main()
        {
            // Configurações iniciais do console
            Console.Title = "Aquário Game";
            Console.SetWindowSize(161, 63);
            Console.SetBufferSize(161, 63);
            Console.CursorVisible = false;

            // Inicia o menu principal
            Cardapio.Mostrar();
        }
    }
}