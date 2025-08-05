using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MagoRicardo
{
    class Aquario
    {
        // Constantes para configuração do jogo
        const int BORDA_ESQUERDA = 2; // Coluna inicial da borda
        const int BORDA_DIREITA = 40; // Coluna final da borda
        const int BORDA_TOPO = 2; // Linha superior da borda
        const int BORDA_FUNDO = 20; // Linha inferior da borda
        const int AREA_UTIL_X_MIN = BORDA_ESQUERDA + 1; // Mínimo X jogável
        const int AREA_UTIL_X_MAX = BORDA_DIREITA - 1; // Máximo X jogável
        const int AREA_UTIL_Y_MIN = BORDA_TOPO + 1; // Mínimo Y jogável
        const int AREA_UTIL_Y_MAX = BORDA_FUNDO - 1; // Máximo Y jogável
        const int JOGADOR1_X_INICIAL = 32; // Posição inicial X do jogador 1
        const int JOGADOR1_Y_INICIAL = 10; // Posição inicial Y do jogador 1
        const int JOGADOR2_X_INICIAL = 8; // Posição inicial X do jogador 2
        const int JOGADOR2_Y_INICIAL = 10; // Posição inicial Y do jogador 2
        const int DISTANCIA_MINIMA_INIMIGOS = 5; // Distância mínima para spawn de inimigos
        const int INIMIGOS_INICIAIS_POR_JOGADOR = 3; // Inimigos iniciais por jogador
        const int INTERVALO_MOVIMENTO_INIMIGOS = 500; // 1 segundo em ms
        const int INTERVALO_CRIACAO_INIMIGOS = 2500; // 10 segundos em ms
        const int FRAME_RATE = 100; // Tempo entre frames em ms

        // Cores do console
        const ConsoleColor COR_BORDA = ConsoleColor.Yellow;
        const ConsoleColor COR_JOGADOR1 = ConsoleColor.Green;
        const ConsoleColor COR_JOGADOR2 = ConsoleColor.Blue;
        const ConsoleColor COR_INIMIGO = ConsoleColor.Red;

        // Estrutura para representar um inimigo
        struct Inimigo
        {
            public int X; // Posição X do inimigo
            public int Y; // Posição Y do inimigo
            public int Alvo; // 1=Jogador1, 2=Jogador2
        }

        public static void JogarAquario() // Método principal do jogo
        {
            Console.CursorVisible = false; // Desativa o cursor do console
            Console.Title = "Jogo do Aquário"; // Define título da janela

            // Posições dos jogadores
            int jogador1X = JOGADOR1_X_INICIAL;
            int jogador1Y = JOGADOR1_Y_INICIAL;
            int jogador2X = JOGADOR2_X_INICIAL;
            int jogador2Y = JOGADOR2_Y_INICIAL;

            // Estados dos jogadores
            bool jogador1Vivo = true;
            bool jogador2Vivo = true;

            // Lista de inimigos
            List<Inimigo> inimigos = new List<Inimigo>();

            // Temporizadores
            Stopwatch temporizadorMovimento = new Stopwatch();
            Stopwatch temporizadorCriacao = new Stopwatch();
            temporizadorMovimento.Start(); // Inicia temporizador de movimento
            temporizadorCriacao.Start(); // Inicia temporizador de criação

            // Cria inimigos iniciais
            CriarInimigos(inimigos, jogador1X, jogador1Y, jogador2X, jogador2Y, INIMIGOS_INICIAIS_POR_JOGADOR);

            // Loop principal do jogo
            while (jogador1Vivo && jogador2Vivo)
            {
                // 1. Processamento de entrada do usuário
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true); // Lê tecla sem exibir no console

                    // Movimentação do Jogador 1 (setas)
                    if (tecla.Key == ConsoleKey.UpArrow && jogador1Y > AREA_UTIL_Y_MIN)
                        jogador1Y--;
                    if (tecla.Key == ConsoleKey.DownArrow && jogador1Y < AREA_UTIL_Y_MAX)
                        jogador1Y++;
                    if (tecla.Key == ConsoleKey.LeftArrow && jogador1X > AREA_UTIL_X_MIN)
                        jogador1X--;
                    if (tecla.Key == ConsoleKey.RightArrow && jogador1X < AREA_UTIL_X_MAX)
                        jogador1X++;

                    // Movimentação do Jogador 2 (WASD)
                    if (tecla.Key == ConsoleKey.W && jogador2Y > AREA_UTIL_Y_MIN)
                        jogador2Y--;
                    if (tecla.Key == ConsoleKey.S && jogador2Y < AREA_UTIL_Y_MAX)
                        jogador2Y++;
                    if (tecla.Key == ConsoleKey.A && jogador2X > AREA_UTIL_X_MIN)
                        jogador2X--;
                    if (tecla.Key == ConsoleKey.D && jogador2X < AREA_UTIL_X_MAX)
                        jogador2X++;
                }
                
                // 2. Atualização de estado do jogo

                // Movimenta inimigos a cada segundo
                if (temporizadorMovimento.ElapsedMilliseconds >= INTERVALO_MOVIMENTO_INIMIGOS)
                {
                    MoverInimigos(inimigos, jogador1X, jogador1Y, jogador2X, jogador2Y);
                    temporizadorMovimento.Restart(); // Reinicia o temporizador
                }

                // Adiciona novos inimigos a cada 10 segundos
                if (temporizadorCriacao.ElapsedMilliseconds >= INTERVALO_CRIACAO_INIMIGOS)
                {
                    AdicionarInimigo(inimigos, jogador1X, jogador1Y, 1);
                    AdicionarInimigo(inimigos, jogador2X, jogador2Y, 2);
                    temporizadorCriacao.Restart(); // Reinicia o temporizador
                }

                // 3. Verificação de colisões
                foreach (Inimigo inimigo in inimigos)
                {
                    // Colisão com Jogador 1
                    if (inimigo.X == jogador1X && inimigo.Y == jogador1Y)
                    {
                        jogador1Vivo = false; // Marca jogador como morto
                    }
                    // Colisão com Jogador 2
                    if (inimigo.X == jogador2X && inimigo.Y == jogador2Y)
                    {
                        jogador2Vivo = false; // Marca jogador como morto
                    }
                }

                // 4. Renderização do jogo
                Console.Clear(); // Limpa o console

                DesenharBordas(); // Desenha as bordas do jogo
                DesenharJogador(jogador1X, jogador1Y, COR_JOGADOR1, '*'); // Desenha Jogador 1
                DesenharJogador(jogador2X, jogador2Y, COR_JOGADOR2, '*'); // Desenha Jogador 2
                DesenharInimigos(inimigos); // Desenha todos os inimigos

                // 5. Controle de frame rate
                Thread.Sleep(FRAME_RATE); // Pequena pausa para controle de velocidade
            }

            // 6. Final do jogo
            Console.Clear(); // Limpa o console

            // Determina o vencedor
            if (!jogador1Vivo && !jogador2Vivo)
            {
                Console.WriteLine("Empate! Ambos jogadores foram capturados!");
            }
            else if (!jogador1Vivo)
            {
                Console.WriteLine("Jogador 2 (Azul) venceu!");
            }
            else
            {
                Console.WriteLine("Jogador 1 (Verde) venceu!");
            }
        }

        static void DesenharBordas() // Desenha as bordas do jogo
        {
            Console.ForegroundColor = COR_BORDA; // Define cor da borda

            // Desenha borda superior (linha 2)
            for (int x = BORDA_ESQUERDA; x <= BORDA_DIREITA; x++)
            {
                Console.SetCursorPosition(x, BORDA_TOPO);
                Console.Write('O'); // Caractere da borda
            }

            // Desenha borda inferior (linha 20)
            for (int x = BORDA_ESQUERDA; x <= BORDA_DIREITA; x++)
            {
                Console.SetCursorPosition(x, BORDA_FUNDO);
                Console.Write('O');
            }

            // Desenha borda esquerda (coluna 2)
            for (int y = BORDA_TOPO + 1; y < BORDA_FUNDO; y++)
            {
                Console.SetCursorPosition(BORDA_ESQUERDA, y);
                Console.Write('O');
            }

            // Desenha borda direita (coluna 40)
            for (int y = BORDA_TOPO + 1; y < BORDA_FUNDO; y++)
            {
                Console.SetCursorPosition(BORDA_DIREITA, y);
                Console.Write('O');
            }
        }

        static void DesenharJogador(int x, int y, ConsoleColor cor, char simbolo) // Desenha um jogador
        {
            Console.ForegroundColor = cor; // Define cor do jogador
            Console.SetCursorPosition(x, y); // Posiciona cursor
            Console.Write(simbolo); // Desenha símbolo
        }

        static void DesenharInimigos(List<Inimigo> inimigos) // Desenha todos os inimigos
        {
            Console.ForegroundColor = COR_INIMIGO; // Define cor dos inimigos
            foreach (Inimigo inimigo in inimigos) // Itera por cada inimigo
            {
                Console.SetCursorPosition(inimigo.X, inimigo.Y); // Posiciona cursor
                Console.Write('#'); // Desenha inimigo
            }
        }

        static void CriarInimigos(List<Inimigo> lista, int j1x, int j1y, int j2x, int j2y, int quantidadePorJogador) // Cria inimigos iniciais
        {
            Random rnd = new Random(); // Gerador de números aleatórios

            // Cria inimigos para o Jogador 1
            for (int i = 0; i < quantidadePorJogador; i++)
            {
                AdicionarInimigo(lista, j1x, j1y, 1, rnd);
            }

            // Cria inimigos para o Jogador 2
            for (int i = 0; i < quantidadePorJogador; i++)
            {
                AdicionarInimigo(lista, j2x, j2y, 2, rnd);
            }
        }

        static void AdicionarInimigo(List<Inimigo> lista, int alvoX, int alvoY, int alvo, Random rnd = null) // Adiciona novo inimigo
        {
            if (rnd == null) rnd = new Random(); // Cria gerador se não fornecido

            int novoX, novoY;
            bool posicaoValida;

            // Gera posições até encontrar uma válida
            do
            {
                // Gera posição aleatória na área útil
                novoX = rnd.Next(AREA_UTIL_X_MIN, AREA_UTIL_X_MAX + 1);
                novoY = rnd.Next(AREA_UTIL_Y_MIN, AREA_UTIL_Y_MAX + 1);

                // Calcula distância para o alvo (Manhattan)
                int distancia = Math.Abs(novoX - alvoX) + Math.Abs(novoY - alvoY);

                // Verifica se está na distância mínima
                posicaoValida = (distancia >= DISTANCIA_MINIMA_INIMIGOS);

            } while (!posicaoValida);

            // Adiciona novo inimigo à lista
            lista.Add(new Inimigo { X = novoX, Y = novoY, Alvo = alvo });
        }

        static void MoverInimigos(List<Inimigo> inimigos, int j1x, int j1y, int j2x, int j2y) // Move todos os inimigos
        {
            for (int i = 0; i < inimigos.Count; i++) // Itera por cópia para evitar modificação
            {
                Inimigo inimigo = inimigos[i]; // Copia o inimigo
                int alvoX = (inimigo.Alvo == 1) ? j1x : j2x; // Define alvo X
                int alvoY = (inimigo.Alvo == 1) ? j1y : j2y; // Define alvo Y

                // Calcula diferenças
                int diffX = alvoX - inimigo.X;
                int diffY = alvoY - inimigo.Y;

                // Decide direção (prioridade horizontal)
                if (Math.Abs(diffX) > Math.Abs(diffY))
                {
                    inimigo.X += Math.Sign(diffX); // Move horizontalmente
                }
                else if (diffY != 0)
                {
                    inimigo.Y += Math.Sign(diffY); // Move verticalmente
                }

                // Atualiza posição na lista
                inimigos[i] = inimigo;
            }
        }
    }
}