

using InsuranceManagementSystem.dao;
using InsuranceManagementSystem.Entity;
using InsuranceManagementSystem.Exceptions;
using InsuranceManagementSystem.util;
using System;
using System.Collections.Generic;

namespace InsuranceManagementSystem.mainmod
{
    public class MainModule
    {
        public static void Start()
        {
            IPolicyService policyService = new PolicyServiceImpl();
            int choice;

            do
            {
                Console.WriteLine("\n========== Insurance Management System ==========");
                Console.WriteLine("1. Create Policy");
                Console.WriteLine("2. Get Policy by ID");
                Console.WriteLine("3. Get All Policies");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                bool valid = int.TryParse(Console.ReadLine(), out choice);
                if (!valid) choice = -1;

                switch (choice)
                {
                    case 1: CreatePolicy(policyService); break;
                    case 2: GetPolicy(policyService); break;
                    case 3: GetAllPolicies(policyService); break;
                    case 4: UpdatePolicy(policyService); break;
                    case 5: DeletePolicy(policyService); break;
                    case 0: Console.WriteLine("Exiting application..."); break;
                    default: Console.WriteLine("Invalid choice! Try again."); break;
                }

            } while (choice != 0);
        }

        static void CreatePolicy(IPolicyService service)
        {
            try
            {
                Console.Write("Enter Policy ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Policy Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Premium Amount: ");
                double premium = double.Parse(Console.ReadLine());

                Console.Write("Enter Coverage Details: ");
                string coverage = Console.ReadLine();

                Policy policy = new Policy(id, name, premium, coverage);
                bool result = service.CreatePolicy(policy);

                Console.WriteLine(result ? "Policy created." : "Creation failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        static void GetPolicy(IPolicyService service)
        {
            try
            {
                Console.Write("Enter Policy ID: ");
                int id = int.Parse(Console.ReadLine());
                Policy policy = service.GetPolicy(id);
                Console.WriteLine(policy);
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        static void GetAllPolicies(IPolicyService service)
        {
            List<Policy> policies = service.GetAllPolicies();
            if (policies.Count == 0)
            {
                Console.WriteLine("No policies found.");
                return;
            }

            foreach (var p in policies)
            {
                Console.WriteLine(p);
            }
        }

        static void UpdatePolicy(IPolicyService service)
        {
            try
            {
                Console.Write("Enter Policy ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter New Policy Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter New Premium Amount: ");
                double premium = double.Parse(Console.ReadLine());

                Console.Write("Enter New Coverage Details: ");
                string coverage = Console.ReadLine();

                Policy updated = new Policy(id, name, premium, coverage);
                bool result = service.UpdatePolicy(updated);

                Console.WriteLine(result ? "Updated successfully." : " Update failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void DeletePolicy(IPolicyService service)
        {
            try
            {
                Console.Write("Enter Policy ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                bool result = service.DeletePolicy(id);
                Console.WriteLine(result ? " Deleted successfully." : "Deletion failed.");
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
