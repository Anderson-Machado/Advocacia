using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIA.Models
{
  public class Empresa
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Cnpj { get; set; }
    public string Estado { get; set; }

  }
}
