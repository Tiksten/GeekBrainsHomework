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
а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;

б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;


2. 
а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
Требуется подсчитать сумму всех нечетных положительных чисел.
Сами числа и сумму вывести на экран, используя tryParse;

б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
При возникновении ошибки вывести сообщение.
Напишите соответствующую функцию;


3. 
*Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса. Достаточно решить 2 задачи. Все программы сделать в одном решении.

** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
ArgumentException("Знаменатель не может быть равен 0");

Добавить упрощение дробей.
*/
#endregion

namespace Lesson3
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
                        prog.Task3();
                        break;
                    case 4:
                        exit = 1;
                        break;
                }
            }


        }

        int TaskSelector()
        {
            Console.Clear();

            Console.WriteLine("\n\n\n" +
                "1.Complex\n" +

                "2.Сумма всех нечетных положительных чисел\n" +

                "3.Дроби (+ - * /)\n" +

                "4.Exit");


            Console.Write("\nВведите номер задания: ");
            int taskNumber = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            return taskNumber;
        }

        void Task1()
        {
            Complex comp = new Complex();

            Complex a = new Complex();
            Complex b = new Complex();


            Console.WriteLine("Введите 2 комплексных числа:");

            a.Re = Convert.ToDouble(Console.ReadLine());
            a.Im = Convert.ToDouble(Console.ReadLine());

            b.Re = Convert.ToDouble(Console.ReadLine());
            b.Im = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(Convert.ToString(comp.Subtraction(a, b).Re) + " " + Convert.ToString(comp.Subtraction(a, b).Im));
            Console.WriteLine(Convert.ToString(comp.Multiply(a, b).Re) + " " + Convert.ToString(comp.Multiply(a, b).Im));

            Console.ReadLine();
        }

        void Task2()
        {
            string input = "1";
            int number = 0;
            int sum = 0;


            while(input != "0")
            {
                Console.WriteLine("Введите число:(0 чтобы закончить)");
                input = Console.ReadLine();

                bool success = Int32.TryParse(input, out number);


                //Проверяем что введено число, а так же условия для добавления в сумму
                if(success && number > 0 && !(number%2==0))
                {
                    sum = sum + number;
                }

                else if(!success)
                {
                    Console.WriteLine("Это не число!(Нажмите Enter)");
                    Console.ReadLine();
                }

                Console.Clear();
            }

            Console.WriteLine($"Сумма всех введенных положительных нечетных чисел равна: {sum}");
            Console.ReadLine();
        }

        void Task3()
        {
            Fraction fr = new Fraction();

            Console.WriteLine("Введите 2 дробных числа: ");

            var a = Console.ReadLine();
            var b = Console.ReadLine();
            var x = Console.ReadLine();
            var y = Console.ReadLine();

            Fraction fractionA = new Fraction();
            Fraction fractionB = new Fraction();

            fractionA.Num = Convert.ToInt32(a);
            fractionA.Den = Convert.ToInt32(b);

            fractionB.Num = Convert.ToInt32(x);
            fractionB.Den = Convert.ToInt32(y);

            Console.Clear();


            var fractionHolder = fr.Sum(fractionA, fractionB);
            Console.WriteLine(fractionHolder.Num + "/" + fractionHolder.Den);

            fractionHolder = fr.Sub(fractionA, fractionB);
            Console.WriteLine(fractionHolder.Num + "/" + fractionHolder.Den);

            fractionHolder = fr.Multi(fractionA, fractionB);
            Console.WriteLine(fractionHolder.Num + "/" + fractionHolder.Den);

            fractionHolder = fr.Div(fractionA, fractionB);
            Console.WriteLine(fractionHolder.Num + "/" + fractionHolder.Den);

            Console.ReadLine();
        }
    }

    class Complex
    {

        public double Im;
        public double Re;


        public Complex Subtraction(Complex complexA, Complex complexB)
        {
            Complex complexX = new Complex();

            complexX.Re = complexA.Re - complexB.Re;
            complexX.Im = complexA.Im - complexB.Im;

            return complexX;
        }

        public Complex Multiply(Complex complexA, Complex complexB)
        {
            Complex complexX = new Complex();

            complexX.Re = complexA.Re * complexB.Re - complexA.Im * complexB.Im;
            complexX.Im = complexA.Re * complexB.Im + complexA.Im * complexB.Re;

            return complexX;
        }
    }

    class Helper
    {
        public int GCD(int a1, int b1)
        {
            var a = Math.Abs(a1);
            var b = Math.Abs(b1);

            if (a == 0)
            {
                return b;
            }
            else if(b == 1)
            {
                return b;
            }
            else
            {
                var min = Min(a, b);
                var max = Max(a, b);

                return GCD(max - min, min);
            }
        }

        public int Min(int x, int y)
        {
            return x <= y ? x : y;
        }

        public int Max(int x, int y)
        {
            return x >= y ? x : y;
        }
    }

    class Fraction
    {
        Helper hlpr = new Helper();

        //Num числитель
        //---
        //Den знаменатель
        public int Num;
        public int Den;


        public Fraction Sum(Fraction fractionA, Fraction fractionB)
        {
            Fraction fractionX = new Fraction();

            if(fractionA.Den == fractionB.Den)
            {
                fractionX.Num = fractionA.Num + fractionB.Num;
                fractionX.Den = fractionA.Den;
            }
            else
            {
                fractionX.Num = fractionA.Num * fractionB.Den + fractionB.Num * fractionA.Den;
                fractionX.Den = fractionA.Den * fractionB.Den;
            }

            fractionX = Reduction(fractionX);
            return fractionX;
        }

        public Fraction Sub(Fraction fractionA, Fraction fractionB)
        {
            Fraction fractionX = new Fraction();

            if (fractionA.Den == fractionB.Den)
            {
                fractionX.Num = fractionA.Num - fractionB.Num;
                fractionX.Den = fractionA.Den;
            }
            else
            {
                fractionX.Num = fractionA.Num * fractionB.Den - fractionB.Num * fractionA.Den;
                fractionX.Den = fractionA.Den * fractionB.Den;
            }

            fractionX = Reduction(fractionX);
            return fractionX;
        }

        public Fraction Multi(Fraction fractionA, Fraction fractionB)
        {
            Fraction fractionX = new Fraction();

            fractionX.Num = fractionA.Num * fractionB.Num;
            fractionX.Den = fractionA.Den * fractionB.Den;

            fractionX = Reduction(fractionX);
            return fractionX;
        }

        public Fraction Div(Fraction fractionA, Fraction fractionB)
        {
            Fraction fractionX = new Fraction();

            fractionX.Num = fractionA.Num * fractionB.Den;
            fractionX.Den = fractionA.Den * fractionB.Num;

            fractionX = Reduction(fractionX);
            return fractionX;
        }

        public Fraction Reduction(Fraction fraction)
        {
            DenIsZeroException(fraction);

            Fraction fractionX = new Fraction();

            int gcd = hlpr.GCD(fraction.Num, fraction.Den);

            fractionX.Num = fraction.Num / gcd;
            fractionX.Den = fraction.Den / gcd;

            return fractionX;
        }

        public void DenIsZeroException(Fraction fraction)
        {
            if (fraction.Den == 0)
                throw new ArgumentException("Parameter (denominator) cannot be null");
        }
    }
}
