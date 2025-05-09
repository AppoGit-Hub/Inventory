using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.BCE.CSV;

public class Enterprise
{
    public string EntrepriseNumber { get; set; }
    public string? Status { get; set; }
    public int? JuridicalSituation { get; set; }
    public int? TypeOfEntreprise { get; set; }
    public int? JuridicalForm { get; set; }
    public int? JuridicalFormCAC { get; set; }
    public DateTime? StartDate { get; set; }

}