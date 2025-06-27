using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InsuranceManagementSystem.Entity
{
   
        public class Client
        {
            public int ClientId { get; set; }
            public string ClientName { get; set; }
            public string ContactInfo { get; set; }
            public Policy Policy { get; set; }

            public Client() { }

            public Client(int clientId, string clientName, string contactInfo, Policy policy)
            {
                ClientId = clientId;
                ClientName = clientName;
                ContactInfo = contactInfo;
                Policy = policy;
            }

            public override string ToString()
            {
                return $"ClientId: {ClientId}, Name: {ClientName}, Contact: {ContactInfo}";
            }
        }
    }


