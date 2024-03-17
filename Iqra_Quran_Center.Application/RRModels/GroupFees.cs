using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
   public record GroupFeeRequest(Guid GroupId,double TotalFee);
   public record UpdateGroupFeeRequest(Guid Id,double TotalFee);
}
