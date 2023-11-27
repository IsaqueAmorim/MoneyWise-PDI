using MoneyWise.Dominio.Entidades;

namespace MoneyWise.Test.Unitario.Receitas
{
    public class Receitas_Controller_Testes
    {
        [Fact]
        public void Receita_Adicionar_Adicionado()
        {
            //ARRANGE
            var receita = new Receita
            {
                Id = new Guid(),
                Titulo = "API Freelancer",
                Descricao = "Consultas de códigos no banco",
                UsuarioId = new Guid(),
                Valor = 400.00,
                DataTrasacao = DateTime.Now
            };

            var controller = new Mock<Contro>

            //ACT


            //ASSERT
        }
    }
}
