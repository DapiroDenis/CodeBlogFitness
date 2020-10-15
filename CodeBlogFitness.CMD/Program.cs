using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Controller;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас привествует приложение CodeBlogFitness");

            Console.WriteLine("Введите ваше имя ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime(); ;
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserDate(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name} ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else Console.WriteLine($"Неверный формат {name}: ");
            }
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения(dd:MM:yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else Console.WriteLine("Неверный формат даты: ");
            }
            return birthDate;
        }
    }
}
