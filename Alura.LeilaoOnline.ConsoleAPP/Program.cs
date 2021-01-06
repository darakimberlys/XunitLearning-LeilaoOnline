using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleAPP
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Teste Ok!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(
                    $"Teste Falhou! Esperado: {esperado}, Obtido: {obtido}");
            }

            Console.ForegroundColor = cor;
        }
        private static void Leilao_With_Various_Lances()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 950);

            //Act - Método sob test
            leilao.TerminaPregao();

            //Assert - [Parte a ser Automatizada]
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
            
        }

        private static void Leilao_With_One_Lance()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);

            //Act - Método sob test
            leilao.TerminaPregao();

            //Assert - [Parte a ser Automatizada]
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }

        static void Main()
        {
            Leilao_With_Various_Lances();
            Leilao_With_One_Lance();
        }
    }
}
