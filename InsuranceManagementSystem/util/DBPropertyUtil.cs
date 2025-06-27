using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.util
{
    
        public class DBPropertyUtil
        {
            public static Dictionary<string, string> LoadProperties(string filePath)
            {
                Dictionary<string, string> properties = new Dictionary<string, string>();

                try
                {
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine(" Property file not found: " + filePath);
                        return properties;
                    }

                    foreach (var line in File.ReadAllLines(filePath))
                    {
                        if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                        {
                            var tokens = line.Split('=', 2);
                            string key = tokens[0].Trim();
                            string value = tokens[1].Trim();
                            properties[key] = value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading DB properties file: " + ex.Message);
                }

                return properties;
            }

            public static string GetConnectionString(string filePath)
            {
                var props = LoadProperties(filePath);

                if (!props.ContainsKey("server") || !props.ContainsKey("database"))
                {
                    Console.WriteLine("Missing required DB config keys: 'server' or 'database'");
                    return null;
                }

                // Windows Authentication (no username/password)
                return $"Server={props["server"]};Database={props["database"]};Integrated Security=True;TrustServerCertificate=True;";
            }
        }
    }

