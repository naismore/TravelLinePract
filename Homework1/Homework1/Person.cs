using System;

namespace Homework
{
    internal partial class Task
    {
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
