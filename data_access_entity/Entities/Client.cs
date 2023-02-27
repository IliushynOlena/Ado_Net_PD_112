using data_access_entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_EF_example.Entities
{

    public class Client
    {
        //public int Id { get; set; }
        public int CredentialsId { get; set; }//foreign key and primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        //Navigation Properties
        //public ICollection<Flight> Flights { get; set; }
        public ICollection<ClientFligth> ClientFligth { get; set; }
        public Credentials Credentials { get; set; }
    }
}
