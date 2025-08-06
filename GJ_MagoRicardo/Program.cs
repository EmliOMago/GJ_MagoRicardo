using System; // Importa o namespace System para usar funcionalidades básicas como Console

namespace MagoRicardo
{
    class Program
    {

        static void Main()
        {
            // Configurações iniciais do console
            Console.Title = "Aquário Game";
            //Console.SetWindowSize(80, 100);
            //Console.SetBufferSize(80, 100);
            Console.CursorVisible = false;

            // Inicia o menu principal
            Cardapio.Mostrar();
        }
    }
}