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


                ;
                List<char> correctList = new List<char>();
                List<char> incorrectList = new List<char>();

                string[] pokemon = { "Ekans", "Pidgeotto", "Moltres", "Nidoking", "vulpix",
                "Shellder", "Kadabra", "Poliwag", "Growlithe", "Articuno",
                "Hypno", "Koffing", "Pickachu", "Zapdos", "Mew",
                "Seadra", "Scyther", "Omastar", "Dratini", "Jolteon"};

                Random random = new Random();
                string pokemonElegido = pokemon[random.Next(0, pokemon.Length)];
                string palabraUpper = pokemonElegido.ToUpper();
                string input;
                String x= "";
                int vidas = 5, points = 0;
                int letrasReveladas = 0;
                bool end = false;
                char intento;

                StringBuilder hiddenDisplay = new StringBuilder(pokemonElegido.Length);
                for (int i = 0; i < pokemonElegido.Length; i++)
                    hiddenDisplay.Append('_');

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

                while (!end && vidas > 0)
                {
                    Console.Write("Escribe una letra: ");

                    input = Console.ReadLine().ToUpper();
                    while (String.IsNullOrEmpty(input))
                    {
                        input = Console.ReadLine().ToUpper();
                    }
                    intento = input[0];

                    if (correctList.Contains(intento))
                    {
                        Console.WriteLine("Esta letra ya fue añadida: '{0}'", intento);
                        continue;
                    }
                    else if (incorrectList.Contains(intento))
                    {
                        Console.WriteLine("Recuerda que ya intentaste con: '{0}', y no es parte del nombre.", intento);
                        continue;
                    }

                    if (palabraUpper.Contains(intento))
                    {
                        correctList.Add(intento);

                        for (int i = 0; i < pokemonElegido.Length; i++)
                        {
                            if (palabraUpper[i] == intento)
                            {
                                hiddenDisplay[i] = pokemonElegido[i];
                                letrasReveladas++;
                                points = points + 5;
                            }
                        }
                        if (letrasReveladas == pokemonElegido.Length)
                            end = true;
                    }
                    else
                    {
                        incorrectList.Add(intento);
                        Console.WriteLine("No, la letra '{0}' no exsite en su nombre!", intento);
                        vidas--;
                        points = points - 10;
                    }
                    Console.WriteLine("/////////////////////");
                    Console.WriteLine("");
                    Console.WriteLine("Tienes las siguientes letras: " + hiddenDisplay.ToString());
                    Console.WriteLine("Pokebolas : " + vidas);
                    Console.WriteLine("Puntos : " + points);
                    Console.WriteLine("");
                }

                if (end)
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
                while (String.IsNullOrEmpty(x))
                {
                    x = Console.ReadLine().ToUpper();
                    if (x == "Y" || x == "YES" || x == "S" || x =="SI")
                    {

                    } else if (String.IsNullOrEmpty(x))
                    {
                        Console.WriteLine("Para continuar: Si!");
                        Console.WriteLine("Para salir: Cualquier caracter!");
                        x = Console.ReadLine().ToUpper();
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
