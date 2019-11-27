using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Switch.CrossCutting.Logging;
using Switch.Domain.Entities;
using Switch.Infra.Data.Context;

namespace SwitchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario1;
            Usuario usuario2;
            Usuario usuario3;
            Usuario usuario4;
            Usuario usuario5;
            Usuario usuario6;
                
            Usuario CriarUsuario(string nome)
            {
                return new Usuario()
                {
                    Nome = "Usuario1", 
                    Sobrenome =  "SobreUsuario",
                    Senha = "ads",
                    Email = "usuario@teste.com",
                    Sexo = Switch.Domain.Enums.SexoEnum.Masculino,
                    UrlFoto = @"c:\temp"
                    
                };
            }

            usuario1 = CriarUsuario("usuario1");
            usuario2 = CriarUsuario("usuario2");
            usuario3 = CriarUsuario("usuario3");
            usuario4 = CriarUsuario("usuario4");
            usuario5 = CriarUsuario("usuario5");
            usuario6 = CriarUsuario("usuario6");

            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(usuario1);
            usuarios.Add(usuario2);
            usuarios.Add(usuario3);
            usuarios.Add(usuario4);
            
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql("Server=localhost;userid=root;password=WSquare2019;database=SwitchDB", m => m.MigrationsAssembly("Switch.Infra.Data"));
            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());
                    dbcontext.Usuarios.AddRange(usuarios);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            
            Console.WriteLine("Ok!");
            Console.ReadKey();

        }
    }
}