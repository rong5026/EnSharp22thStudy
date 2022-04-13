using System.Text.RegularExpressions;

//Console.SetWindowSize(150, 40);


while (true)
{
    string id = Console.ReadLine();

    Console.WriteLine(Regex.IsMatch(id, @"^[0-9]{6}$")); // 숫자6자리

}

//Console.WriteLine(Console.GetCursorPosition()); //

//Console.WindowHeight
//Console.WindowWidth
