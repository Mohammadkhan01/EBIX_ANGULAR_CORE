using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBIX_WEBAPI.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }
        public int Telephone { get; set; }
    }
}