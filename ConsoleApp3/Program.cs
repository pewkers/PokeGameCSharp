using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;  // Please make sure you install this
using Newtonsoft.Json.Linq;
using static System.Console; // Saves typing, ask more if you need.

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Housekeeping should be done here as this function is vital to the functionality of the program.
            var pokemon = GetPokemonById("https://pokeapi.co/api/v2/pokemon/ditto");
            var jo = JObject.Parse(pokemon);
            var id = jo["abilities"].ToString();
            Console.WriteLine(id);
            FileHandler.CreateNewUser();
            Console.Read();

        }

        private static void MainMenu()
        {
            WriteLine("Select an option from below: ");
            WriteLine("=============================");
            WriteLine("1) Create a new save.");
            WriteLine("2) Open an existing save.");
            WriteLine("3) Delete an existing save.");
            WriteLine("=============================" + "\n");
        }

        private static void GameMenu()
        {
            WriteLine("Select an option from below: ");
            WriteLine("================================");
            WriteLine("1) Show existing Pokemon.");
            WriteLine("2) Show PokeDex.");
            WriteLine("3) Show Inventory.");
            WriteLine("4) Go to the PokeMart.");
            WriteLine("5) Go exploring for new Pokemon.");
            WriteLine("================================" + "\n");
        }

        private static string GetPokemonById(string url)
        {
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(new Uri(url)).Result;
            var obj1 = JsonConvert.DeserializeObject(response);;
            return obj1.ToString();
        }
    }
}