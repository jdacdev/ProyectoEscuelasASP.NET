using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HolaMundoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            // por medio del host accedemos al context antes de poner arriba el servicio
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<EscuelaContext>();

                    context.Database.EnsureCreated();//asegurese de que la base de datos esta creada
                    //... con esto nos aseguramos de que el OnCreatingModel se ejecuto y con ello la siembra de nuestros datos.
                }catch(Exception exc)
                {
                    //escribimos en el Log
                    var logger = services.GetRequiredService<ILogger>();
                    logger.LogError(exc, "ocurrio un error conectando con la BD.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
