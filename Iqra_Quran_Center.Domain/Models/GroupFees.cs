using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class GroupFees : BaseEntity
    {
        public Guid GroupId { get; set; }
        public double TotalFee { get; set; }




        #region Navigational Properties
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = null!;
        #endregion Navigational Properties
    }
}
