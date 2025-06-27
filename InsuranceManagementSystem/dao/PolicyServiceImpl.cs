
using InsuranceManagementSystem.Entity;
using InsuranceManagementSystem.Exceptions;
using InsuranceManagementSystem.util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace InsuranceManagementSystem.dao
{
    public class PolicyServiceImpl : IPolicyService
    {
        public bool CreatePolicy(Policy policy)
        {
            bool isInserted = false;
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "INSERT INTO Policy (PolicyId, PolicyName, PremiumAmount, CoverageDetails) " +
                                   "VALUES (@id, @name, @premium, @coverage)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", policy.PolicyId);
                    cmd.Parameters.AddWithValue("@name", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@premium", policy.PremiumAmount);
                    cmd.Parameters.AddWithValue("@coverage", policy.CoverageDetails);

                    int rows = cmd.ExecuteNonQuery();
                    isInserted = rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CreatePolicy: " + ex.Message);
            }

            return isInserted;
        }

        public Policy GetPolicy(int policyId)
        {
            Policy policy = null;
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Policy WHERE PolicyId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", policyId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        policy = new Policy(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDouble(2),
                            reader.GetString(3)
                        );
                    }
                    else
                    {
                        throw new PolicyNotFoundException($"Policy with ID {policyId} not found.");
                    }
                }
            }
            catch (PolicyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetPolicy: " + ex.Message);
            }

            return policy;
        }

        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Policy";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Policy policy = new Policy(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDouble(2),
                            reader.GetString(3)
                        );
                        policies.Add(policy);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllPolicies: " + ex.Message);
            }

            return policies;
        }

        public bool UpdatePolicy(Policy policy)
        {
            bool isUpdated = false;
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "UPDATE Policy SET PolicyName = @name, PremiumAmount = @premium, " +
                                   "CoverageDetails = @coverage WHERE PolicyId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@premium", policy.PremiumAmount);
                    cmd.Parameters.AddWithValue("@coverage", policy.CoverageDetails);
                    cmd.Parameters.AddWithValue("@id", policy.PolicyId);

                    int rows = cmd.ExecuteNonQuery();
                    isUpdated = rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdatePolicy: " + ex.Message);
            }

            return isUpdated;
        }

        public bool DeletePolicy(int policyId)
        {
            bool isDeleted = false;

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "DELETE FROM Policy WHERE PolicyId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", policyId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new PolicyNotFoundException($"Policy with ID {policyId} does not exist.");
                    }

                    isDeleted = true;
                }
            }
            catch (PolicyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeletePolicy: " + ex.Message);
            }

            return isDeleted;
        }
    }
}
