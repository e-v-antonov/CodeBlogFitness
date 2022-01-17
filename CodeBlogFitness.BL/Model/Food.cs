using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100г продукта.
        /// </summary>
        public double Callories { get; }

        /// <summary>
        /// Калории за 1г продукта.
        /// </summary>
        private double CalloriesOneGramm { get { return Callories / 100.0; } }
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        private double FatsOneGramm { get { return Fats / 100.0; } }
        private double CarbohydratesOneGramm { get { return Carbohydrates/ 100.0; } }

        public Food(string name) : this(name, 0, 0, 0, 0)
        {
        }

        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название продукта не может быть пустым.", nameof(name));
            }

            if (callories < 0)
            {
                throw new ArgumentNullException("Количество каллорий в продукте не может быть меньше нуля.", nameof(name));
            }

            if (proteins < 0)
            {
                throw new ArgumentNullException("Количество белков в продукте не может быть меньше нуля.", nameof(name));
            }

            if (fats < 0)
            {
                throw new ArgumentNullException("Количество жиров в продукте не может быть меньше нуля.", nameof(name));
            }

            if (carbohydrates < 0)
            {
                throw new ArgumentNullException("Количество углеводов в продукте не может быть меньше нуля.", nameof(name));
            }
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
