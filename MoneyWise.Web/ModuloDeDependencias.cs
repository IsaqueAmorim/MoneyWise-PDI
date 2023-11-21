using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Repositorios.ReceitaRepositorio;
using MoneyWise.Dominio.Repositorios.Usuarios;
using MoneyWise.Infra.Database.Contexto;
using MoneyWise.Infra.Receitas;
using MoneyWise.Infra.Usuarios;
using MoneyWise.Servico.Despesas;
using MoneyWise.Servico.Interfaces;
using MoneyWise.Servico.Repositorios;
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
            services.AddScoped<IDespesaRepositorio, DespesaRepositorio>();
            services.AddScoped<IReceitaRepositorio, ReceitaRepositorio>();
            services.AddScoped<ServicoDespesa,ServicoDespesa>();
        }
    }
}
