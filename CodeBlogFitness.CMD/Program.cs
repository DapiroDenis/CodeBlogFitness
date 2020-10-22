using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

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
            var eatingController = new EatingContoller(userController.CurrentUser);
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

            Console.WriteLine("Что вы хотите сделать ?");
            Console.WriteLine("E - ввести приём пищи");

            var key = Console.ReadKey();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food,double Weight) EnterEating()
        {
            Console.WriteLine("Введите ключ продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var cards = ParseDouble("углеводы");

            Console.Write("Введите вес порции: ");
            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prots, fats, cards);

            return (Food: product,Weight: weight);
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
