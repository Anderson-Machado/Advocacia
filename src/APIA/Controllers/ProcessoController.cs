using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIA.Data;
using APIA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIA.Controllers
{

  [Route("api/[controller]")]
  public class ProcessoController : Controller
  {
    ApplicationDbContext db = new ApplicationDbContext();
    /// <summary>
    ///metodo para criar um novo processo para a empresa
    /// </summary>
    /// <param name="processo"></param>
    /// <returns></returns>
    [HttpPost("CreateProcesso")]
    public object CreateProcesso([FromBody]Processo processo)
    {
      try
      {

        db.Processos.Add(processo);
        db.SaveChanges();
        return Ok(new { text = "Processo cadastrado com sucesso!", type = true });
      }
      catch (Exception ex)
      {
        return Ok(new { text = ex.Message, type = false });
      }
    }

    /// <summary>
    /// Calcular a soma dos processos ativos. A aplicação deve retornar R$ 1.087.000,00
    /// Utilizado no dashbord do front end
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetProcessosAtivo")]
    public object GetProcessosAtivo()
    {
      var ativo = db.Processos.Where(x => x.IsAtivo == true).Sum(x => x.Valor);
      return Json(ativo);
    }

    /// <summary>
    ///  Calcular a a média do valor dos processos no Rio de Janeiro para o Cliente "Empresa A". A aplicação deve retornar R$ 110.000,00
    ///  Utilizado no dashboard
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetMedia")]
    public object GetMedia()
    {
      var media = db.Processos.Where(x => x.IdEmpresa == 1).Average(x => x.Valor);
     if(media!=null)
      return Json(media);
      return Ok();
    }

    /// <summary>
    /// Calcular o Número de processos com valor acima de R$ 100.000,00. A aplicação deve retornar 2.
    /// Utilizado no dashboard
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetCalculoNumeroDeProcesso")]
    public object GetCalculoNumeroDeProcesso()
    {
      var qtd = db.Processos.Where(x => x.Valor > 100000).ToList();
      return Json(qtd);
    }

    /// <summary>
    /// Obter a lista de Processos de Setembro de 2007. A aplicação deve retornar uma lista com somente o Processo “00010TRABAM”.
    /// Sera exibido no dashboard
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetListProcessosMaior")]
    public object GetListProcessosMaior()
    {
      var listProcesso = db.Processos.Where(x => x.DataInicio.Month == 9 && x.DataInicio.Year == 2007).ToList();
      return Json(listProcesso);
    }
    [HttpGet("getListProcessosNomesmoEstado")]
    public object getListProcessosNomesmoEstado(){
      var retval = from s in db.Empresas
                   join sa in db.Processos on s.Estado equals sa.Estado
                   select sa;
      return Json(retval);
    }

    /// <summary>
    /// Obter a lista de processos que contenham a sigla “TRAB”. A aplicação deve retornar uma lista com os processos “00003TRABMG” e “00010TRABAM”
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetProcessTrab")]
    public object GetProcessTrab(){
      var trab = db.Processos.Where(x => x.NumeroProcesso.Contains("TRAB"));
      return Json(trab.ToList());
    }


  }
}