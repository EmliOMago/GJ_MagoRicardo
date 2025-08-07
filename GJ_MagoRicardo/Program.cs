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
                        MostrarMaioresRecordes();
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

		public static void MostrarMaioresRecordes()
        {
            Console.Clear();
            Console.WriteLine("=== TOP 10 RECORDES ===");
            string recordes = LerMaioresRecordes();

            Console.WriteLine(recordes);
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey(true);
        }

        public static string LerMaioresRecordes()
        {
            try
            {
                string caminho = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                    "MagoRicardoGameJam2025",
                    "PontosMR.txt"
                );

                if (!File.Exists(caminho))
                    return "Nenhum recorde registrado";

                var linhas = File.ReadAllLines(caminho)
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .ToArray();

                if (linhas.Length == 0)
                    return "Sem registros";

                // Ordena decrescentemente pela pontuação
                var recordesOrdenados = linhas
                    .Select(linha => new {
                        Texto = linha,
                        Pontos = ExtrairPontuacao(linha)
                    })
                    .OrderByDescending(x => x.Pontos)
                    .Take(10)
                    .Select((x, index) => $"{index + 1}. {x.Texto}") // Numera os recordes
                    .ToArray();

                return string.Join("\n", recordesOrdenados.Length > 0 ?
                                      recordesOrdenados :
                                      new string[] { "Sem registros válidos" });
            }
            catch
            {
                return "Erro ao ler recordes";
            }
        }

        private static int ExtrairPontuacao(string linha)
        {
            try
            {
                // Formato: "Nome - X pontos em DD/MM/AAAA HH:MM"
                int inicioPontos = linha.IndexOf("-") + 1;
                int fimPontos = linha.IndexOf("pontos") - 1;
                string valorPontos = linha.Substring(inicioPontos, fimPontos - inicioPontos).Trim();
                return int.Parse(valorPontos);
            }
            catch
            {
                return 0; // Se não conseguir extrair, considera 0 pontos
            }
        }
    }
}