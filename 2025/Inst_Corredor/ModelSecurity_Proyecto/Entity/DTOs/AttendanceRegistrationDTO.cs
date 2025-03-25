using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class AttendanceRegistrationDTO
    {
        public int Id { get; set; }
        public DateTime Hour { get; set; }
        public bool TypeAccess { get; set; }
        public AttendanceDTO Attendance { get; set; } 
        public AccessPointDTO AccessPoints { get; set; } 
    }
}
