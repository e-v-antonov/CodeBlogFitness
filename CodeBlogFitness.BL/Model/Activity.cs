using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }   

        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название активности не может быть пустым.", nameof(name));
            }

            if (caloriesPerMinute < 0)
            {
                throw new ArgumentOutOfRangeException("Трата калорий не может быть меньше нуля.", nameof(caloriesPerMinute));
            }
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
