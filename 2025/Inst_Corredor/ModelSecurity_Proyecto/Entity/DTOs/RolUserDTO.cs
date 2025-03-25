using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class RolUserDTO
    {
        public int Id { get; set; }
        public RolDTO Role { get; set; }
        public UserDTO User { get; set; }
    }
}
