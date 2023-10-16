using MoneyWise.Dominio.Entidades;
using MoneyWise.Infra.Database.Contexto;
using MoneyWise.Infra.Usuarios;
using Moq.EntityFrameworkCore;

namespace MoneyWise.Test.Unitario.Usuarios
{
    [Collection("Coleção de Testes do Repositório Usuário")]
    public class Testes_Do_Repositorio_Usuario
    {
        [Fact]
        public void Adicionar_deve_retornar_usuario()
        {
            // Arrange
            var contexto = new Mock<SqlServerContexto>();
            contexto.Setup(x => x.Set<Usuario>())
                .ReturnsDbSet(TestDataHelper.ObterListaUsuarios());

            var repositorio = new UsuarioRepositorio(contexto.Object);
            var usuario = TestDataHelper.ObterUsuario();

            // Act
            var usuarioId = repositorio.Adicionar(usuario).Id;

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal(usuario.Id, usuarioId);
        }

        [Fact]
        public void Atualizar_deve_retornar_usuario()
        {
            // Arrange
            var contexto = new Mock<SqlServerContexto>();
            contexto.Setup(x => x.Set<Usuario>())
                .ReturnsDbSet(TestDataHelper.ObterListaUsuarios());

            var repositorio = new UsuarioRepositorio(contexto.Object);
            var usuario = TestDataHelper.ObterUsuario();

            // Act
            var usuarioId = repositorio.Atualizar(usuario).Id;

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal(usuario.Id, usuarioId);
        }

        [Fact]
        public void ObterPorId_deve_retornar_um_usuario()
        {
            // Arrange
            var listaUsuarios = TestDataHelper.ObterListaUsuarios();

            var contexto = new Mock<SqlServerContexto>();
            contexto.Setup(x => x.Set<Usuario>())
                .ReturnsDbSet(listaUsuarios);

            var repositorio = new UsuarioRepositorio(contexto.Object);

            // Act
            var usuario = repositorio.ObterPorId(listaUsuarios.First().Id);

            // Asserts
            Assert.NotNull(usuario);
            Assert.Equal(listaUsuarios.First().Id, usuario.Id);
        }

        [Fact]
        public void ObterPorId_com_id_vazio_deve_gerar_excecao()
        {
            const string ID_VAZIO = "Informe o ID do registro.";

            // Arrange
            var listaUsuarios = TestDataHelper.ObterListaUsuarios();

            var contexto = new Mock<SqlServerContexto>();
            contexto.Setup(x => x.Set<Usuario>())
                .ReturnsDbSet(listaUsuarios);

            var repositorio = new UsuarioRepositorio(contexto.Object);

            // Act
            var ex = Assert.Throws<Exception>(() => repositorio.ObterPorId(Guid.Empty));
            
            // Assert
            Assert.Contains(ID_VAZIO, ex.Message);
        }

        [Fact]
        public void ObterTodos_deve_retornar_lista_com_dois_usuarios()
        {
            // Arrange
            var contexto = new Mock<SqlServerContexto>();
            contexto.Setup(x => x.Set<Usuario>())
                .ReturnsDbSet(TestDataHelper.ObterListaUsuarios());

            var repositorio = new UsuarioRepositorio(contexto.Object);

            // Act
            var usuarios = repositorio.ObterTodos();

            // Assert
            Assert.NotNull(usuarios);
            Assert.Equal(2, usuarios.Count());
        }

        [Fact]
        public void Remover_deve_retornar_a_quantidade_de_tuplas_afetadas()
        {
            // Arrange
            var usuarios = TestDataHelper.ObterListaUsuarios();

            var contexto = new Mock<SqlServerContexto>();
            contexto.Setup(x => x.Set<Usuario>())
                .ReturnsDbSet(usuarios);

            contexto.Setup(x => x.SaveChanges())
                .Returns(1);

            var repositorio = new UsuarioRepositorio(contexto.Object);

            // Act
            var quantidade = repositorio.Remover(usuarios.First());

            // Assert
            Assert.Equal(1, quantidade);
        }
    }
}