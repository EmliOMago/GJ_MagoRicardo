using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MagoRicardo
{

    class JogarAquario
    {
        // Variáveis públicas para armazenar os nomes dos jogadores
        public static string nome1;
        public static string nome2;

        // Variáveis de estado do jogo
        private static int nivel = 1;
        public static int pontuacao1 = 0;
        public static int pontuacao2 = 0;
        private static bool jogoAtivo = true;

        // Posições dos jogadores
        private static int jogador1X = 14, jogador1Y = 20;
        private static int jogador2X = 14, jogador2Y = 40;

        // Posição da saída
        private static int saidaX = 75, saidaY = 30;
        public static bool jogador1Chegou = false;
        public static bool jogador2Chegou = false;
        public static string jogadorVencedor = " ";

        // Listas para armazenar obstáculos e inimigos
        private static List<(int x, int y)> obstaculos = new List<(int x, int y)>();
        private static List<(int x, int y, int direcao)> inimigos = new List<(int x, int y, int direcao)>();

        // Cores do console
        private static ConsoleColor[] coresFases = {
            //ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.DarkYellow,
            //ConsoleColor.Green,
            //ConsoleColor.Blue,
            ConsoleColor.Magenta,
            ConsoleColor.DarkMagenta,
            ConsoleColor.Cyan
        };

        // Temporizadores
        private static DateTime ultimoMovInimigos = DateTime.Now;
        private static DateTime ultimoNovoInimigo = DateTime.Now;

        public static void Iniciar()
        {
            // Limpa o console ao iniciar o módulo
            Console.Clear();

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


            // Solicita os nomes dos jogadores
            Console.Write("Nome do primeiro jogador: ");
            nome1 = Console.ReadLine();
            Console.Write("Nome do segundo jogador: ");
            nome2 = Console.ReadLine();
            Console.Write("\nPressione Enter para iniciar a primeira fase");
            Console.ReadKey(true);
            jogoAtivo = true;
            Jogar();
            
        }

        public static void Jogar()
        {
            // Loop principal do jogo
            while (jogoAtivo)
            {
                PrepararNivel();
                ExecutarNivel();
                AvancarNivel();
            }
        }

        private static void PrepararNivel()
        {
            // Limpa listas do nível anterior
            obstaculos.Clear();
            inimigos.Clear();

            // Adiciona bordas fixas (linha 10, linha 50, coluna 8, coluna 80)
            for (int x = 8; x <= 80; x++)
            {
                obstaculos.Add((x, 10));
                obstaculos.Add((x, 50));
            }
            for (int y = 10; y <= 50; y++)
            {
                obstaculos.Add((8, y));
                obstaculos.Add((80, y));
            }

            // Adiciona obstáculos aleatórios
            Random rand = new Random();
            int numObstaculos = 10 + (10 * nivel);

            // Gera obstáculos até ter caminho válido
            bool caminhoValido;
            do
            {
                // Remove obstáculos aleatórios anteriores
                obstaculos.RemoveAll(o => o.y > 10 && o.y < 50 && o.x > 8 && o.x < 80);

                // Adiciona novos obstáculos aleatórios
                for (int i = 0; i < numObstaculos; i++)
                {
                    int x = rand.Next(9, 80);
                    int y = rand.Next(11, 50);

                    // Evita posições próximas aos jogadores e saída
                    if (!PosicaoProxima(jogador1X, jogador1Y, x, y, 5) &&
                        !PosicaoProxima(jogador2X, jogador2Y, x, y, 5) &&
                        !PosicaoProxima(saidaX, saidaY, x, y, 5))
                    {
                        obstaculos.Add((x, y));
                    }
                }

                // Verifica se há caminho livre
                caminhoValido = VerificarCaminhoLivre();
            } while (!caminhoValido);

            // Adiciona contorno da saída (com aberturas acima e abaixo)
            obstaculos.Add((73, 28));
            obstaculos.Add((74, 28));
            obstaculos.Add((76, 28));
            obstaculos.Add((77, 28));
            obstaculos.Add((73, 29));
            obstaculos.Add((77, 29));
            obstaculos.Add((73, 30));
            obstaculos.Add((77, 30));
            obstaculos.Add((73, 30));
            obstaculos.Add((77, 30));
            obstaculos.Add((73, 31));
            obstaculos.Add((77, 31));
            obstaculos.Add((73, 32));
            obstaculos.Add((74, 32));
            obstaculos.Add((76, 32));
            obstaculos.Add((77, 32));

            // Adiciona inimigos iniciais
            for (int i = 0; i < 3; i++)
            {
                AdicionarInimigo(0); // Persegue jogador 1
                AdicionarInimigo(1); // Persegue jogador 2
            }
        }

        private static bool PosicaoProxima(int x1, int y1, int x2, int y2, int distancia)
        {
            // Calcula distância euclidiana entre dois pontos
            double dist = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return dist < distancia;
        }

        private static bool VerificarCaminhoLivre()
        {
            // Usa busca em largura para verificar caminho para jogador 1
            Queue<(int x, int y)> fila = new Queue<(int x, int y)>();
            HashSet<(int x, int y)> visitados = new HashSet<(int x, int y)>();

            fila.Enqueue((jogador1X, jogador1Y));
            visitados.Add((jogador1X, jogador1Y));

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();

                // Verifica se chegou na saída (considerando as entradas)
                if ((atual.x == 75 && atual.y == 19) || (atual.x == 75 && atual.y == 21))
                    return true;

                // Explora vizinhos
                var vizinhos = new (int dx, int dy)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
                foreach (var viz in vizinhos)
                {
                    int nx = atual.x + viz.dx;
                    int ny = atual.y + viz.dy;

                    // Verifica limites do mapa
                    if (nx < 9 || nx > 79 || ny < 11 || ny > 49)
                        continue;

                    // Verifica se é obstáculo
                    if (obstaculos.Contains((nx, ny)))
                        continue;

                    // Verifica se já foi visitado
                    if (visitados.Contains((nx, ny)))
                        continue;

                    fila.Enqueue((nx, ny));
                    visitados.Add((nx, ny));
                }
            }
            return false;
        }

        private static void AdicionarInimigo(int alvo)
        {
            Random rand = new Random();
            int x, y;

            // Gera posições válidas (à direita dos jogadores)
            do
            {
                x = rand.Next(20, 70);
                y = rand.Next(15, 45);
            } while (
                obstaculos.Contains((x, y)) ||
                inimigos.Any(i => i.x == x && i.y == y) ||
                (alvo == 0 && !PosicaoProxima(jogador1X, jogador1Y, x, y, 30)) ||
                (alvo == 1 && !PosicaoProxima(jogador2X, jogador2Y, x, y, 30))
            );

            inimigos.Add((x, y, alvo));
        }


        private static void ExecutarNivel()
        {
            // Configurações iniciais do nível
            Console.Clear();
            Console.CursorVisible = false;
            bool nivelConcluido = false;

            while (!nivelConcluido && jogoAtivo)
            {
                // Limpa apenas a área de jogo para evitar rastros
                Console.SetCursorPosition(9, 11);
                for (int y = 11; y < 52; y++)
                {
                    Console.SetCursorPosition(9, y);
                    Console.Write(new string(' ', 71));
                }

                // Exibe informações dos jogadores
                ExibirCabecalho();

                // Desenha elementos do jogo
                DesenharObstaculos();
                DesenharJogadores();
                DesenharInimigos();
                DesenharSaida();

                // Processa input dos jogadores
                ProcessarInput();

                // Move inimigos periodicamente
                MoverInimigos();

                // Adiciona novos inimigos
                AdicionarNovosInimigos();

                // Verifica condições de término
                nivelConcluido = VerificarChegadaSaidaJuntos();
                if (VerificarColisaoInimigos())
                {
                    Console.Beep();
                    RegistrarPontuacao();
                    FinalizarJogo();
                    return;
                }

                if (VerificarChegadaSaidaSeparado())
                {
                    Console.Beep();
                    RegistrarPontuacao();
                    VencerJogo();
                    return;
                }

                // Controla velocidade do loop
                System.Threading.Thread.Sleep(50);
            }
        }

        private static void ExibirCabecalho()
        {
            // Jogador 1 (azul à esquerda)
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            Console.Write($"{nome1}: {pontuacao1}".PadRight(20));

            // Jogador 2 (verde à direita)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(60, 0);
            Console.Write($"{nome2}: {pontuacao2}".PadLeft(20));

            // Exibe recorde na linha 51
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                Console.SetCursorPosition(0, 52);
            }
            catch(Exception e) { Console.WriteLine($"{e}"); }
            
            Console.Write("Recorde: " + LerRecorde().PadRight(Console.WindowWidth - 9));
        }

        private static void DesenharObstaculos()
        {
            // Define cor baseada no nível
            Console.ForegroundColor = coresFases[(nivel - 1) % coresFases.Length];

            foreach (var (x, y) in obstaculos)
            {
                Console.SetCursorPosition(x, y);
                Console.Write('O');
            }
        }

        private static void DesenharJogadores()
        {
            // Jogador 1 (azul)
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(jogador1X, jogador1Y);
            Console.Write('*');

            // Jogador 2 (verde)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(jogador2X, jogador2Y);
            Console.Write('*');
        }

        private static void DesenharInimigos()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var (x, y, _) in inimigos)
            {
                Console.SetCursorPosition(x, y);
                Console.Write('#');
            }
        }

        private static void DesenharSaida()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 30); //28, 32
            Console.Write("S");
        }

        private static void ProcessarInput()
        {
            if (Console.KeyAvailable)
            {
                var tecla = Console.ReadKey(true).Key;
                int novoX1 = jogador1X, novoY1 = jogador1Y;
                int novoX2 = jogador2X, novoY2 = jogador2Y;

                // Movimento do jogador 1 (WASD)
                novoX1 = jogador1X;
                novoY1 = jogador1Y;

                switch (tecla)
                {
                    case ConsoleKey.W: novoY1--;
                        pontuacao1++; break;
                    case ConsoleKey.S: novoY1++;
                        pontuacao1++; break;
                    case ConsoleKey.A: novoX1--;
                        pontuacao1++; break;
                    case ConsoleKey.D: novoX1++;
                        pontuacao1++; break;
                }

                if (MovimentoValido1(novoX1, novoY1))
                {
                    jogador1X = novoX1;
                    jogador1Y = novoY1;
                }

                // Movimento do jogador 2 (Teclado numérico)
                novoX2 = jogador2X;
                novoY2 = jogador2Y;

                switch (tecla)
                {
                    case ConsoleKey.NumPad8: novoY2--; 
                        pontuacao2++; break;
                    case ConsoleKey.NumPad2: novoY2++;
                        pontuacao2++; break;
                    case ConsoleKey.NumPad4: novoX2--;
                        pontuacao2++; break;
                    case ConsoleKey.NumPad6: novoX2++; 
                        pontuacao2++; break;
                }

                if (MovimentoValido2(novoX2, novoY2))
                {
                    jogador2X = novoX2;
                    jogador2Y = novoY2;
                }
            }
        }

        private static bool MovimentoValidoNPC(int x, int y)
        {
            // Verifica se está dentro dos limites válidos
            return x > 8 && x < 80 && y > 10 && y < 50 &&
                   !obstaculos.Contains((x, y)) &&
                   !inimigos.Any(i => i.x == x && i.y == y);
        }

        private static bool MovimentoValido1(int x1, int y1)
        {
            // Verifica se está dentro dos limites válidos
            return x1 > 8 && x1 < 80 && y1 > 10 && y1 < 50 &&
                   !obstaculos.Contains((x1, y1)) &&
                   !inimigos.Any(i => i.x == x1 && i.y == y1);
        }

        private static bool MovimentoValido2(int x2, int y2)
        {
            // Verifica se está dentro dos limites válidos
            return x2 > 8 && x2 < 80 && y2 > 10 && y2 < 50 &&
                   !obstaculos.Contains((x2, y2)) &&
                   !inimigos.Any(i => i.x == x2 && i.y == y2);
        }

        private static void MoverInimigos()
        {
            // Move a cada 1 segundo
            if ((DateTime.Now - ultimoMovInimigos).TotalMilliseconds < (500 - (50 * nivel)))
                return;

            ultimoMovInimigos = DateTime.Now;

            // Cria nova lista para atualizar posições
            var novosInimigos = new List<(int x, int y, int direcao)>();

            foreach (var (x, y, alvo) in inimigos)
            {
                int novoX = x, novoY = y;
                int alvoX = alvo == 0 ? jogador1X : jogador2X;
                int alvoY = alvo == 0 ? jogador1Y : jogador2Y;

                // Movimento em direção ao alvo
                if (Math.Abs(alvoX - x) > Math.Abs(alvoY - y))
                {
                    novoX += (alvoX > x) ? 1 : -1;
                }
                else
                {
                    novoY += (alvoY > y) ? 1 : -1;
                }

                // Verifica movimento válido
                if ((x!=32 || x!= 28) && y!=75) {

                    if (MovimentoValidoNPC(novoX, novoY))
                    {
                        novosInimigos.Add((novoX, novoY, alvo));
                    }
                    else
                    {
                        // Mantém posição anterior se inválido
                        novosInimigos.Add((x, y, alvo));
                    }
                }
                
            }

            inimigos = novosInimigos;
        }

        private static void AdicionarNovosInimigos()
        {
            // Adiciona a cada (10 - nível) segundos
            int intervalo = Math.Max(1, 8 - (2 * nivel));
            if ((DateTime.Now - ultimoNovoInimigo).TotalSeconds < intervalo)
                return;

            ultimoNovoInimigo = DateTime.Now;
            AdicionarInimigo(0);
            AdicionarInimigo(1);
        }

        private static bool VerificarChegadaSaidaJuntos()
        {
            // Verifica se ambos chegaram na região da saída
            jogador1Chegou = (jogador1X == 75 && jogador1Y == 30);

            jogador2Chegou = (jogador2X == 75 && jogador2Y == 30);

            return (jogador1Chegou && jogador2Chegou);



        }

        private static bool VerificarChegadaSaidaSeparado()
        {
            // Verifica se ambos chegaram na região da saída
            jogador1Chegou = (jogador1X == 75 && jogador1Y == 30);

            jogador2Chegou = (jogador2X == 75 && jogador2Y == 30);

            return ((!jogador1Chegou && jogador2Chegou) || (jogador1Chegou && !jogador2Chegou));



        }

        private static bool VerificarColisaoInimigos()
        {
            // Verifica colisão para ambos os jogadores
            return inimigos.Any(i => (i.x == jogador1X && i.y == jogador1Y)) ||
                   inimigos.Any(i => (i.x == jogador2X && i.y == jogador2Y));
        }

        private static void AvancarNivel()
        {
            // Atualiza pontuações
            pontuacao1 += 20;
            pontuacao2 += 20;

            // Mostra mensagem de conclusão
            Console.Clear();
            Console.WriteLine($"Fase {nivel} concluída!");
            Console.WriteLine($"{nome1}: {pontuacao1} pontos");
            Console.WriteLine($"{nome2}: {pontuacao2} pontos");
            Console.WriteLine("\nPressione Enter para próxima fase...");

            // Incrementa nível e reinicia posições
            nivel++;
            jogador1X = 14; jogador1Y = 20;
            jogador2X = 14; jogador2Y = 40;

            // Aguarda confirmação
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }

        private static void RegistrarPontuacao()
        {
            // Determina vencedor
            string vencedor = pontuacao1 > pontuacao2 ? nome1 : nome2;
            int pontuacaoVencedor = Math.Max(pontuacao1, pontuacao2);

            // Cria registro
            string registro = $"{vencedor} - {pontuacaoVencedor} pontos em {DateTime.Now:dd/MM/yyyy HH:mm}";

            // Salva em arquivo
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                "MagoRicardoGameJam2025",
                "PontosMR.txt"
            );

            Directory.CreateDirectory(Path.GetDirectoryName(caminho));
            File.AppendAllText(caminho, registro + Environment.NewLine);
        }

        public static string LerRecorde()
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

                // Lê todas as linhas e retorna a última
                return File.ReadAllLines(caminho).LastOrDefault() ?? "Sem registros";
            }
            catch
            {
                return "Erro ao ler recorde";
            }
        }

        private static void FinalizarJogo()
        {
            // Pisca personagem atingido
            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                DesenharJogadores();
                System.Threading.Thread.Sleep(250);
            }

            // Mostra mensagem final
            Console.Clear();
            bool jogador1Venceu = pontuacao1 > pontuacao2;

            Console.WriteLine("FIM DE JOGO!");
            Console.WriteLine($"Jogador atingido: {(jogador1Venceu ? nome2 : nome1)}");
            Console.WriteLine($"Vencedor: {(jogador1Venceu ? nome1 : nome2)}");
            Console.WriteLine($"Pontuação final: {pontuacao1} x {pontuacao2}");
            Console.WriteLine("\nPressione Enter para voltar ao menu");
            Console.WriteLine("Pressione Esc para sair");

            // Processa escolha final
            while (true)
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.Enter)
                {
                    jogoAtivo = false;
                    return;
                }
                if (tecla == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }

        private static void VencerJogo()
        {
            // Pisca personagem atingido
            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                DesenharJogadores();
                System.Threading.Thread.Sleep(250);
            }

            // Mostra mensagem final
            Console.Clear();
            jogadorVencedor = jogador1Chegou ? nome1 : nome2;

            Console.WriteLine("FIM DE JOGO!");
            Console.WriteLine($"\nVencedor: {jogadorVencedor}");
            Console.WriteLine($"\nPontuação final: {nome1}:{pontuacao1} x {nome2}:{pontuacao2}");
            Console.WriteLine("\nPressione Enter para voltar ao menu");
            Console.WriteLine("Pressione Esc para sair");

            // Processa escolha final
            while (true)
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.Enter)
                {
                    jogoAtivo = false;
                    return;
                }
                if (tecla == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}