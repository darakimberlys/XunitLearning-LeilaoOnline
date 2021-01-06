using System;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTest
    {
        [Fact]
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
            Assert.Equal(valorEsperado, valorObtido);

        }

        [Fact]
        private static void Leilao_With_One_Lance()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 1000);

            //Act - Método sob test
            leilao.TerminaPregao();

            //Assert - [Parte a ser Automatizada]
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
