using BooksApp.Data;
using BooksApp.Domain;
using System.Linq;
using System;

namespace ConsoleApp
{
    class Program

    {
        private static BooksContext context = new BooksContext();
        static void Main(string[] args)
        {
            char lectura;
            context.Database.EnsureCreated();
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
                        ShowAuthor("Autores registrados");
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

        private static void ShowAuthor(string text)
        {
            var authors = context.Authors.ToList();

            Console.WriteLine($"{text}: Se ha registrado {authors.Count} autores.");
            foreach(var author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }

        private static void DeleteAuthor()
        {
            Console.Write("Proporcione el identificador del autor a eliminar: ");
            int authorId = Convert.ToInt32(Console.ReadLine());
            var author = context.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author != null)
            {
                Console.WriteLine("Datos actuales del autor:");
                Console.WriteLine($"Identificador: {author.Id}");
                Console.WriteLine($"Nombres: {author.FirstName}");
                Console.WriteLine($"Apellidos: {author.LastName}");
                context.Authors.Remove(author);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Lo siento. El autor a eliminar no existe.");
            }
        }

        private static void ModifyAuthor()
        {
            Console.Write("Proporcione el identificador del autor a modificar: ");
            int authorId = Convert.ToInt32(Console.ReadLine());
            var author = context.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author != null)
            {
                Console.WriteLine("Datos actuales del autor:");
                Console.WriteLine($"Identificador: {author.Id}");
                Console.WriteLine($"Nombres: {author.FirstName}");
                Console.WriteLine($"Apellidos: {author.LastName}");
                Console.WriteLine("Nuevos datos.");
                Console.Write("Proporcione el nuevo nombre del autor: ");
                string firstName = Console.ReadLine();
                Console.Write("Proporcione los apellidos del autor: ");
                string lastName = Console.ReadLine();
                author.FirstName = firstName;
                author.LastName = lastName;
                context.Authors.Update(author);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Lo siento. El autor no existe.");
            }
        }
        private static void AddAuthor()
        {
            Console.WriteLine("Agregando un autor.");
            Console.Write("Nombre: ");
            string firstName = Console.ReadLine();
            Console.Write("Apellido: ");
            string lastName = Console.ReadLine();
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };
            context.Authors.Add(author);
            context.SaveChanges();
        }
    }
}
