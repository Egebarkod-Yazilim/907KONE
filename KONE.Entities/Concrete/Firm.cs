using KONE.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.Entities.Concrete
{
    public class Firm : EntityBase, IEntity
    {
        public string Name { get; set; }

        public ICollection<UserFirmMapping> UserFirmMappings { get; set; }

    }
}
