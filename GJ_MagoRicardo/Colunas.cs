using System; // Importa o namespace System para usar funcionalidades básicas como Console

namespace MagoRicardo
{
    public class Colunas
    {
        // Variáveis globais para armazenar o estado do jogo
        static int alturaP1 = 1; // Altura atual da coluna do jogador 1 (coluna 5)
        static int alturaP2 = 1; // Altura atual da coluna do jogador 2 (coluna 10)
        static int linhaMare = 20; // Linha atual da maré (começa na linha 20)

        public static void JogarColunas(string[] args)
        {
            Console.Title = "Jogo de Maré"; // Define o título da janela do console

            // Configuração inicial do console
            Console.CursorVisible = false; // Oculta o cursor para melhor visualização
            Console.WindowWidth = 45; // Define largura da janela para 45 colunas
            Console.WindowHeight = 25; // Define altura da janela para 25 linhas

            DesenharCenarioInicial(); // Desenha o cenário inicial do jogo

            // Loop principal do jogo
            while (true)
            {
                if (Console.KeyAvailable) // Verifica se alguma tecla foi pressionada
                {
                    var tecla = Console.ReadKey(true).Key; // Lê a tecla pressionada sem mostrá-la no console

                    // Verifica qual tecla foi pressionada e chama a função correspondente
                    if (tecla == ConsoleKey.D1 || tecla == ConsoleKey.NumPad1)
                    {
                        if (tecla == ConsoleKey.D1) // Tecla 1 do teclado alfanumérico
                            AcrescentarP1(); // Adiciona letra na coluna do jogador 1
                        else if (tecla == ConsoleKey.NumPad1) // Tecla 1 do teclado numérico
                            AcrescentarP2(); // Adiciona letra na coluna do jogador 2
                    }
                    else if (tecla == ConsoleKey.D2 || tecla == ConsoleKey.NumPad2)
                    {
                        if (tecla == ConsoleKey.D2) // Tecla 2 do teclado alfanumérico
                            SabotagemP1(); // Sabota a coluna do jogador 1
                        else if (tecla == ConsoleKey.NumPad2) // Tecla 2 do teclado numérico
                            SabotagemP2(); // Sabota a coluna do jogador 2
                    }
                }

                // Verifica condições de fim de jogo
                if (alturaP1 >= linhaMare - 1 || alturaP2 >= linhaMare - 1)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 10);
                    Console.Write("FIM DE JOGO!");
                    Console.ReadKey();
                    return;
                }

                System.Threading.Thread.Sleep(50); // Pequena pausa para reduzir uso da CPU
            }
        }

        /// <summary>
        /// Desenha o cenário inicial do jogo
        /// </summary>
        static void DesenharCenarioInicial()
        {
            Console.Clear(); // Limpa o console

            // Desenha a linha da maré (subtrai 1 porque as linhas começam em 0)
            Console.SetCursorPosition(1, linhaMare - 1);
            Console.Write(new string('_', 40)); // Desenha 40 underlines

            // Desenha as colunas iniciais dos jogadores
            AtualizarColuna(5, alturaP1); // Coluna do jogador 1 (coluna 5)
            AtualizarColuna(20, alturaP2); // Coluna do jogador 2 (coluna 10)
        }

        /// <summary>
        /// Atualiza a exibição de uma coluna de letras
        /// </summary>
        /// <param name="coluna">Número da coluna (5 ou 10)</param>
        /// <param name="altura">Altura atual da coluna</param>
        static void AtualizarColuna(int coluna, int altura)
        {
            // Limpa a coluna inteira (da linha 1 até a linha 19)
            for (int linha = 1; linha <= 19; linha++)
            {
                Console.SetCursorPosition(coluna, linha);
                Console.Write(' ');
            }

            // Desenha as letras 'H' na coluna, da base até a altura atual
            for (int linha = 19; linha > 19 - altura; linha--)
            {
                Console.SetCursorPosition(coluna, linha);
                Console.Write('H');
            }
        }

        /// <summary>
        /// Aumenta a maré (move a linha de underlines para cima)
        /// </summary>
        static void AumentoDeMare()
        {
            if (linhaMare > 1) // Verifica se a maré não chegou ao topo
            {
                linhaMare--; // Decrementa a linha da maré

                // Apaga a linha antiga
                Console.SetCursorPosition(1, linhaMare);
                Console.Write(new string(' ', 40));

                // Desenha a nova linha
                Console.SetCursorPosition(1, linhaMare - 1);
                Console.Write(new string('_', 40));
            }
        }

        /// <summary>
        /// Acrescenta uma letra na coluna do jogador 1 (coluna 5)
        /// </summary>
        static void AcrescentarP1()
        {
            if (alturaP1 < 19) // Verifica se a coluna não está no máximo
            {
                alturaP1++; // Aumenta a altura da coluna
                AtualizarColuna(5, alturaP1); // Atualiza a exibição
                //AumentoDeMare(); // Aumenta a maré como efeito colateral
            }
        }

        /// <summary>
        /// Acrescenta uma letra na coluna do jogador 2 (coluna 10)
        /// </summary>
        static void AcrescentarP2()
        {
            if (alturaP2 < 19) // Verifica se a coluna não está no máximo
            {
                alturaP2++; // Aumenta a altura da coluna
                AtualizarColuna(20, alturaP2); // Atualiza a exibição
                //AumentoDeMare(); // Aumenta a maré como efeito colateral
            }
        }

        /// <summary>
        /// Sabota a coluna do jogador 2 (remove a letra do topo da coluna 10)
        /// </summary>
        static void SabotagemP1()
        {
            if (alturaP2 > 0) // Verifica se há letras para remover
            {
                alturaP2--; // Reduz a altura da coluna
                AtualizarColuna(210, alturaP2); // Atualiza a exibição
            }
        }

        /// <summary>
        /// Sabota a coluna do jogador 1 (remove a letra do topo da coluna 5)
        /// </summary>
        static void SabotagemP2()
        {
            if (alturaP1 > 0) // Verifica se há letras para remover
            {
                alturaP1--; // Reduz a altura da coluna
                AtualizarColuna(5, alturaP1); // Atualiza a exibição
            }
        }
    }
}