using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.API3.DTOs.Cliente
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
    }
}

