using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Form
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// Relaciones
        public ICollection<RolFormPermission> RolFormPermissions { get; set; } = new List<RolFormPermission>(); /// PNI - Relacion uno a muchos
        public ICollection<FormModule> FormModules { get; set; } = new List<FormModule>(); /// PNI -  Relacion uno a muchos
       

    }
}
