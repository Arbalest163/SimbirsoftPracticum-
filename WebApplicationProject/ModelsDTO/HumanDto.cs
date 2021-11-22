using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    /// <summary>
    /// 1.2.1 Клас человек DTO
    /// </summary>
    public class HumanDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Patronimic { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
