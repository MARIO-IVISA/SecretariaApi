using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Secretaria.Tests.Helper;
using Secretaria.Application.Models;
using Secretaria.Domain.Contracts.Datas;
using Secretaria.Domain.Entities;
using Secretaria.Infrastructure.Repositories;
using System.Collections;
using Microsoft.Extensions.Configuration;
using Secretaria.Api.Settings;

namespace Secretaria.Tests.Unitario
{
    //public class RepositoryTests
    //{

    //    private readonly INoticiaRepository _noticiaRepository;
    //    public RepositoryTests()
    //    {
    //        var servico = new ServiceCollection();
    //        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    //        servico.AddSingleton<IConfiguration>(config);
    //        AppSettings.ConnectionStrings = config.GetConnectionString("SecretariaConnection");

         
    //        servico.AddTransient<INoticiaRepository, NoticiaRepository>();
    //        var provedor = servico.BuildServiceProvider();
    //        _noticiaRepository = provedor.GetService<INoticiaRepository>();
    //    }
      

    //    [Fact]
    //    public async Task<Noticia> CadastrarNoticia()
    //    {
    //        var faker = new Faker("pt_BR");
    //        var model = new Noticia()
    //        {
    //            Titulo = faker.Lorem.Sentence(),
    //        };
   
    //        var noticia = await _noticiaRepository.Inserir(model);
    //        Assert.NotNull(noticia);
    //        return noticia;
    //    }
    //    [Fact]
    //    public async Task Todas_Noticias()
    //    {
    //        ICollection<Noticia> lista = await _noticiaRepository.ListarTudo();

    //        Assert.NotNull(lista);
    //    }
    //    [Fact]
    //    public async Task Noticia_Por_Id()
    //    {
    //        var noticia =  new RepositoryTests().CadastrarNoticia();

    //        Noticia SecretariaPorId = await _noticiaRepository.BuscarPorId(noticia.Id);

    //        Assert.NotNull(SecretariaPorId);
    //    }
    //}
}
