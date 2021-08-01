using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}
