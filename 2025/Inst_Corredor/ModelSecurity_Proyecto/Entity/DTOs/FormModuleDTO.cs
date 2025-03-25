using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class FormModuleDTO
    {
        public int Id { get; set; }
        public FormDTO Form { get; set; }
        public ModuleDTO Module { get; set; }
    }
}
