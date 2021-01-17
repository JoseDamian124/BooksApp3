using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            char lectura;
            
            do
            {
                Console.WriteLine("[A]gregar | [M]odificar autor | [E]liminar autor | [V]er autor | [S]alir ");
                Console.Write("Selecciona una opcion: ");
                lectura = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                switch (lectura)
                {
                    case 'A':
                        AddAuthor();
                        break;

                    case 'M':
                        ModifyAuthor();
                        break;

                    case 'E':
                        DeleteAuthor();
                        break;

                    case 'V':
                        ShowAuthor();
                        break;

                    case 'S':
                        Console.WriteLine("Adios. Programa finalizado");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            } while (lectura != 'S');
            Console.WriteLine("");
        }

        private static void ShowAuthor()
        {
            Console.WriteLine("Mostrando autores...");
        }

        private static void DeleteAuthor()
        {
            Console.WriteLine("Eliminando autor...");
        }

        private static void ModifyAuthor()
        {
            Console.WriteLine("Modificando autor...");
        }

        private static void AddAuthor()
        {
            Console.WriteLine("Agregando un autor...");
        }
    }
}
