using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Dtos.ApplicationRole
{
    public class AddOrUpdateRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
