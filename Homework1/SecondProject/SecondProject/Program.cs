using System;

<<<<<<<< HEAD:Homework1/FirstTask/FirstHomework/Program.cs
namespace FirstTask
========
namespace SecondProject
>>>>>>>> dce3dc1cd50939ecab24325bb7b1088b8c096d7d:Homework1/SecondProject/SecondProject/Program.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<<< HEAD:Homework1/FirstTask/FirstHomework/Program.cs

========
>>>>>>>> dce3dc1cd50939ecab24325bb7b1088b8c096d7d:Homework1/SecondProject/SecondProject/Program.cs
            int[] array = new int[] { 2, 13, 14, 1241, 142, 412, 5, 12 };

            Console.Write("Исходный массив: { ");
            WriteArray(array);
            Console.WriteLine("}");

            BubbleSort(array);

            Console.Write("Отсортированный массив: { ");
            WriteArray(array);
            Console.WriteLine("}");

            Console.ReadKey();

        }

        public static void WriteArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
        }

        public static int[] BubbleSort(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] >= array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }
    }
}
