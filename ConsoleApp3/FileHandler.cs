using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp3
{
    class FileHandler
    {
        public static void CreateNewUser()
        {
            User NewPlayer = new User();
            NewPlayer.Username = "Pewkers";
            NewPlayer.Password = "cumguzzler123";

            string result = JsonConvert.SerializeObject(NewPlayer);
            string path = @"C:\json\NewPlayer.json";

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            System.Console.WriteLine("New File Successfully Created!");
        }
    }

    class User
    {
        public string Username;
        public string Password;
    }
}
