using Iqra_Quran_Center.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class AppFile : BaseEntity
    {
        public Guid EntityId { get; set; }
        public string FilePath { get; set; } = null!;
        public Module Module { get; set; }
    }
}
