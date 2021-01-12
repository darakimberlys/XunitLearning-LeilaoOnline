using System.Linq;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(4, new double[] { 100, 1200, 1400, 1300 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void Nao_Permite_Novos_Lances_Dado_Leilao_Finalizado(int qtdEsperada, double[] ofertas)
        {
            //Arrange - Cenario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            leilao.TerminaPregao();

            //Act - Método sob test
            leilao.RecebeLance(fulano, 1000);

            //Assert - [Parte a ser Automatizada]
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObtida);
        }
    }
}