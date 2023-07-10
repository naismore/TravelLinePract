using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal partial class Task
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Console.Write("Введите Ваше имя: ");
            person.name = Console.ReadLine();
            Console.Write("Введите Ваш возраст: ");
            int.TryParse(Console.ReadLine(), out person.age);
            Console.Write("Введите Ваш email: ");
            person.email = Console.ReadLine();
            Console.Write("Введите ссылку на Ваш GitHub: ");
            person.githubLink = Console.ReadLine();
            Console.WriteLine();
            person.WriteInfo();
            Console.ReadKey();
        }
    }
}
