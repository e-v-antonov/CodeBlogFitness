using CodeBlogFitness.BL.Controller;

Console.WriteLine("Вас приветствует приложение Fitness.");

Console.WriteLine("Введите имя пользователя.");
var name = Console.ReadLine();

Console.WriteLine("Введите пол.");
var gender = Console.ReadLine();

Console.WriteLine("Введите дату рождения.");
var birthdate = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Введите вес.");
var weight = Double.Parse(Console.ReadLine());

Console.WriteLine("Введите рост.");
var height = Double.Parse(Console.ReadLine());

var userController = new UserController(name, gender, birthdate, weight, height);
userController.Save(); 