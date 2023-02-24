using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _07_EF_example.Entities
{
    public class Flight
    {
        public int Number { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public int? Rating { get; set; }

        public int AirplaneId { get; set; }
        //Navigation Properties
        public Airplane Airplane { get; set; }//Reference
        public ICollection<Client> Clients { get; set; }//Collection

    }
}
