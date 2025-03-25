using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class RolFormPermissionDTO
    {
        public int Id { get; set; }
        public RolDTO Role { get; set; }
        public PermissionDTO Permission { get; set; }
        public FormDTO Form { get; set; }
    }
}
