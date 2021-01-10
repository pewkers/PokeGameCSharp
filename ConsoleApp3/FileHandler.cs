using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp3
{
    class FileHandler
    {
        public static object Server { get; private set; }

        public static void CreateNewUser()
        {
            // Instantiates a new user object and prompts the user to enter a username and password.
            User NewPlayer = new User();
            System.Console.Write("Please select a username: ");
            NewPlayer.Username = System.Console.ReadLine();
            System.Console.Write("Please select a password: ");
            NewPlayer.Password = System.Console.ReadLine();

            // Salts, and then hashes the password for storage in JSON file.
            string SaltedPassword = NewPlayer.Password + "Pokemon";
            SaltedPassword = PasswordEnhancer.ComputeSha256Hash(SaltedPassword);
            NewPlayer.Password = SaltedPassword;

            // Converts user object JSON format using NewtonSoft.
            string result = JsonConvert.SerializeObject(NewPlayer);
            string path = @"C:\json\";

            // Checks if the needed directory exists, if not, the directory gets created.
            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
                System.IO.Directory.CreateDirectory(path);

            // Write the JSON file to the file system.
            string file = @"C:\json\NewPlayer.json";
            using (var tw = new StreamWriter(file, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            System.Console.WriteLine("New File Successfully Created!");
        }
    }

    class PasswordEnhancer
    {
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    class User
    {
        public string Username;
        public string Password;
    }
}
