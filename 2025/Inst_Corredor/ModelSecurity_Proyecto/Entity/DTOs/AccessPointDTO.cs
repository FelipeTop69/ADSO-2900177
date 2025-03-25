using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class AccessPointDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ubication { get; set; } 
        public EventDTO Event { get; set; }
    }
}
