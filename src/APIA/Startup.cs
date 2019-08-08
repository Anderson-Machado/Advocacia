using APIA.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace APIA
{
  public class Startup
  {

    private readonly ILogger _logger;

    public Startup(IConfiguration configuration, ILogger<Startup> logger)
    {
      Configuration = configuration;
      _logger = logger;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      // Configurando o uso da classe de contexto para
      // acesso às tabelas do ASP.NET Identity Core
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("BaseIdentity")));


      // Ativando a utilização do ASP.NET Identity, a fim de
      // permitir a recuperação de seus objetos via injeção de
      // dependências

      var signingConfigurations = new SigningConfigurations();
      services.AddSingleton(signingConfigurations);



      services.AddAuthentication(authOptions =>
      {
        authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(bearerOptions =>
      {
        var paramsValidation = bearerOptions.TokenValidationParameters;
        paramsValidation.IssuerSigningKey = signingConfigurations.Key;

              // Valida a assinatura de um token recebido
              paramsValidation.ValidateIssuerSigningKey = true;

              // Verifica se um token recebido ainda é válido
              paramsValidation.ValidateLifetime = true;

              // Tempo de tolerância para a expiração de um token (utilizado
              // caso haja problemas de sincronismo de horário entre diferentes
              // computadores envolvidos no processo de comunicação)
              paramsValidation.ClockSkew = TimeSpan.Zero;
      });

      // Ativa o uso do token como forma de autorizar o acesso
      // a recursos deste projeto

      services.AddCors(options =>
      {
        options.AddPolicy("EnableCORS", builder =>
              {
            builder.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials()
                  .Build();
          });
      });
      services.AddMvc();

    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env,
        ILoggerFactory loggerFactory,
        ApplicationDbContext context)
    {

      if (env.IsDevelopment())
      {
        _logger.LogInformation(1, "In Development environment");
        app.UseDeveloperExceptionPage();
      }
      else
        _logger.LogInformation("Oxi");


      var supportedCultures = new[] { new CultureInfo("pt-BR") };

      app.UseRequestLocalization(new RequestLocalizationOptions
      {
        DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
        SupportedCultures = supportedCultures,
        SupportedUICultures = supportedCultures,
      });


      app.UseCors("EnableCORS");
      app.UseMvc();
    }
  }
}