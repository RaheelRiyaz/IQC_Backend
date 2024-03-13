using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class Group : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Batch { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
