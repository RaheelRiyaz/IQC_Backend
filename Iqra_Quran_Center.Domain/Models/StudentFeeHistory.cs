using Iqra_Quran_Center.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class StudentFeeHistory : BaseEntity
    {
        public Guid StudentId { get; set; }
        public DateOnly Date { get; set; }
        public double TotalFeeSubmitted { get; set; }
        public PaymentMethod PaymentMethod { get; set; }




        #region Navigational Properties
        [ForeignKey(nameof(StudentId))]
        public User Student { get; set; } = null!;
        #endregion Navigational Properties
    }
}
