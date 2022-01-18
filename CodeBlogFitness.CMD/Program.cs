using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

Console.WriteLine("Вас приветствует приложение Fitness.");

Console.WriteLine("Введите имя пользователя.");
var name = Console.ReadLine();

var userController = new UserController(name);
var eatingController = new EatingController(userController.CurrentUser);
var exerciseController = new ExerciseController(userController.CurrentUser);

if (userController.IsNewUser)
{
    Console.WriteLine("Введите пол.");
    var gender = Console.ReadLine();

    var birthDate = ParseDateTime("дата рождения");
    var weight = ParseDouble("вес");
    var height = ParseDouble("рост"); 

    userController.SetNewUserData(gender, birthDate, weight, height);
}

Console.WriteLine(userController.CurrentUser);

while (true)
{
    Console.WriteLine("Что вы хотите сделать?");
    Console.WriteLine("Е - ввести прием пищи");
    Console.WriteLine("A - ввести упражнение");
    Console.WriteLine("Q - выход");
    var key = Console.ReadKey();
    Console.WriteLine();


    switch (key.Key)
    {
        case ConsoleKey.E:
            var foods = EnterEating();
            eatingController.Add(foods.Food, foods.Weight);

            foreach (var item in eatingController.Eating.Foods)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
            break;

        case ConsoleKey.A:
            var exe = EnterExercise();

            exerciseController.Add(exe.activity, exe.begin, exe.end);

            foreach (var item in exerciseController.Exercises)
            {
                Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} по {item.Finish.ToShortTimeString()}");
            }
            break;

        case ConsoleKey.Q:
            Environment.Exit(0);
            break;
    }

    Console.ReadKey();
}

static (DateTime begin, DateTime end, Activity activity) EnterExercise()
{
    Console.WriteLine("Введите название упражнения.");
    var name = Console.ReadLine();

    var energy = ParseDouble("расход энергии в минуту");

    var begin = ParseDateTime("начало упражнения");
    var end = ParseDateTime("окончание упражнения");

    var activity = new Activity(name, energy);
    return (begin, end, activity);
}

static DateTime ParseDateTime(string value)
{
    DateTime birthDate;
    while (true)
    {
        Console.WriteLine($"Введите {value} (дд.мм.гггг).");
        if (DateTime.TryParse(Console.ReadLine(), out birthDate))
        {
            break;
        }
        else
        {
            Console.WriteLine($"Неверный формат {value}.");
        }
    }

    return birthDate;
}

static double ParseDouble(string name)
{
    while (true)
    {
        Console.WriteLine($"Введите {name}.");
        if (double.TryParse(Console.ReadLine(), out double value))
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Неверный формат поля {name}.");
        }
    }
}

static (Food Food, double Weight) EnterEating()
{
    Console.WriteLine("Введите название продукта");
    var food = Console.ReadLine();

    var calories = ParseDouble("калорийность");
    var proteins = ParseDouble("белки");
    var fats = ParseDouble("жиры");
    var carbs = ParseDouble("углеводы");
    var weight = ParseDouble("вес порции");

    var product = new Food(food, calories, proteins, fats, carbs);

    return (Food: product, Weight: weight);
}