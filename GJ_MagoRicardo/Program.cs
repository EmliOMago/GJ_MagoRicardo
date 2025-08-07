using System; // Importa o namespace System para usar funcionalidades básicas como Console

namespace MagoRicardo
{
    class Program
    {

        static void Main()
        {
            // Configurações iniciais do console
            Console.Title = "Fuga Partilhada";
            Console.SetWindowSize(161, 63);
            Console.SetBufferSize(161, 63);
            Console.CursorVisible = false;

            // Inicia o menu principal
            Cardapio.Mostrar();
        }
    }

    class Cardapio
    {
        public static void Mostrar()
        {
            // Limpa o menu
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");
            Console.WriteLine("                                                                                                                                                                                                       ");

            //Escreve o menu e utiliza os inputs
            while (true)
            {
                Console.Clear();
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n   ");
                Console.WriteLine("               ************************************************************************************************************************************************************************************");
                Console.WriteLine("               ************************************************************************************************************************************************************************************");
                Console.WriteLine("               **************************************************************************************************___*****************,--,******,---,***********************************************");
                Console.WriteLine("               *****.--.,*************************************************,-.----.*****************************,--.'|_*****,--,****,--.'|****,--.' |*************************,---,*****************");
                Console.WriteLine("               ***,--.'  |**********,--,**********************************|    /  |******************__**,-.***|  | :,'**,--.'|****|  | :****|  |  :***********************,---.'|*****************");
                Console.WriteLine("               ***|  | /|/********,'_ /|****,----._,.*********************|   :    |***************,' ,'/ /|***:  : ' :**|  |,*****:  : '****:  :  :***********************|   | :*****************");
                Console.WriteLine("               ***:  : :*****.--.*|  | :***/   /  '*/****,--.--.**********|   | .| :****,--.--.****'  | |' |*.;__,'  /***`--'_*****|  ' |****:  |  |,--.****,--.--.********|   | |****,--.--.******");
                Console.WriteLine("               ***:  | |-,*,'_*/|*:  . |**|   :     |***/       |*********.   : |: |***/       |***|  |   ,'*|  |   |****,' ,'|****'  | |****|  :  '   |***/       |*****,--.__| |***/       |*****");
                Console.WriteLine("               ***|  : :/|*|  ' |*|  . .**|   | .|  .**.--.  .-. |********|   |  | :**.--.  .-. |**'  :  /***:__,'| :****'  | |****|  | :****|  |   /' :**.--.  .-. |***/   ,'   |**.--.  .-. |****");
                Console.WriteLine("               ***|  |  .'*|  | '*|  | |**.   ; ';  |***|__|/: . .********|   : .  |***|__|/: . .**|  | '******'  : |__**|  | :****'  : |__**'  :  | | |***|__|/: . .**.   '  /  |***|__|/: . .****");
                Console.WriteLine("               ***'  : '***:  | :*;  ; |**'   .   . |***,# .--.; |********:   | |`-'***,# .--.; |**;  : |******|  | '.'|*'  : |__ *|  | '.'|*|  |  ' | :***,# .--.; |**;   |:  | |***,# .--.; |****");
                Console.WriteLine("               ***|  | |***'  :  `--'   |**`---`-'| |**/  /  ,.  |********:   : :*****/  /  ,.  |**|  , ;******;  :    ;*|  | '.'|*;  :    ;*|  :  :_:,'**/  /  ,.  |**|   | '/  '**/  /  ,.  |****");
                Console.WriteLine("               ***|  : |***:  ,      .-./**.'__/|_: |*;  :   .'   |*******|   | :****;  :   .'   |**---'*******|  ,   /**;  :    ;*|  ,   /**|  | ,'*****;  :   .'   |*|   :    :|*;  :   .'   |***");
                Console.WriteLine("               ***|  |,'****`--`----'******|   :    :*|  ,     .-./*******`---'.|****|  ,     .-./**************---`-'***|  ,   /***---`-'***`--''*******|  ,     .-./**|   |  /***|  ,     .-./***");
                Console.WriteLine("               ***`--'**********************|   |  /***`--`---'*************`---`*****`--`---'****************************---`-'**************************`--`---'*******`----'*****`--`---'*******");
                Console.WriteLine("               ******************************`--`-'************************************************************************************************************************************************");
                Console.WriteLine("               ************************************************************************************************************************************************************************************");
                Console.WriteLine("               ************************************************************************************************************************************************************************************");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n\n  ");
                Console.WriteLine("                                                                                     Pressione a tecla 1 para Jogar");
                Console.WriteLine("                                                                                Pressione a tecla 2 para ver os Recordes");
                Console.WriteLine("                                                                    Pressione a tecla 3. para sair do jogo (ou Esc) {Não faça isso!!!}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n  ");
                Console.WriteLine("     Explicação completa do jogo deve ser inserida aqui");


                var tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        JogarAquario.Iniciar();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        MostrarRecordes();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        public static void MostrarRecordes()
        {
            Console.Clear();
            Console.WriteLine("=== RECORDES ===");
            Console.WriteLine(JogarAquario.LerRecorde());
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey(true);
        }
    }
}