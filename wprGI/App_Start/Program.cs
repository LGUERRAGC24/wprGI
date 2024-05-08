using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;


 namespace wprGI.App_Start


class Program
{
  public  void Main(string[] args)
    {
        // Crear un proveedor de servicios
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(BuildConfiguration())
            .BuildServiceProvider();

        // Obtener la instancia de IConfiguration desde el proveedor de servicios
        var configuration = serviceProvider.GetService<IConfiguration>();

        // Obtener la cadena de conexión desde IConfiguration
        string connectionString = configuration.GetConnectionString("AzureDatabase");

        // Resto del código...
    }

    private static IConfiguration BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return builder.Build();

    }