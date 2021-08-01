using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class Todo
    {
        [Key]
        public int ID { get; set;}

        [DataType(DataType.Date)]
        public DateTime CreatedDateTime { get; set; }

        public bool CompletedStatus { get; set; }

        [StringLength(300)]
        public string Info { get; set; }

        [DataType(DataType.Date)]
        public DateTime CompletedDateTime { get; set; }

        public int UserID { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
