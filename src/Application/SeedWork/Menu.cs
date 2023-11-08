using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Application.SeedWork;

public struct Menu
{
    private bool IsSelected { get; set; }
    private int KeyValue { get; set; } = 1;
    private int Left { get; set; }
    private int Top { get; set; }
    private Dictionary<int, string> Options { get; }
    private Menu(Dictionary<int, string> options)
    {
        (Left, Top) = Console.GetCursorPosition();
        Options = options;
    }
    
    public static implicit operator Menu(Dictionary<int, string> options) => new (options);
    public (int Key, string Value) StartAndGetValueSelected()
    {        
        string color = "> \u001b[32m";
        ConsoleKeyInfo key;
        int totalOptions = Options.Count;
        while (!IsSelected)
        {

            Console.SetCursorPosition(Left, Top);
            foreach (var option in Options)
            {
                Console.WriteLine($"{(option.Key == KeyValue ? color : " ")}{option.Value} \u001b[0m");
            }
            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    KeyValue = (KeyValue == totalOptions ? 1 : KeyValue + 1);
                    break;
                case ConsoleKey.UpArrow:
                    KeyValue = (KeyValue == 1 ? totalOptions : KeyValue - 1);
                    break;
                case ConsoleKey.Enter:
                    IsSelected = true;
                    break;
            }

        }
        var value = Options[KeyValue];
        Console.Clear();         
        return (KeyValue, value);
    }
}