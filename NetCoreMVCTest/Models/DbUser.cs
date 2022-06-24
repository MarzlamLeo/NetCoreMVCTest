using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCTest.Models
{
    public class DbUser
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string UserName { get; set; }
        [MaxLength(10)]
        public string Password { get; set; }
        [MaxLength(10)]
        public string Remark { get; set; }

        [Required]
        public int Order { get; set; }

        public List<DbRole> Roles { get; set; }
      

    }
}
