using KONE.Entities.Concrete;
using KONE.Shared.Data.Concrete.EntitiesFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.DataAccess.KONE.Repositories
{
    internal class ActivityLogRepository : EfEntityRepositoryBase<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(DbContext context) : base(context)
        {
        }
    }
}
