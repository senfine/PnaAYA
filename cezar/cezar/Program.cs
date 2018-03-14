using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cezar
{
    class Program
    {
        static void Main(string[] args)
        {
            int shiftCounts = 1;
            //число позиций 

            Console.WriteLine("Введите слово,которое нужно зашифровать:");
            string text = Console.ReadLine();//храню слово, которое будем шифровать
            text = text.ToLower();

            Console.WriteLine("Введите ключ:");
            shiftCounts = Convert.ToInt32(Console.ReadLine());

            string cipherText = "";//храню результат шифрования

            //string alphabet = "abcdefghijklmnopqrstuvwxyz";//работаю с английским алфавитом
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";//работаю с русским алфавитом

            int alphabetSize = alphabet.Length; //количество знаков в алфавите

            for (int i = 0; i < text.Length; i++)//цикл перебора букв шифруемого слова
            {
                for (int j = 0; j < alphabetSize; j++)//цикл сравнения каждой бкувы с алфавитом
                {
                    if (text[i] == alphabet[j]) // в случае совпадения создаем темп, где храню номер буквы со сдвигом
                    {
                        int shiftIndex = j + shiftCounts;//номер буквы+сдвиг в темп

                        while (shiftIndex >= alphabetSize)//чтобы темп не уходил за рамки алфавита
                            shiftIndex -= alphabetSize;

                        cipherText += alphabet[shiftIndex];//заношу зашифрованную букву в переменную для ее хранения
                    }
                }

            }

            Console.WriteLine("Зашифрованное слово:");
            Console.WriteLine(cipherText);
            Console.ReadLine();
        }
    }
}