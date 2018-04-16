using System;
using System.Collections;
using System.Linq;

namespace lab3
{
    class Program
    {
        static ArrayList ANSWERS;
        static string THE_NUMBER;
        static void Main(string[] args)
        {
            do
            {
                switch (menuList())
                {
                    case 1:
                        Console.Clear();
                        THE_NUMBER = init(); // задуманное число
                        ANSWERS = new ArrayList();
                        bool THE_END = true;
                        do
                        {
                            print_step();

                            string new_step = step();
                            if (new_step.Length == 0)
                            {
                                Console.Write("Для продолжения игры нажмите любую клавишу...");
                                Console.ReadLine();
                            }
                            else
                                THE_END = test_step(new_step);
                        } while (THE_END);

                        print_step();

                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка!");
                        break;
                }
                Console.WriteLine("\n\nДля продолжения нажмите любую клавишу...");
                Console.ReadLine();
            } while (true);
        }

        static void print_step() // вывод шагов
        {
            Console.Clear();
            Console.WriteLine("Отгадай загаданное число!");
            foreach (object o in ANSWERS) Console.WriteLine(o);
            Console.WriteLine();
        }
        static bool test_step(string step) // проверка шага
        {
            if (String.Compare(THE_NUMBER, step) == 0) // если число угадано
            {
                string result = step + ": 4 быка, 0 коров     Победа!";
                ANSWERS.Add(result);
                return false;
            }
            else
            {
                int number_cows = 0, number_bulls = 0;
                for (int i = 0; i < 4; i++)
                {
                    int index_step = step.IndexOf(step[i]);
                    int index_number = THE_NUMBER.IndexOf(step[i]);
                    if (index_number != -1)
                    {
                        if (index_step == index_number)
                            number_bulls = number_bulls + 1;
                        else
                            number_cows = number_cows + 1;
                    }
                }
                string result_bulls = " быка ", result_cows = " коров     ", result_message = "";

                if (number_bulls == 1) result_bulls = " бык ";
                if (number_cows == 1) result_cows = " корова     ";

                string result = step + ": " + number_bulls + result_bulls + number_cows + result_cows + result_message;
                ANSWERS.Add(result);
            }

            return true;
        }

        static string step() // новый шаг
        {
            Console.Write("Сделать шаг: ");
            string ANSWER = Console.ReadLine();
            // проверка на числа
            int number;
            bool result = Int32.TryParse(ANSWER, out number);
            if (!result)
            {
                Console.WriteLine("Ошибка! Ход состоит из четырёх цифр.");
                return "";
            }
            // проверка на количество чисел
            if (ANSWER.Length > 4 || ANSWER.Length < 4)
            {
                Console.WriteLine("Ошибка! Ход состоит из четырёх цифр.");
                return "";
            }
            // проверка на повторение чисел
            var mas = new int[4];
            for (int i = 0; i < 4; i++)
            {
                mas[i] = (int)Char.GetNumericValue(ANSWER[i]);
            }
            var res = from x in mas
                      group x by x;

            foreach (var group in res)
            {
                if (group.Count() > 1)
                {
                    Console.WriteLine("Ошибка! Цифры не должны повторятья.");
                    return "";
                }
            }

            return ANSWER;
        }


        static string init() // инициализация числа
        {
            string a, B = "";
            int indexOfChar, x;
            var r = new Random();
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    x = r.Next() % 10;
                    a = x.ToString();
                    indexOfChar = B.IndexOf(a);
                } while (indexOfChar != -1);
                B = String.Concat(B, a);
            }
            return B;
        }

        static int menuList() 
        {
            Console.Clear();
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Играть");
            Console.WriteLine("2. Выход");
            Console.Write("Введите команду: ");

            int item;
            string value = Console.ReadLine();
            bool result = Int32.TryParse(value, out item);
            if (result)
                return Convert.ToInt32(value);

            return 0;
        }
    }
}