using CodeBlogFitness.BL.Controller;

Console.WriteLine("Вас приветствует приложение Fitness.");

Console.WriteLine("Введите имя пользователя.");
var name = Console.ReadLine();

var userController = new UserController(name);

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
            Console.WriteLine($"Неверный формат {name}.");
        }
    }
}