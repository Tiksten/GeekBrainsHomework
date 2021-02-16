using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

#region Автор
//Пчелинцев Сергей
#endregion

#region Задание
/*
1. Создать программу, которая будет проверять корректность ввода логина.
Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) с использованием регулярных выражений.

2. Разработать класс Message, содержащий следующие статические методы для обработки
текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
Продемонстрируйте работу программы на текстовом файле с вашей программой.

3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
а) с использованием методов C#;
б) *разработав собственный алгоритм.
Например:
badc являются перестановкой abcd.

4. Задача ЕГЭ.
*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран
фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
Достаточно решить 2 задачи. Старайтесь разбивать программы на подпрограммы. Переписывайте в
начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения
задач используйте неизменяемые строки (string)

5. **Написать игру «Верю. Не верю». ***Не успел***
В файле хранятся вопрос и ответ, правда это или нет.
Например: «Шариковую ручку изобрели в древнем Египте», «Да». Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
Список вопросов ищите во вложении или воспользуйтесь интернетом.*/
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
                        prog.Task3();
                        break;
                    case 4:
                        prog.Task4();
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

            Console.WriteLine("Введите логин: ");
            string login = Console.ReadLine();

            Regex regex = new Regex(@"\W");
            Regex num = new Regex(@"^\d");

            if (login.Length < 2 || login.Length > 10)
            {
                Console.WriteLine("Логин должен содержать от 2 до 10 символов!");
            }

            else if (regex.IsMatch(login))
            {
                Console.WriteLine("Логин должен содержать в себе только цифры и буквы!");
            }

            else if(num.IsMatch(login))
            {
                Console.WriteLine("Логин не должен начинаться с цифры");
            }

            else
            {
                Console.WriteLine("Логин подходит!");
            }

            Console.ReadLine();
        }

        void Task2()
        {
            Message mes = new Message();

            Console.WriteLine("Введите строку: ");
            var line = Console.ReadLine();

            var words = mes.LineReader(line);

            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(" ");

            foreach (string word in mes.WordsWithCharCount(words, 5))
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(" ");

            foreach (string word in mes.WithoutWordWithEnding(words, 'a'))
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(" ");

            Console.WriteLine(mes.LongestWord(words));
            Console.WriteLine(" ");

            var maxLength = mes.LongestWord(words).Length;
            foreach (string word in mes.WordsWithCharCount(words, maxLength))
            {
                Console.Write(word + " ");
            }

                Console.ReadLine();
        }

        void Task3()
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();


            var empty = ' ';

            if(line1.Length == line2.Length)
            {
                int count1 = line1.Length;

                while (count1 > 0)
                {
                    int count2 = line1.Length;
                    while (count2 > 0)
                    {
                        if(line1[count1 - 1] == line2[count2 - 1])
                        {
                            line1 = line1.Replace(line1[count1 - 1], empty);
                            line2 = line2.Replace(line2[count2 - 1], empty);
                            count2 = 0;
                        }
                        count2--;
                    }
                    count1--;
                }

                var fullyEquals = true;

                foreach(char i in line1)
                {
                    if(!(i == ' '))
                    {
                        fullyEquals = false;
                    }
                }

                Console.WriteLine($"Данные строки равны: {fullyEquals}");
            }

            else
            {
                Console.WriteLine("Данные строки не равны");
            }

            Console.ReadLine();
        }

        void Task4()
        {
            Message mes = new Message();
            string str = "";
            List <List<string>> list = new List<List<string>>();

            List<string> output = new List<string>();

            while(str != "0")
            {
                Console.WriteLine("Введите данные ученика (0 чтобы закончить): ");
                str = Console.ReadLine();

                if(str != "0")
                    list.Add(mes.LineReader(str));

                Console.Clear();
            }

            foreach(List<string> i in list)
            {
                var start = 1;
                var num = 0;

                while(start < i.Count - 1)
                {
                    start++;
                    num = num + Convert.ToInt32(i[start]);
                }

                num = num / (start - 1);

                i[2] = Convert.ToString(num);
            }
            var a = Convert.ToInt32(list[0][2]);
            var b = Convert.ToInt32(list[1][2]);
            var c = Convert.ToInt32(list[2][2]);

            if (a > c)
                (a, c) = (c, a);

            if (a > b)
                (a, b) = (b, a);

            if (b > c)
                (b, c) = (c, b);

            output.Add(Convert.ToString(a));
            output.Add(Convert.ToString(b));
            output.Add(Convert.ToString(c));

            foreach(List<string> i in list)
            {
                if(Convert.ToInt32(output[2]) > Convert.ToInt32(i[2]) && output[2] != i[2])
                {
                    if (Convert.ToInt32(output[1]) > Convert.ToInt32(i[2]) && output[1] != i[2])
                    {
                        if (Convert.ToInt32(output[0]) > Convert.ToInt32(i[2]) && output[0] != i[2])
                        {
                            output[2] = output[1];
                            output[1] = output[0];
                            output[0] = i[2];
                        }

                        output[2] = output[1];
                        output[1] = i[2];
                    }

                    output[2] = i[2];
                }
            }

            foreach(List<string> i in list)
            {
                if(i[2] == output[0] || i[2] == output[1] || i[2] == output[2])
                {
                    var name = i[0] + i[1];
                    output.Add(name);
                }
            }

            output.RemoveAt(0);
            output.RemoveAt(0);
            output.RemoveAt(0);

            foreach(string name in output)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();



            //Походу где то накосячил, но так и не смог понять где
            //Remove только три раза но убирается больше
            //Немного не хватило времени на данное задание т к приходится долго дебажить

        }
    }

    class Message
    {
        public List<String> LineReader(string line)
        {
            List<String> words = new List<String>();
            int num = 0;
            words.Add("");
            foreach (char i in line)
            {
                if (!(char.IsLetter(i) || char.IsDigit(i)))
                {
                    if (!(words[num] == ""))
                    {
                        words.Add("");
                        num++;
                    }
                }

                else
                {
                    words[num] = words[num] + Convert.ToString(i);
                }
            }

            return words;
        }

        public List<String> WordsWithCharCount(List<String> words, int wordLength)
        {
            List<String> output = new List<string>();

            foreach (string word in words)
            {
                if(word.Length <= wordLength)
                {
                    output.Add(word);
                }
            }

            return output;
        }

        public List<String> WithoutWordWithEnding(List<String> words, char ending)
        {
            List<String> output = new List<string>();

            foreach (string word in words)
            {
                if(!(word[word.Length - 1] == ending))
                {
                    output.Add(word);
                }
            }

            return output;
        }

        public string LongestWord(List<String> words)
        {
            string maxLengthWord = words[0];

            foreach(string word in words)
            {
                if(maxLengthWord.Length < word.Length)
                {
                    maxLengthWord = word;
                }
            }

            return maxLengthWord;
        }
    }
}
