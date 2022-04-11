using System.Text.RegularExpressions;
char[] arr = { 'O', 'O', 'O', 'O', 'O', '5', '6', 'O', '8', '9' };


while (true)
{
    string id;
    bool check;
    id = Console.ReadLine();
    check = Regex.IsMatch(id, @"^[1-9][0-9]{0,2}$"); //  1~999

    Console.WriteLine(check);
}

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