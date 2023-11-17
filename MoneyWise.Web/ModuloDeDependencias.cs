using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Repositorios.Usuarios;
using MoneyWise.Infra.Database.Contexto;
using MoneyWise.Infra.Usuarios;
using MoneyWise.Servico.Autenticacao;
using MoneyWise.Servico.Usuarios;

namespace MoneyWise.Web
{
    public class ModuloDeDependencias
    {
        public static void BindServices(IServiceCollection services)
        {
            services.AddScoped<DbContext, SqlServerContexto>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ServicoUsuario, ServicoUsuario>();

            services.AddScoped<ServicoAutenticacao, ServicoAutenticacao>();
        }
    }
}
