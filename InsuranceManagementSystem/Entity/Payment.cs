using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Entity
{
    
        public class Payment
        {
            public int PaymentId { get; set; }
            public DateTime PaymentDate { get; set; }
            public double PaymentAmount { get; set; }
            public Client Client { get; set; }

            public Payment() { }

            public Payment(int paymentId, DateTime paymentDate, double paymentAmount, Client client)
            {
                PaymentId = paymentId;
                PaymentDate = paymentDate;
                PaymentAmount = paymentAmount;
                Client = client;
            }

            public override string ToString()
            {
                return $"PaymentId: {PaymentId}, Amount: {PaymentAmount}, Date: {PaymentDate}";
            }
        }
    }


