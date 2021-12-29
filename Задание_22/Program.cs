using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_22
{
    //Сформировать массив случайных целых чисел (размер задается пользователем).
    //Вычислить сумму чисел массива и максимальное число в массиве.
    //Реализовать решение задачи с использованием механизма задач продолжения.
    class Program
    {
        public class Array
        {
            const int a = -100;
            const int b = 100;
            int n;
            public int N
            {
                get
                {
                    return n;
                }
                set
                {
                    if (value < 1)
                    {
                        n = 1;
                    }
                    else
                    {
                        n = value;
                    }
                }
            }
            int[] array;
            public Array(int n1)
            {
                N = n1;
                Random random = new Random();
                array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = random.Next(a, b);
                    Console.Write("{0} ", array[i]);
                }
            }
            public void Sum()
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += array[i];
                }
                Console.WriteLine($"Сумма чисел массива: Sum = {sum}");
            }
            public void Max(Task task)
            {
                int max = a;
                for (int i = 0; i < n; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }
                Console.WriteLine($"Максимальное число в массиве: Max = {max}");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите положительное целое число, равное количеству элементов массива целых чисел:");
                int n = Convert.ToInt32(Console.ReadLine());
                Array array = new Array(n);
                Console.WriteLine();
                Action action = new Action(array.Sum);
                Task task1 = new Task(action);
                Action<Task> actionTask = new Action<Task>(array.Max);
                Task task2 = task1.ContinueWith(actionTask);
                task1.Start();
                task2.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Для завершения программы нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
