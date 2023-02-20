using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_EF_example.Entities
{
    //Entities
    [Table("Passengers")]
    class Client
    {
        //Primary Key naming : Id/id/ID / EntityName + Id
        public int Id { get; set; }
        [Required]//not null
        [MaxLength(100)]//nvarchar(100)
        [Column("FirstName")]
        public string Name { get; set; }
        [Required, MaxLength(150)]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        //Navigation Properties
        public ICollection<Flight> Flights { get; set; }
    }
}
