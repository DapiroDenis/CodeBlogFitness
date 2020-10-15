using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get;  }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get;  }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории за 100 г продукта    
        /// </summary>
        public double Calorie { get;  }
        private double CalloriesOneGram { get { return Calorie / 100.0; } }
        private double ProteinsOneGram { get { return Proteins / 100.0; } }
        private double FatsOneGram { get { return Fats / 100.0; } }
        private double CarbohydratesOneGram { get { return Carbohydrates / 100.0; } }

        public Food(string name) : this(name, 0,0,0,0)
        {
        }

        public Food(string name, double calorie, double proteins, double fats, double carbohydrates)
        {
            //TODO: Проверка
            Name = name;
            Calorie = calorie;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
