using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    public class EatingContoller
    {
        private readonly User user;
        public List<Food> Foods { get; }

        public EatingContoller(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            Foods = GetAllFood();
        }

        private List<Food> GetAllFood()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("foods.dat", FileMode.Append))
            {
                if (formatter.Deserialize(fs) is List<Food> foods)
                { return foods; }
                else
                { return new List<Food>(); }
            }
        }

        private 
    }
}
