using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingAPI.Models
{
    public class Tarifa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioHora { get; set; }
    }
}
