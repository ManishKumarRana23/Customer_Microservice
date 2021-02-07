using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Models
{
    public class customerDetails
    {
        
        public int customerId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string dateOfBirth { get; set; }
        public string panNumber { get; set; }
        
        /*
        public int CustId { get; set; }
        public int Name { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string PanNo { get; set; }
        */
    }
}
