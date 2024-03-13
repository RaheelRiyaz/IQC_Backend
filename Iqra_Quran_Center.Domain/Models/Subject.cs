using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; } = null!;
        public bool IsAvailable { get; set; } = true;
    }
}
