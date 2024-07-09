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
    public class UserFirmMappingRepository : EfEntityRepositoryBase<UserFirmMapping>, IUserFirmMappingRepository
    {
        public UserFirmMappingRepository(DbContext context) : base(context)
        {
        }
    }
}
