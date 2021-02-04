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
1. Написать метод, возвращающий минимальное из трех чисел.
2. Написать метод подсчета количества цифр числа.
3. С клавиатуры вводятся числа, пока не будет введен 0.
Подсчитать сумму всех нечетных положительных чисел.
4. Реализовать метод проверки логина и пароля. На вход подается логин и пароль.
На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
С помощью цикла do while ограничить ввод пароля тремя попытками.
6. *Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000.
Хорошим называется число, которое делится на сумму своих цифр.
Реализовать подсчет времени выполнения программы, используя структуру DateTime.
*/
#endregion

namespace Lesson2
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


                switch(taskNumber)
                {
                    case 1:
                        prog.Task1();
                        break;
                    case 2:
                        prog.Task2();
                        break;
                    case 3:
                        prog.Task3();
                        break;
                    case 4:
                        prog.Task4();
                        break;
                    case 6:
                        prog.Task6();
                        break;
                    case 7:
                        exit = 1;
                        break;
                }
            }
        }

        int TaskSelector()
        {
            Console.Clear();

            Console.WriteLine("\n\n\n" +
                "1.Минимальное из трех чисел\n" +

                "2.Подсчет количества цифр числа\n" +

                "3.Сумма всех нечетных положительных чисел\n" +

                "4.Логин и пароль\n" +

                "6.«Хорошие» числа в диапазоне от 1 до 1 000 000 000\n" +

                "7.Exit");


            Console.Write("\nВведите номер задания: ");
            int name = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            return name;
        }

        void Task1()
        {
            var hlpr = new Helper();
            Console.Clear();

            Console.Write("\n\nВведите 3 числа:");
            string line = Console.ReadLine();

            List<Int32> numbers = hlpr.IntLineReader(line);

            if (numbers.Count == 0)
                Console.Write("\nЗдесь нет числа!");

            else if (numbers.Count != 3)
                Console.Write("\nНужно ровно ТРИ числа!");

            else
            {
                int a = numbers[0];
                int b = numbers[1];
                int c = numbers[2];

                if (a == b && b == c)
                    Console.Write("\nЧисла равны!");

                else
                {
                    if (a >= b)
                    {

                    }

                    else
                    {
                        a = b;
                    }


                    if (a >= c)
                    {

                    }

                    else
                    {
                        a = c;
                    }
                }

                Console.Write($"\nНаибольшее из чисел: {a}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        void Task2()
        {
            var hlpr = new Helper();

            Console.Write("Введите число:");

            //Получаем список с числом(-ами) из консоли
            var line = hlpr.IntLineReader(Console.ReadLine());

            if (line.Count == 1)
            {
                var inputString = Convert.ToString(line[0]);
                var charCount = inputString.Length;
                Console.Write($"\nКол-во цифр в данном числе = {charCount}");
            }
            else
                Console.Write("\nНужно только одно число");
            Console.ReadLine();
        }

        void Task3()
        {
            int num = 1;
            int totalSum = 0;

            Console.WriteLine("Вводите любые числа, программа посчитает сумму всех нечетных (введите 0 чтобы выйти)");
            Console.ReadLine();

            while(num != 0)
            {
                Console.Clear();
                Console.WriteLine("Введите число (0 чтобы выйти): ");

                num = Convert.ToInt32(Console.ReadLine());
                var remain = num % 2;

                if(remain != 0 && num > 0)
                {
                    totalSum = totalSum + num;
                }
            }

            Console.WriteLine($"Сумма всех нечетных чисел = {totalSum}.");
            Console.ReadLine();
        }

        void Task4()
        {
            string correctLog = "root";
            string correctPassw = "GeekBrains";
            bool inputIsCorrect = false;

            int attemptCount = 3;
            while (!(attemptCount == 0 || inputIsCorrect))
            {
                Console.Clear();
                Console.WriteLine("Введите логин:");
                string log = Console.ReadLine();


                Console.Clear();
                Console.WriteLine("Введите пароль:");
                string passw = Console.ReadLine();


                Console.Clear();

                attemptCount--;

                if ((log == correctLog) && (passw == correctPassw))
                {
                    inputIsCorrect = true;
                    Console.WriteLine("\nЛогин и пароль верны (Нажмите Enter чтобы продолжить)");
                    Console.ReadLine();
                }

                else
                {
                    Console.WriteLine($"\nВведен неверный логин или пароль (Осталось {attemptCount} попыток)");
                    Console.ReadLine();
                }
            }

            if (inputIsCorrect)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n*СЕКРЕТНЫЕ МАЕРИАЛЫ GEEKBRAINS* (Нажмите Enter чтобы продолжить)");
                Console.ReadLine();
            }

        }

        void Task6()
        {
            DateTime date1 = DateTime.Now;

            int i = 1;
            int goodNumCount = 0;

            while(i <= 1000000000)
            {
                int sum = 0;


                foreach(char c in Convert.ToString(i))
                {
                    sum = sum + Convert.ToInt32(c.ToString());
                }

                if ((i) % sum == 0)
                    goodNumCount++;
                i++;
            }
            DateTime date2 = DateTime.Now;
            TimeSpan value = date2.Subtract(date1);

            Console.Clear();

            Console.WriteLine($"Итого {goodNumCount} хороших чисел. Времени на вычисления ушло: {value}");
            Console.ReadLine();
        }
    }
        
    class Helper
    {
        public List<Int32> IntLineReader(string line)
        {
            List<Int32> numbers = new List<Int32>();

            bool hasNumbers = false;
            int num;
            int listNumber = 0;

            numbers.Add(0);


            foreach(char i in line)
            { 
                if(!char.IsNumber(i))
                {
                    if (hasNumbers)
                    {
                        hasNumbers = false;
                        listNumber++;
                        numbers.Add(0);
                    }  
                }

                else
                {
                    num = Convert.ToInt32(Convert.ToString(i));

                    hasNumbers = true;

                    numbers[listNumber] = (numbers[listNumber] * 10) + num;
                }
            }

            if((numbers.Count == 1) && (numbers[0] == 0))
            {
                numbers.Clear();
            }

            return numbers;
        }
    }
}