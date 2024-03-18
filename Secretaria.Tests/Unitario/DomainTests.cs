using Bogus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secretaria.Api.Settings;
using Secretaria.Domain.Contracts.Datas;
using Secretaria.Domain.Contracts.Services;
using Secretaria.Domain.Entities;
using Secretaria.Domain.Service;
using Secretaria.Infrastructure.Repositories;

namespace Secretaria.Tests.Unitario
{
    //public class DomainTests
    //{
    //    private readonly INoticiaDomainService _noticiaDomain;
    //    public DomainTests()
    //    {
    //        var servico = new ServiceCollection();
    //        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    //        servico.AddSingleton<IConfiguration>(config);
    //        AppSettings.ConnectionStrings = config.GetConnectionString("SecretariaConnection");

    //        servico.AddTransient<INoticiaDomainService, NoticiaDomainService>();
    //        servico.AddTransient<INoticiaRepository, NoticiaRepository>();
    //        var provedor = servico.BuildServiceProvider();
    //        _noticiaDomain = provedor.GetService<INoticiaDomainService>();
    //    }
       

    //    [Fact]
    //    public async Task<Noticia> Cadastrar_Noticia()
    //    {
    //        var faker = new Faker("pt_BR");
    //        var model = new Noticia()
    //        {
    //            Titulo = faker.Lorem.Sentence(),
    //        };

    //        var noticia = await _noticiaDomain.Inserir(model);
    //        Assert.NotNull(noticia);
    //        return noticia;
    //    }
    //    [Fact]
    //    public async Task Noticia_Por_Id()
    //    {
    //        var faker = new Faker("pt_BR");
    //        var model = new Noticia()
    //        {
    //            Titulo = faker.Lorem.Sentence(),

    //        };

    //        var noticia = await _noticiaDomain.Inserir(model); 

    //        Noticia SecretariaPorId = await _noticiaDomain.BuscarPorId(noticia.Id);

    //        Assert.NotNull(SecretariaPorId);
    //    }
    //    [Fact]
    //    public async Task Todas_Noticias()
    //    {
    //        ICollection<Noticia> lista = await _noticiaDomain.ListarTudo();

    //        Assert.NotNull(lista);
    //    }
    //}
}
