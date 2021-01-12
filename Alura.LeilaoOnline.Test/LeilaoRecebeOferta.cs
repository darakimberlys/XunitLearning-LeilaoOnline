using System.Linq;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {

        [Fact]
        public void Nao_Permite_Novos_Lances_Dado_Leilao_Finalizado()
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(fulano, 900);


            //Act - Método sob test
            leilao.RecebeLance(fulano, 1000);
            leilao.TerminaPregao();

            //Assert - [Parte a ser Automatizada]
            var valorEsperado = 2;
            var valorObtido = leilao.Lances.Count();
            
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}