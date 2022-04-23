using System;
using System.Collections.Generic;

namespace Adventure_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new List<int>                   { 0,     1,   2,     3,   4 ,    5,   6,        7 };
            //new List<int>                   { HP, HP_MAX, MP, MP_MAX, ATK, GOLD, POTION, ELIXIR };
            List<int> jogador = new List<int> { 500, 500, 100, 100, 100, 300, 0, 0 };
            List<string> menuInicial = new List<string> { "1. Visitar loja - Comprar itens para auxiliar a aventura.",
            "2. Dormir - Recupera todos os pontos de vida e pontos de magia",
            "3. Explorar masmorra - Possibilita entrar na masmorra e enfrentar monstros para evoluir seu personagem e conseguir dinheiro."};
            while (true)
            {
                Console.WriteLine("===============================================================================================================");
                foreach (string menu in menuInicial)
                    Console.WriteLine(menu);
                int input = Check_input(Console.ReadLine());
                if (input == -1 || input < 1 || input > 3)
                {
                    Console.WriteLine("Por favor, informe uma opção válida.");
                    continue;
                }
                else if (input == 1)
                    Visitar_loja(jogador);
                else if (input == 2)
                    Dormir(jogador);
                else
                    Explorar_masmorra(jogador);
            }
        }
        static void Dormir(List<int> jogador)
        {
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("Recepcionista: Bem-vindo a nossa taverna aventureiro. Tenha ótimos sonhos");
            Console.WriteLine("Dormindo");
            jogador[0] = jogador[1];
            jogador[2] = jogador[3];
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Recepcionista: Boas Aventuras");
        }
        static void Visitar_loja(List<int> jogador)
        {
            List<string> menuLoja = new List<string> { "1. Poção - Recupera 500 pontos de vida - Preço 100 moedas de ouro",
            "2. Elixir - Recupera 50 pontos de magia - Preço 100 moedas de ouro",
            "3. Voltar ao Menu Inicial"};

            while (true)
            {
                Console.WriteLine("===============================================================================================================");
                Console.WriteLine("Olá, estranho! O que você está comprando?");
                foreach (string menu in menuLoja)
                    Console.WriteLine(menu);
                Console.WriteLine($"Total de Moedas: {jogador[5]}");
                Console.Write("Opção escolhida: ");
                int input = Check_input(Console.ReadLine());
                if (input == -1 || input < 1 || input > 3)
                {
                    Console.WriteLine("Por favor, informe uma opção válida.");
                    continue;
                }
                else if (input == 3)
                    break;
                else
                {
                    Console.WriteLine("Por favor, informe uma quantidade desejada.");
                    int qtd = Check_input(Console.ReadLine());
                    if (qtd <= 0)
                        Console.WriteLine("Por favor, informe uma quantidade positiva.");
                    else
                    {
                        if (jogador[5] >= 100 * qtd)
                        {
                            jogador[5] += -100 * qtd;
                            if (input == 1)
                                jogador[6] += qtd;
                            else
                                jogador[7] += qtd;
                        }
                        else
                            Console.WriteLine("Você não possui ouro suficiente para efetuar a compra.");
                    }
                }
            }
        }
        static void Explorar_masmorra(List<int> jogador)
        {
            List<string> menuMasmorra = new List<string> { "1. Entrar em uma sala de monstro",
            "2. Entrar na sala do chefe",
            "3. Voltar ao Menu Inicial"};
            while (true)
            {
                Console.WriteLine("===============================================================================================================");
                Console.WriteLine("Escolha uma das opções abaixo: ");
                foreach (string menu in menuMasmorra)
                    Console.WriteLine(menu);
                Console.Write("Opção escolhida: ");
                int input = Check_input(Console.ReadLine());
                if (input == -1 || input < 1 || input > 3)
                {
                    Console.WriteLine("Por favor, informe uma opção válida.");
                    continue;
                }
                else if (input == 3)
                    break;
                else
                {
                    if (input == 1)
                        SalaDoMonstro(jogador);
                    else
                        SalaDoChefe(jogador);
                }
            }
        }
        static void SalaDoChefe(List<int> jogador)
        {
            Random random = new Random();
            //new List<int>                 { 0,     1,     2,          3,   4 ,    5,        6,        7 };
            //new List<int>                 { HP, HP_MAX, HP_BONUS, MP_MAX, ATK, GOLD,       POTION, ELIXIR };
            List<int> chefe = new List<int> { 5000, 5000, 100, 0, 250, random.Next(500, 1000), 0, 0 };
            RotinaSala(jogador, chefe, "Monstro");
        }

        static void SalaDoMonstro(List<int> jogador)
        {
            Random random = new Random();
            //new List<int>                  { 0,     1,   2,     3,   4 ,    5,   6,        7 };
            //new List<int>                  { HP, HP_MAX, HP_BONUS, MP_MAX, ATK, GOLD, POTION, ELIXIR };
            List<int> monstro = new List<int> { 500, 500, 10, 0, 100, random.Next(50, 100), 0, 0 };
            RotinaSala(jogador, monstro, "Monstro");
        }
        static void RotinaSala(List<int> jogador, List<int> inimigo, string nomeInimigo)
        {
            List<string> menuCombate = new List<string> { "1. Atacar",
            "2. Disparar energia",
            "3. Usar item"};
            int qtdTurnos = 1;
            while (true)
            {
                Console.WriteLine("===============================================================================================================");
                Console.WriteLine("O que você deseja fazer?");
                foreach (string menu in menuCombate)
                    Console.WriteLine(menu);
                Console.Write("Opção escolhida: ");
                int input = Check_input(Console.ReadLine());
                if (input == -1 || input < 1 || input > 3)
                {
                    Console.WriteLine("Por favor, informe uma opção válida.");
                    continue;
                }
                else if (input == 1)
                    Atacar(jogador, inimigo);
                else if (input == 2)
                {
                    if (Disparar_energia(jogador, inimigo) == -1)
                        continue;
                }
                else if (input == 3)
                {
                    if (jogador[6] == 0 && jogador[7] == 0)
                    {
                        Console.WriteLine("Você não possui itens para utilizar");
                        continue;
                    }
                    Usar_item(jogador);
                }
                if (inimigo[0] > 0)
                    Atacar(inimigo, jogador);
                ResumoRodada(jogador, inimigo, nomeInimigo);
                if (AlguemMorreu(jogador, inimigo, nomeInimigo, qtdTurnos) == 0)
                    break;
                qtdTurnos++;
            }
        }
        static void Atacar(List<int> atacante, List<int> defensor)
        {
            if (defensor[0] > atacante[4])
                defensor[0] -= atacante[4];
            else
                defensor[0] = 0;
        }
        static int Disparar_energia(List<int> atacante, List<int> defensor)
        {
            if (atacante[2] < 50)
                return -1;
            if (defensor[0] > atacante[4] * 2)
                defensor[0] -= atacante[4] * 2;
            else
                defensor[0] = 0;
            atacante[2] -= 50;
            return 0;
        }

        static void Usar_item(List<int> jogador)
        {
            List<string> menuCombate = new List<string> { $"1. Poção ({jogador[6]})",
            $"2. Poção ({jogador[7]})" };
            while (true)
            {
                if (jogador[6] == 0 && jogador[7] == 0)
                {
                    Console.WriteLine("Você não possui itens para utilizar");
                    break;
                }
                Console.WriteLine("===============================================================================================================");
                Console.WriteLine("O que você deseja utilizar?");
                foreach (string menu in menuCombate)
                    Console.WriteLine(menu);
                int input = Check_input(Console.ReadLine());
                if (input == -1 || input < 1 || input > 2)
                {
                    Console.WriteLine("Por favor, informe uma opção válida.");
                    continue;
                }
                else if (input == 1)
                {
                    jogador[6] = -1;
                    break;
                }
                else if (input == 2)
                {
                    jogador[7] = -1;
                    break;
                }
            }
        }

        static void ResumoRodada(List<int> jogador, List<int> inimigo, string nomeInimigo)
        {
            Console.WriteLine("Jogador");
            Console.WriteLine($"Pontos de Vida: {jogador[0]} / {jogador[1]}");
            Console.WriteLine($"Pontos de Magia: {jogador[2]} / {jogador[3]}");
            Console.WriteLine();
            Console.WriteLine($"{nomeInimigo}");
            Console.WriteLine($"Pontos de Vida: {inimigo[0]} / {inimigo[1]}");
            Console.WriteLine();
        }
        static int AlguemMorreu(List<int> jogador, List<int> inimigo, string nomeInimigo, int qtdTurnos)
        {
            if (inimigo[0] <= 0)
            {
                Console.WriteLine($"Parabéns jogador você derrotou o {nomeInimigo} em {qtdTurnos} turnos");
                jogador[1] += inimigo[2];
                jogador[5] += inimigo[5];
                Console.WriteLine($"Vida máxima aumentada para {jogador[1]}");
                Console.WriteLine($"{inimigo[5]} moedas de ouro recebidas");
                Console.WriteLine("Retornando à sala anterior");
                //Explorar_masmorra(jogador);
                return 0;
            }
            else if (jogador[0] <= 0)
            {
                Console.WriteLine($"{nomeInimigo}: HAHAHA! Fraco, muito fraco! Mande mais aventureiros para me entreter mais");
                Console.WriteLine("O jogador foi derrotado e foi encaminhado para a taverna na cidade");
                Dormir(jogador);
                return 0;
            }
            return 1;
        }

        static int Check_input(string value)
        {
            try
            {
                int result = Convert.ToInt32(value);
                return result;
            }
            catch (OverflowException)
            {
                return -1;
            }
            catch (FormatException)
            {
                return -1;
            }
        }
    }
}


