using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace pokemonapi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool conditional;
            do
            {
                
                Console.WriteLine("Input the name of a pokemon and I'll let you know how big they are");
                Console.WriteLine();
                string answer = Console.ReadLine();
                string pokemon = answer.ToLower();
                var pokeURL = $"https://pokeapi.co/api/v2/pokemon/{pokemon}/";
                var pokeClient = new HttpClient();
                var pokeResponse = pokeClient.GetStringAsync(pokeURL).Result;
                var pokeInfo = JObject.Parse(pokeResponse).GetValue("height").ToString();
                var pokePounds = JObject.Parse(pokeResponse).GetValue("weight").ToString();


                int pokeWeight = int.Parse(pokePounds);
                int pokeHeight = int.Parse(pokeInfo);


                if (pokeHeight < 5 && pokeWeight <= 100)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{answer} is {pokeHeight} ft tall and weighs {pokeWeight} pounds! Not a large pokemon");
                    Console.WriteLine();
                }

                if (pokeHeight > 5 && pokeWeight >= 100)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{answer} is {pokeHeight} ft tall and weighs {pokeWeight} pounds! That's a big pokemon!");
                    Console.WriteLine();
                }

                if (pokeHeight > 5 && pokeWeight <= 100)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{answer} is {pokeHeight} ft tall and weighs {pokeWeight} pounds! Small thing but a bit on the hefty side");
                    Console.WriteLine();
                }

                if (pokeHeight < 5 && pokeWeight >= 100)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{answer} is {pokeHeight} ft tall and weighs {pokeWeight} pounds! Lanky pokemon if you ask me ");
                    Console.WriteLine();
                }

                Console.ReadKey();
                Console.WriteLine("Want to check another pokemon? Yes/No");
                Console.WriteLine();

                var check = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (check == "yes")
                {
                    conditional = true;
                }
                if (check == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("You sure? Yes/ No");
                    Console.WriteLine();
                    string option = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    if (option == "yes")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ok- thanks for your time!");
                        Console.WriteLine();
                        return;
                    }

                    if (option == "no")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Cool - let's run it again");
                        Console.WriteLine();
                        conditional = true;
                    }

                    if (check != "yes" && check != "no")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid response - later");
                        Console.WriteLine();
                        return ;
                    }
                }

                 if (check != "yes" && check != "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid response - try again");
                    Console.WriteLine();
                }

            }

            while (conditional = true);

        }
    }







}

