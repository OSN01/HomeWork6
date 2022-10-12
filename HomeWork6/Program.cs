using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Нажмите '1' чтобы откыть список сотрудников. Нажимите '2' чтобы добавить сотрудника\n" +
                    "Нажмите любую кнопку, чтобы закрыть программу.\n");
                char key = Console.ReadKey(true).KeyChar;
                if (key == '1')
                {
                    WorkerList();
                }
                else if (key == '2')
                {
                    AddWorker();
                }
                else return;
            }
        }
        static void WorkerList()
        {
            if (File.Exists(@"D:\WorkerList.txt"))
            {
                ReadWorker();
                
            } else
            {
                Console.WriteLine("Файл не существует. Создать файл? д/н");
                char key = Console.ReadKey(true).KeyChar;
                if (char.ToLower(key) == 'д')
                {
                    AddWorker();
                }
            }

        }
        static void AddWorker()
        {
            using (StreamWriter workerStream = new StreamWriter(@"D:\WorkerList.txt", true))
            {
                char key = 'д';
                int id = 0;

                do
                {
                    Console.Clear();
                    DateTime now = new DateTime();
                    now = DateTime.Now;

                    id++; //номер записи

                    Console.Write("Введите Ф.И.О. сотрудника: ");
                    string name = Console.ReadLine();

                    Console.Write("Введите дату рождения сотрудника в формате dd/mm/yyyy: ");
                    DateTime bDate;
                    while (true) // проверка даты
                    {
                        string bDay = Console.ReadLine();
                        
                        if (DateTime.TryParse(bDay, out bDate))
                        {
                            bDate = DateTime.Parse(bDay);
                            break;
                        }
                        else
                        {
                            Console.Write("Неверный ввод. Введите дату рождения сотрудника в формате dd/mm/yyyy: ");
                        }
                    }

                    int age = now.Year - bDate.Year; //возраст сотрудника

                    Console.Write("Введите рост сотрудника в сантиметрах: ");
                    int height;
                    while (!int.TryParse(Console.ReadLine(), out height)) //проверка введеного роста
                    {
                        Console.Write("Неверный ввод. Введите рост сотрудника в сантиметрах: ");
                    }

                    Console.Write("Введите город рождения: ");
                    string city = Console.ReadLine();

                    workerStream.WriteLine($"{id}#{now.ToString()}#{name}#{age}#{height}#{bDate.ToShortDateString()}#город {city}");
                    Console.WriteLine("\nСотрудник добавлен. Добавить нового сотрудника? д/н"); key = Console.ReadKey(true).KeyChar;

                } while (char.ToLower(key) == 'д');
            }
        }
        static void ReadWorker()
        {
            using (StreamReader wlreader = new StreamReader(@"D:\WorkerList.txt"))
            {
                string line;
                while ((line = wlreader.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"{data[0]} {data[1]} {data[2]} {data[3]} {data[4]} {data[5]} {data[6]}");
                }
            }
            Console.WriteLine("\nНажмите любую кнопку чтобы вернуться в меню.");
            Console.ReadKey();
        }
    }
}
