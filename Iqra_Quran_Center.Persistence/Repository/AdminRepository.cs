using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Domain.Models;
using Iqra_Quran_Center.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Persistence.Repository
{
    public class AdminRepository : BaseRepository<User>, IUserRespository
    {
        public AdminRepository(IqraQuranCenterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
