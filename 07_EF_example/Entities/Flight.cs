using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _07_EF_example.Entities
{
    class Flight
    {
        [Key]//set primary key
        public int Number { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        public int? Rating { get; set; }
        /////Relationship type : one to many
        ///Foreign key namig : RelatingEntityName + RelatingEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        //Navigation Properties
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
