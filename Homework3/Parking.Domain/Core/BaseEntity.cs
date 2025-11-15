using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Domain.Core
{
    // Clase base para todas las entidades
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
