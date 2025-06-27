using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Exceptions
{
    
   
        public class PolicyNotFoundException : Exception
        {
            public PolicyNotFoundException() : base() { }

            public PolicyNotFoundException(string message) : base(message) { }

            public PolicyNotFoundException(string message, Exception innerException)
                : base(message, innerException) { }
        }
    }


