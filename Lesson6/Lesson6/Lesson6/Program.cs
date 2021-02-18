using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

#region Автор
//Пчелинцев Сергей
#endregion

#region Задание
/*
1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double).
Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).


2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она
возвращает минимум через параметр.


3. Переделать программу «Пример использования коллекций» для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;
д) разработать единый метод подсчета количества студентов по различным параметрам
выбора с помощью делегата и методов предикатов.
*Достаточно решить 2 задачи. Старайтесь разбивать программы на подпрограммы.
*Переписывайте в начало программы условие и свою фамилию. Все программы сделайте в одном решении.*/
#endregion

namespace Lesson5
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
                        prog.Task1();
                        break;
                    case 4:
                        prog.Task1();
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
            Table(new MathFun(MyFuncA), -2, 2, 3);

            Table(new MathFun(MyFuncB), -2, 2, 3);

            Console.ReadLine();
        }

        void Task2()
        {
            var exit = false;

            while (true)
            {
                Console.WriteLine(
                "1.x * x - 50 * x + 10\n" +
                "2.x * x + 500 * x - 5\n" +
                "3.x * (x + x + 8) * x - 5 + x * 3\n" +
                "4.x^3\n" +
                "5.(x + x) * x\n" +
                "6.Exit\n");

                Console.WriteLine("\nВыберите функцию и отрезок к ней: ");

                var chose = Console.ReadLine();
                if (chose == "6")
                    break;
                var a = Convert.ToDouble(Console.ReadLine());
                var b = Convert.ToDouble(Console.ReadLine());


                switch (chose)
                {
                    case "1":
                        SaveFunc(Func1, "data.bin", a, b, 0.5);
                        break;
                    case "2":
                        SaveFunc(Func2, "data.bin", a, b, 0.5);
                        break;
                    case "3":
                        SaveFunc(Func3, "data.bin", a, b, 0.5);
                        break;
                    case "4":
                        SaveFunc(Func4, "data.bin", a, b, 0.5);
                        break;
                    case "5":
                        SaveFunc(Func5, "data.bin", a, b, 0.5);
                        break;
                }

                Console.Clear();
            }

            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();


            var fi1 = new FileInfo("data.bin");
            fi1.Delete();
        }




        //***Task1***

        public delegate double MathFun(double x, double a);

        public static double MyFuncA(double x, double a)
        {
            return a * x * x;
        }

        public static double MyFuncB(double x, double a)
        {
            return a * Math.Sin(x);
        }


        public static void Table(MathFun F, double x, double b, double a)
        {
            Console.WriteLine("----- X ----- Y -----");

            while (x <= b)
            {
                Console.WriteLine(Convert.ToString(a) + " " + Convert.ToString(x) + " " + Convert.ToString(F(x, a)));
                x += 1;
            }

            Console.WriteLine("---------------------");
        }




        //***Task2***

        public delegate double Fun(double x);

        public static double Func1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double Func2(double x)
        {
            return x * x + 500 * x - 5;
        }

        public static double Func3(double x)
        {
            return x * (x + x + 8) * x - 5 + x * 3;
        }

        public static double Func4(double x)
        {
            return x * x * x;
        }

        public static double Func5(double x)
        {
            return (x + x) * x;
        }

        public static void SaveFunc(Fun F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
    }
}