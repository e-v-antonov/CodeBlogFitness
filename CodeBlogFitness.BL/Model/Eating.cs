using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список принятой пищи.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        /// <summary>
        /// Пользователь, принявший пищу.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Конструктор приема пищи.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Добавление пщии в словарь уже съеденной пищи.
        /// </summary>
        /// <param name="food">Еда.</param>
        /// <param name="weight">Вес еды.</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
