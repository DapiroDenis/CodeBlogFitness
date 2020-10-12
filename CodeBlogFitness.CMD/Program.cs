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

            Console.WriteLine("Введите ваш пол ");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите вашу дату рождения ");
            var birthDate =DateTime.Parse(Console.ReadLine()); // TODO: Переписать

            Console.WriteLine("Введите ваш вес ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите ваш рост ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
