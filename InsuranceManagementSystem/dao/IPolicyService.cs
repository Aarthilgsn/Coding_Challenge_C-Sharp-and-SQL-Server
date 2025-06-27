using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagementSystem.Entity;

namespace InsuranceManagementSystem.dao
{
   

   
        public interface IPolicyService
        {
            bool CreatePolicy(Policy policy);
            Policy GetPolicy(int policyId);
            List<Policy> GetAllPolicies();
            bool UpdatePolicy(Policy policy);
            bool DeletePolicy(int policyId);
        }
    }

