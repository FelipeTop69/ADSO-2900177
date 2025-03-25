using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Entity.DTOs
{
    public class DivisionBranchDTO
    {
        public int Id { get; set; }
        public DivisionDTO Division { get; set; }
        public BranchDTO Branch { get; set; }
    }
}
