﻿using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secretaria.Api.Settings;
using Secretaria.Infrastructure.Context;

namespace Secretaria.Tests.Unitario
{
    public class ContextTests
    {
        public ContextTests()
        {
            var servico = new ServiceCollection();

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            servico.AddSingleton<IConfiguration>(config);
            AppSettings.ConnectionStrings = config.GetConnectionString("SecretariaConnection");
        }
        [Fact]
        public async Task TestConexao()
        {
            var contexto = new SqlServerContext();
            bool conectado;
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception e)
            {

                throw new Exception("Não foi dessa vez");
            }
            Assert.True(conectado);
        }
    }
}
