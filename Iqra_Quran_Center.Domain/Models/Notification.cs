using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        public Guid? GroupId { get; set; } = null;
    }
}
