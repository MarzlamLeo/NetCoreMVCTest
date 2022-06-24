using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCTest.Models
{
    public class DbRole
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DbUser")]
        public int UserId { get; set; }
        [MaxLength(10)]
        public string RoleName { get; set; }
        public virtual DbUser DbUser { get; set; }
    }
}
