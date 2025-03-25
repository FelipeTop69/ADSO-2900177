using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public int BranchId { get; set; }
        public int BranchName { get; set; }
    }
}
