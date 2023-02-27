using _07_EF_example.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access_entity.Entities
{
    public class ClientFligth
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
