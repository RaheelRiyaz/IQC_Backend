using Iqra_Quran_Center.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ResetCode { get; set; } 
        public DateTime? ResetCodeExpiration { get; set; }
        public UserRole UserRole { get; set; }
        public Guid? GroupId { get; set; }





        #region Navigational Properties
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = null!;
        #endregion Navigational Properties
    }
}
