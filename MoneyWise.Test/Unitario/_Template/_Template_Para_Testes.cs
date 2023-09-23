namespace MoneyWise.Test.Unitario._Template
{
    [Collection("Coleção de Testes do Template")]
    public class _Template_Para_Testes
    {
        [Fact]
        public void ObterNomeProjeto_deve_retornar_string_MoneyWise()
        {
            const string NOME_PROJETO = "MoneyWise";
            
            // Arrange
            //var entidade = new Mock<>();
            //entidade.Setup<DbSet<>>(x => )

            // Act
            var nome = TestDataHelper.ObterNomeProjeto();

            // Assert
            Assert.Equal(NOME_PROJETO, nome);
        }
    }
}