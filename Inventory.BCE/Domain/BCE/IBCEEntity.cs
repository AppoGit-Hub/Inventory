using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.BCE;

public interface IBCEEntity
{
    public string? Id { get; set; }
    public int Version { get; set; }
}
