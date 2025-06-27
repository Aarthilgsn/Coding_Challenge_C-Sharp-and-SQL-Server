using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Entity
{
   
        public class Policy
        {
            public int PolicyId { get; set; }
            public string PolicyName { get; set; }
            public double PremiumAmount { get; set; }
            public string CoverageDetails { get; set; }

            public Policy() { }

            public Policy(int policyId, string policyName, double premiumAmount, string coverageDetails)
            {
                PolicyId = policyId;
                PolicyName = policyName;
                PremiumAmount = premiumAmount;
                CoverageDetails = coverageDetails;
            }

            public override string ToString()
            {
                return $"PolicyId: {PolicyId}, Name: {PolicyName}, Premium: {PremiumAmount}, Coverage: {CoverageDetails}";
            }
        }
    }


