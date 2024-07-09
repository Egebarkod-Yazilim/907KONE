using KONE.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Concrete
{
    public class Permission : EntityBase, IEntity
    {
        public string Name { get; set; }
    }
}
