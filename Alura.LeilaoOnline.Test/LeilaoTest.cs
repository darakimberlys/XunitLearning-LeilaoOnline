using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTest
    {
        [Fact]
        public void Leilao_without_lances()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");

            //Act - Método sob test
            leilao.TerminaPregao();

            //Assert - [Parte a ser Automatizada]
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]

        public static void Leilao_With_Various_Lance(double valorEsperado, double[] ofertas)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            var joseph = new Interessada("Joseph", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            //Act - Método sob test
            leilao.TerminaPregao();

            //Assert - [Parte a ser Automatizada]
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}

