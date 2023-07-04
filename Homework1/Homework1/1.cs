using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class Task1
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

        struct Person
        {
            public string name;
            public int age;
            public string email;
            public string githubLink;

            public void WriteInfo()
            {
                Console.WriteLine($"ФИО: {name}\n  Возраст: {age}\n  Email: {email}\n  Github: {githubLink}");
            }
        }
    }
}
