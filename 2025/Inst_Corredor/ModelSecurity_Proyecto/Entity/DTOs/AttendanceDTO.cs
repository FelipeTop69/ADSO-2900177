using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public CardDTO Card { get; set; } 
        public EventSessionDTO EventSession { get; set; } 
    }
}
