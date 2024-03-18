using Bogus;
using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secretaria.Api.Settings;
using Secretaria.Application.Contracts;
using Secretaria.Application.Models;
using Secretaria.Application.Services;
using Secretaria.Domain.Contracts.Datas;
using Secretaria.Domain.Contracts.Services;
using Secretaria.Domain.Entities;
using Secretaria.Domain.Service;
using Secretaria.Infrastructure.Repositories;

namespace Secretaria.Tests.Unitario
{
    //public class ApplicationTests
    //{

    //    private readonly INoticiaApplicationService _noticiaApplication;

    //    public ApplicationTests()
    //    {
    //        var servico = new ServiceCollection();
    //        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    //        servico.AddSingleton<IConfiguration>(config);
    //        AppSettings.ConnectionStrings = config.GetConnectionString("SecretariaConnection");

 
    //        servico.AddTransient<INoticiaDomainService, NoticiaDomainService>();
    //        servico.AddTransient<INoticiaRepository, NoticiaRepository>();
    //        servico.AddTransient<INoticiaApplicationService, NoticiaApplicationService>();;
    //        servico.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    //        var provedor = servico.BuildServiceProvider();

    //        _noticiaApplication = provedor.GetService<INoticiaApplicationService>();
    //    }

    //    [Fact]
    //    public async Task<Noticia> CadastrarNoticia()
    //    {
    //        var faker = new Faker("pt_BR");
    //        var model = new Noticia()
    //        {
    //            Titulo = faker.Lorem.Sentence(),
    //        };

    //        var noticia = await _noticiaApplication.Inserir(model);
    //        Assert.NotNull(noticia);
    //        return noticia;
    //    }
    //    [Fact]
    //    public async Task Todas_Noticias()
    //    {
    //        ICollection<Noticia> lista = await _noticiaApplication.ListarTudo();

    //        Assert.NotNull(lista);
    //    }
    //    [Fact]
    //    public async Task Noticia_Por_Id()
    //    {
    //        var noticia = new RepositoryTests().CadastrarNoticia();

    //        Noticia SecretariaPorId = await _noticiaApplication.BuscarPorId(noticia.Id);

    //        Assert.NotNull(SecretariaPorId);
    //    }
    //}
}
