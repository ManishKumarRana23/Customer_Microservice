using CustomerMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMicroservice.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public static List<customerDetails> customers = new List<customerDetails>
        {
             new customerDetails{customerId=1,name="xyz",address="BBSR",dateOfBirth="09-09-1997",panNumber="CGLBP00"},
            new customerDetails{customerId=2,name="SB",address="Dumdum",dateOfBirth="05-09-1997",panNumber="CGLBP002"}
        };
        Uri baseAddress = new Uri("https://localhost:44302/api/Account");
        HttpClient client;
        public CustomerRepository()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        [HttpPost]
        public CustomerCreationStatus createCustomer(customerDetails customer)
        {
            customers.Add(customer);
            string JsonData = JsonConvert.SerializeObject(customer.customerId);
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/createAccount/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                customerAccount createStatus = JsonConvert.DeserializeObject<customerAccount>(responseData);
                var result = new CustomerCreationStatus();
                result.customerId = customer.customerId;
                result.Message = "Success. Current and Savings account also created";
                result.currentAccountId = createStatus.currentAccountId;
                result.savingsAccountId = createStatus.savingsAccountId;
                return result;
            }
            return null;
        }
        [HttpGet]
        public customerDetails getCustomerDetails(int customerId)
        {
            var ob = new customerDetails();
            return customers.Where(c => c.customerId == customerId).FirstOrDefault();  
          //  var x = customers.Find(x => x.customerId == customerId);
           
           // return x;
        }
    }
}
