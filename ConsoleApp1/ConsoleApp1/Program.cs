using System.Text.RegularExpressions;
char[] arr = { 'O', 'O', 'O', 'O', 'O', '5', '6', 'O', '8', '9' };


while (true)
{
    string name = Console.ReadLine();
    bool check;
    check = Regex.IsMatch(name, @"^[1-9]+[0-9]?[0-9]?$"); //  

    Console.WriteLine(check);
}

//Console.SetCursorPosition(origCol + x, origRow + y);
Console.WriteLine(Console.GetCursorPosition());

Console.WriteLine("┌---------------------------------------┐");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│      {0}     ││      {0}     ││     {0}     │", arr[1], arr[2], arr[3]);
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│------------││------------││-----------│");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│      {0}     ││      {0}     ││     {2}     │", arr[4], arr[5], arr[6]);
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│------------││------------││-----------│");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│      {0}     ││      {1}     ││     {2}     │", arr[7], arr[8], arr[9]);
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("│            ││            ││           │");
Console.WriteLine("└---------------------------------------┘");