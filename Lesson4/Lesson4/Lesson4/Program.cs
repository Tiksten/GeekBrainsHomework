using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Автор
//Пчелинцев Сергей
#endregion

#region Задания
/*
1. 
Дан целочисленный массив из 20 элементов.
Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
В данной задаче под парой подразумевается два подряд идущих элемента массива.
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.


2. 
а) Дописать класс для работы с одномерным массивом.
Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
Создать свойство Sum, которые возвращают сумму элементов массива,
метод Inverse, меняющий знаки у всех элементов массива,
метод Multi, умножающий каждый элемент массива на определенное число,
свойство MaxCount, возвращающее количество максимальных элементов.
В Main продемонстрировать работу класса.

б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл. ***Не успел***


3. ***Не успел***
Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.
Создайте структуру Account, содержащую Login и Password.


4. ***Не успел***
а) Реализовать класс для работы с двумерным массивом.
Реализовать конструктор, заполняющий массив случайными числами.
Создать методы, которые возвращают сумму всех элементов массива,
сумму всех элементов массива больше заданного,
свойство, возвращающее минимальный элемент массива,
свойство, возвращающее максимальный элемент массива,
метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)

б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
Дополнительные задачи

в) Обработать возможные исключительные ситуации при работе с файлами.*/
#endregion

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;
            while (exit == 0)
            {
                var prog = new Program();
                int taskNumber = prog.TaskSelector();


                switch (taskNumber)
                {
                    case 1:
                        prog.Task1();
                        break;
                    case 2:
                        prog.Task2();
                        break;
                    case 3:
                        exit = 1;
                        break;
                }
            }
        }

        int TaskSelector()
        {
            Console.Clear();

            Console.WriteLine("\n\n\n" +
                "1.Пары элементов\n" +

                "2.ListHelper\n" +

                "3.Exit");


            Console.Write("\nВведите номер задания: ");
            int taskNumber = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            return taskNumber;
        }

        void Task1()
        {
            bool stop = false;
            int totalDuos = 0;
            List<int> numList = new List<int>();

            while(!stop)
            {
                Console.WriteLine("Введите число (0 чтобы закончить ввод чисел): ");
                var num = Convert.ToInt32(Console.ReadLine());

                if (num != 0)
                    numList.Add(num);
                else
                    stop = true;
            }

            while(numList.Count > 1)
            {
                if(Math.Abs(numList[0]) % 3 == 0 || Math.Abs(numList[1]) % 3 == 0)
                {
                    totalDuos++;
                }
                numList.RemoveAt(0);
            }

            Console.WriteLine($"Итого {totalDuos} пар");
            Console.ReadLine();
        }

        void Task2()
        {
            bool stop = false;
            List<int> numList = new List<int>();

            while (!stop)
            {
                Console.WriteLine("Введите число (0 чтобы закончить ввод чисел): ");
                var num = Convert.ToInt32(Console.ReadLine());

                if (num != 0)
                    numList.Add(num);
                else
                    stop = true;
            }

            Console.Clear();
            ListHelper lh = new ListHelper();


            Console.WriteLine(string.Join(",", lh.MaxNumCount(numList)));

            Console.WriteLine(string.Join(",", lh.Multi(5, numList)));

            Console.WriteLine(string.Join(",", lh.SetNumbersInRow(3, lh.Builder(14))));

            Console.WriteLine(string.Join(",", lh.Builder(14)));

            Console.WriteLine((string.Join(",", lh.Inverse(numList))));

            Console.WriteLine((string.Join(",", lh.Sum(numList))));

            Console.ReadLine();
        }
    }

    class ListHelper
    {


        public int MaxNumCount(List<int> list)
        {
            var maxNum = list[0];
            var maxNumCount = 1;

            foreach(int i in list)
            {
                if (i > maxNum)
                {
                    maxNum = i;
                    maxNumCount = 1;
                }

                else if (i == maxNum)
                    maxNumCount++;
            }

            return maxNumCount;
        }

        public List<int> Builder(int length)
        {
            List<int> list = new List<int>();

            while(length > 0)
            {
                list.Add(0);
                length--;
            }

            return list;
        }

        public List<int> SetNumbersInRow(int step, List<int> list)
        {
            var counter = list.Count();
            int num = 1;
            int pos = 0;

            while(counter > 0)
            {
                list[pos] = num;
                num = num + step;
                counter--;
                pos++;
            }

            return list;
        }

        public int Sum(List<int> list)
        {
            var sum = 0;

            foreach(int i in list)
                sum = sum + i;

            return sum;
        }

        public List<int> Inverse(List<int> list)
        {
            var count = list.Count();
            var pos = 0;

            while(pos < count)
            {
                list[pos] = -list[pos];
                pos++;
            }

            return list;
        }

        public List<int> Multi(int numToMulti, List<int> list)
        {
            var count = list.Count();
            var pos = 0;

            while (pos < count)
            {
                list[pos] = numToMulti * list[pos];
                pos++;
            }

            return list;
        }
    }
}
