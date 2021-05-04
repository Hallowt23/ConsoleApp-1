using System;
using System.Collections.Generic;
using System.Text;

namespace Pokecolgado
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                string [] pokemon = { "Ekans", "Pidgeotto", "Moltres", "Nidoking", "Vulpix",
                "Shellder", "Kadabra", "Poliwag", "Growlithe", "Articuno",
                "Hypno", "Koffing", "Pickachu", "Zapdos", "Mew",
                "Seadra", "Scyther", "Omastar", "Dratini", "Jolteon", "Mewtwo",
                "Beedrill", "Sandshrew", "Venasaur", "Eevee", "Squirtle",
                "Bulbasaur", "Kabutops", "Charmander", "Ninetales", "Fearow",
                "Weedle", "Metapod", "Wygglypuff", "Wartortle", "Raichu"};

                List<char> cList = new List<char>();
                List<char> eList = new List<char>();

                Random random = new Random();
                string pokemonElegido = pokemon[random.Next(0, pokemon.Length)];
                string palabraUpper = pokemonElegido.ToUpper();
                string input;
                String confirmar = "";
                char intento;
                int vidas = 5;
                int puntos = 0;
                int letrasReveladas = 0;
                bool fin = false;
                

                StringBuilder letrasOcultas = new StringBuilder(pokemonElegido.Length);
                for (int i = 0; i < pokemonElegido.Length; i++)
                    letrasOcultas.Append('_');

                Console.WriteLine("/////////////////////");
                Console.WriteLine("El Poke-Colgado");
                Console.WriteLine("");
                Console.WriteLine("Ha aparecido un pokemon salvaje!");
                Console.WriteLine("");
                Console.WriteLine("Para capturarlo debes adivinar su nombre letra por letra");
                Console.WriteLine("");
                Console.WriteLine("Mucha suerte entrenador!");
                Console.WriteLine("");
                Console.WriteLine("-Enter para continuar-");
                Console.WriteLine("/////////////////////");
                Console.ReadLine();
                Console.WriteLine("Quien es este pokemon!?");

                while (!fin && vidas > 0)
                {
                    Console.Write("Escribe una letra: ");

                    input = Console.ReadLine().ToUpper();
                    while (String.IsNullOrEmpty(input))
                    {
                        input = Console.ReadLine().ToUpper();
                    }
                    intento = input[0];

                    if (cList.Contains(intento))
                    {
                        Console.WriteLine("Esta letra ya fue añadida: '{0}'", intento);
                        continue;
                    }
                    else if (eList.Contains(intento))
                    {
                        Console.WriteLine("Recuerda que ya intentaste con: '{0}', y no es parte del nombre.", intento);
                        continue;
                    }

                    if (palabraUpper.Contains(intento))
                    {
                        cList.Add(intento);

                        for (int i = 0; i < pokemonElegido.Length; i++)
                        {
                            if (palabraUpper[i] == intento)
                            {
                                letrasOcultas[i] = pokemonElegido[i];
                                letrasReveladas++;
                                puntos = puntos + 5;
                            }
                        }
                        if (letrasReveladas == pokemonElegido.Length)
                            fin = true;
                    }
                    else
                    {
                        eList.Add(intento);
                        Console.WriteLine("No, la letra '{0}' no exsite en su nombre!", intento);
                        vidas--;
                        puntos = puntos - 10;
                    }
                    Console.WriteLine("/////////////////////");
                    Console.WriteLine("");
                    Console.WriteLine("Tienes las siguientes letras: " + letrasOcultas.ToString());
                    Console.WriteLine("Pokebolas : " + vidas);
                    Console.WriteLine("Puntos : " + puntos);
                    Console.WriteLine("");
                }

                if (fin)
                {
                    Console.WriteLine("Tu pokebola ha acertado!");
                    Console.WriteLine(".");
                    Console.ReadLine();
                    Console.WriteLine(". .");
                    Console.ReadLine();
                    Console.WriteLine(". . .");
                    Console.ReadLine();
                    Console.WriteLine("Haz capturado un '{0}'!", pokemonElegido);
                }
                else
                {
                    Console.WriteLine("Rayos!'{0}' se ha escapado", pokemonElegido);
                }
                Console.ReadLine();
                
                Console.WriteLine("Para volver a jugar escribe Si, en caso contrario, cualquier otro caracter");
                while (String.IsNullOrEmpty(confirmar))
                {
                    confirmar = Console.ReadLine().ToUpper();
                    if (confirmar == "Y" || confirmar == "YES" || confirmar == "S" || confirmar =="SI")
                    {

                    } else if (String.IsNullOrEmpty(confirmar))
                    {
                        Console.WriteLine("Para continuar: Si!");
                        Console.WriteLine("Para salir: Cualquier caracter!");
                        confirmar = Console.ReadLine().ToUpper();
                    } else
                    {
                        Console.WriteLine("@@ Creditos al satan @@");
                        continuar = false;
                    }
                }
            }
        }
    }
}
