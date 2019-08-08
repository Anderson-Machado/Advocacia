using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIA.Models
{
  public class Processo
  {
    public int Id { get; set; }
    public string NumeroProcesso { get; set; }
    public bool IsAtivo { get; set; }

    public string Estado { get; set; }

    public decimal Valor { get; set; }

    public DateTime DataInicio { get; set; }

    public int IdEmpresa { get; set; }

  }
}
