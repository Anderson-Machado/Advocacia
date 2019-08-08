using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIA.Data;
using APIA.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIA.Controllers
{

  [Route("api/[controller]")]
  public class EmpresaController : Controller
  {
    ApplicationDbContext db = new ApplicationDbContext();
    /// <summary>
    ///metodo para criar uma nova empresa
    /// </summary>
    /// <param name="empresa"></param>
    /// <returns></returns>
    [HttpPost("CreateEmpresa")]
    public object CreateEmpresa([FromBody]Empresa empresa)
    {
      try
      {
        db.Empresas.Add(empresa);
        db.SaveChanges();
        return Ok(new { text = "Centro de custo cadastrado com sucesso!", type = true });
      }
      catch (Exception ex)
      { 
        return Ok(new { text = ex.Message, type = false });
      }
    }
    /// <summary>
    /// Metodo responsavel por todas as empresas cadastradas na base.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllEmpresa")]
    public object GetAllEmpresa()
    {
      var retVal = db.Empresas.ToList().OrderBy(x => x.Nome);
      return Json(retVal);
    }


  }
}