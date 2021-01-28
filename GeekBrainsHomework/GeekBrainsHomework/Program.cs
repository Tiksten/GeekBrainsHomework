using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Автор
//Пчелинцев Сергей
#endregion

#region Задание
/* 
1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.
а) используя склеивание;
б) используя форматированный вывод;
в) *используя вывод со знаком $.

2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах
3.
а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
б) *Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;

4. Написать программу обмена значениями двух переменных.
а) с использованием третьей переменной;
б) *без использования третьей переменной.

5.
а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
б) Сделать задание, только вывод организуйте в центре экрана
в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y)

6. *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause). */
#endregion

namespace GeekBrainsHomework
{
    class Program
    {
        
        int TaskSelector()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n" +
                "1.Анкета\n" +
                "2.Индекс массы тела\n" +
                "3.Метод вычисления расстояния между точками\n" +
                "4.Программа обмена значениями двух переменных\n" +
                "5.Программа, которая выводит на экран имя, фамилию и город проживания\n" +
                "6.Exit");
            Console.Write("Введите номер задания: ");
            int name = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return name;
        }
        Double Distance(float x1, float y1, float x2, float y2)
        {
            Double r = Convert.ToDouble(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
            return r;
        }

        void Anket()
        {
            Console.Write("\n\n\nВведите имя: ");
            var name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            var secName = Console.ReadLine();
            Console.Write("Введите возраст: ");
            var age = Console.ReadLine();
            Console.Write("Введите рост (в см): ");
            var tall = Console.ReadLine();
            Console.Write("Введите вес (в кг): ");
            var weight = Console.ReadLine();
            Console.WriteLine($"Имя:     {name}\nФамилия: {secName}\nВозраст: {age}\nРост:    {tall} см\nВес:     {weight} кг");
            Console.ReadLine();
        }

        void Index()
        {
            //I = m / (h * h)
            Console.Write("\n\n\nВведите рост (в см) (например 174): ");
            var tall = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите вес (в кг): ");
            var weight = Convert.ToSingle(Console.ReadLine());
            //Переводим см в м
            tall = tall / 100;
            var Index = Convert.ToSingle(weight / (tall * tall));
            Console.Write($"Ваш индекс массы тела (ИМТ): {Index}");
            Console.ReadLine();
        }

        void Task3()
        {
            Console.Write("\n\n\nВведите координату x первой точки: ");
            var x1 = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите координату y первой точки: ");
            var y1 = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите координату x второй точки: ");
            var x2 = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите координату y второй точки: ");
            var y2 = Convert.ToSingle(Console.ReadLine());
            var d = Distance(x1, y1, x2, y2);
            Console.WriteLine($"Расстояние между данными точками равно {d}");
            Console.ReadLine();
        }

        void Task4()
        {
            Console.Write("\n\n\nВведите первое число: ");
            var a = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите второе число: ");
            var b = Convert.ToSingle(Console.ReadLine());
            (a, b)=(b, a);
            Console.Write($"{a}, {b}");
            Console.ReadLine();
        }

        void Task5()
        {
            var h = new Helper();
            string str = "___Пчелинцев Сергей г.Москва___";
            h.PrintInCenter(str);
        }

        static void Main(string[] args)
        {
            int exit = 0;
            while (exit == 0)
            {
                var prog = new Program();
                var taskNumber = prog.TaskSelector();
                if (taskNumber == 1)
                {
                    prog.Anket();
                }
                else if (taskNumber == 2)
                {
                    prog.Index();
                }
                else if (taskNumber == 3)
                {
                    prog.Task3();
                }
                else if (taskNumber == 4)
                {
                    prog.Task4();
                }
                else if (taskNumber == 5)
                {
                    prog.Task5();
                }
                else if (taskNumber == 6)
                {
                    exit = 1;
                }
            }
        }
    }
    class Helper
    {
        public string Print(string text, bool waitForInputAfterText, bool clearAtStart)
        {
            if(clearAtStart)
            {
                Console.Clear();
            }
            Console.Write(text);
            if (waitForInputAfterText)
                return Console.ReadLine();
            else
                return null;
        }
        public string PrintAtPos(string text, int left, int top)
        {
            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.Write(text);
            return Console.ReadLine();
        }
        public string PrintInCenter(string text)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.WindowHeight / 2);
            Console.Write(text);
            return Console.ReadLine();
        }
    }
}
