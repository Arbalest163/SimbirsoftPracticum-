using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public class Human
    {
        public Human(int id, string name, string lastName, string patronimic, DateTime birthday)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Patronimic = patronimic ?? throw new ArgumentNullException(nameof(patronimic));
            Birthday = birthday;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Patronimic { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

    }
}
