using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using APIA.Models;
using System.Collections;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace APIA.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        private readonly ILogger _logger;
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //Tabelas do banco de dados
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Processo> Processos { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())

                    .AddJsonFile("appsettings.Development.json", optional: true)
                    .AddJsonFile("appsettings.Prodution.json", optional: true)
                    .Build();
                var connectionString = configuration.GetConnectionString("BaseIdentity");
               // _logger.LogInformation("STRING-CONEXÃO:", 2);
                optionsBuilder.UseSqlServer(connectionString);
            }
        }



    }
}