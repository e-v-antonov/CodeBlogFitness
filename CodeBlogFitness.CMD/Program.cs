using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

Console.WriteLine("Вас приветствует приложение Fitness.");

Console.WriteLine("Введите имя пользователя.");
var name = Console.ReadLine();

var userController = new UserController(name);
var eatingController = new EatingController(userController.CurrentUser);

if (userController.IsNewUser)
{
    Console.WriteLine("Введите пол.");
    var gender = Console.ReadLine();

    var birthDate = ParseDateTime();
    var weight = ParseDouble("вес");
    var height = ParseDouble("рост"); 

    userController.SetNewUserData(gender, birthDate, weight, height);
}

Console.WriteLine(userController.CurrentUser);

Console.WriteLine("Что вы хотите сделать?");
Console.WriteLine("Е - ввести прием пищи");
var key = Console.ReadKey();
Console.WriteLine();

if (key.Key == ConsoleKey.E)
{
    var foods = EnterEating();
    eatingController.Add(foods.Food, foods.Weight);

    foreach (var item in eatingController.Eating.Foods)
    {
        Console.WriteLine($"\t{item.Key} - {item.Value}");
    }
}

Console.ReadKey();

static DateTime ParseDateTime()
{
    DateTime birthDate;
    while (true)
    {
        Console.WriteLine("Введите дату рождения (дд.мм.гггг).");
        if (DateTime.TryParse(Console.ReadLine(), out birthDate))
        {
            break;
        }
        else
        {
            Console.WriteLine("Неверный формат даты рождения.");
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