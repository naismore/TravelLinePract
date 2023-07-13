using System;

class Person
{

    private string _name = "undefined";
    private int _age = 0;
    private string _email = "undefined";
    private string _githublink = "undefined";

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                _name = value;
            }
            else
            {
                Console.WriteLine($"ОШИБКА: Входеная строка не должна состоять только из символов разделителей");
            }
        }
    }

    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            if (value > 0 || value < 130)
            {
                _age = value;
            }
            else
            {
                Console.WriteLine("ОШИБКА: Возраст должен быть больше 0, но меньше 130");
            }
        }
    }

    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            if (!String.IsNullOrWhiteSpace(value) && value.Contains("@"))
            {
                _email = value;
            }
            else
            {
                Console.WriteLine("ОШИБКА: Входеная строка должна содержать \"@\" и не состоять только из символов разделителей");
            }
        }
    }

    public string Githublink
    {
        get
        {
            return _githublink;
        }

        set
        {
            if (!String.IsNullOrEmpty(value))
            {
                _githublink = value;
            }
            else
            {
                Console.WriteLine("ОШИБКА: Строка не должна быть пустой");
            }
        }
    }

    public void WriteInfo()
    {
        Console.WriteLine($"ФИО: {_name}\n  Возраст: {_age}\n  Email: {_email}\n  Github: {_githublink}");
    }

}