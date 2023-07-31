using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Homework1/SecondTask/SecondTask/Program.cs
namespace SecondTask
========
namespace FirstTask
>>>>>>>> dce3dc1cd50939ecab24325bb7b1088b8c096d7d:Homework1/FirstTask/FirstTask/Program.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Console.Write("Введите Ваше имя: ");
            person.Name = Console.ReadLine();
            Console.Write("Введите Ваш возраст: ");
            try
            {
                person.Age = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("Введите Ваш email: ");
            person.Email = Console.ReadLine();
            Console.Write("Введите ссылку на Ваш GitHub: ");
            person.Githublink = Console.ReadLine();
            Console.WriteLine();
            person.WriteInfo();
            Console.ReadKey();
        }
    }
}
