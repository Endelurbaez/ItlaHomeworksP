using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tarifa
{
    public int TarifaId { get; set; }  
    public string TipoVehiculo { get; set; } = null!;
    public decimal PrecioHora { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}


