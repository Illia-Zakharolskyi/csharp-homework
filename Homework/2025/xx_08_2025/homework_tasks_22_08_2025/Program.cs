using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Media;


class StartProgram
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        while (true)
        {
            TaskMenu();
            UserOperation();
        }
    }
    static void TaskMenu()
    {
        Thread.Sleep(2000);
        Console.Clear();
        List<string> Menu = new List<string> {  "", "Day of the week", "notes", "months of the year", "Calculator", "A Fairytale Planet of Colors", "chatbot for transport",
            "variable's type", "mini game", "exit" };
        Console.WriteLine("operations:");
        for (int i = 1; i < Menu.Count; i++)
        {
            Thread.Sleep(250);
            Console.WriteLine($"{i}. {Menu[i]}");
        }
    }
    static void UserOperation()
    {
        Console.Write("your choice: ");
        int SelectedTask;
        if (int.TryParse(Console.ReadLine(), out SelectedTask))
        {
            Thread.Sleep(1000);
            Console.Clear();
            switch (SelectedTask)
            {
                case 1:
                    DayWeekLevel1();
                    break;
                case 2:
                    NotesLevel1();
                    break;
                case 3:
                    MonthsYearLevel2();
                    break;
                case 4:
                    CalculatorOperationLevel2();
                    break;
                case 5:
                    FairyPlanetOfColoursLevel3();
                    break;
                case 6:
                    ChatBotLevel3();
                    break;
                case 7:
                    PatternMatching();
                    break;
                case 8:
                    MiniGame();
                    break;
                case 9:
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("invalid choice");
                    break;
            }
        }
        else
        {
            Console.WriteLine("you can only choose a number");
        }
    }
    static void DayWeekLevel1()
    {
        Console.Write("what day of the week (1-7): ");
        int SelectedDay;
        if (int.TryParse(Console.ReadLine(), out SelectedDay))
        {
            switch (SelectedDay)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("invalid choice");
                    break;
            }
        }
        else
        {
            Console.WriteLine("you can only choose a number");
        }
    }
    static void NotesLevel1()
    {
        const int PerfectlyNote = 5;
        const int GoodNote = 4;
        const int SatisfactoryNote = 3;
        const int BadNote = 2;
        const int VeryBadNote = 1;

        Console.Write("your grade (1-5): ");
        int SelectedNote;
        if (int.TryParse(Console.ReadLine(), out SelectedNote))
        {
            switch (SelectedNote)
            {
                case PerfectlyNote:
                    Console.WriteLine("perfect!");
                    break;
                case GoodNote:
                    Console.WriteLine("good!");
                    break;
                case SatisfactoryNote:
                    Console.WriteLine("satisfactory");
                    break;
                case BadNote:
                    Console.WriteLine("bad");
                    break;
                case VeryBadNote:
                    Console.WriteLine("very bad");
                    break;
                default:
                    Console.WriteLine("this is not a valid grade");
                    break;
            }
        }
        else
        {
            Console.WriteLine("you can only choose an integer");
        }
    }
    static void MonthsYearLevel2()
    {
        Console.Write("enter a month(1-12): ");
        int SelectedMonth;
        if (int.TryParse(Console.ReadLine(), out SelectedMonth))
        {
            switch (SelectedMonth)
            {
                case 1:
                    Console.WriteLine("January, winter");
                    break;
                case 2:
                    Console.WriteLine("February, winter");
                    break;
                case 3:
                    Console.WriteLine("March, spring");
                    break;
                case 4:
                    Console.WriteLine("April, spring");
                    break;
                case 5:
                    Console.WriteLine("May, spring");
                    break;
                case 6:
                    Console.WriteLine("June, summer");
                    break;
                case 7:
                    Console.WriteLine("July, summer");
                    break;
                case 8:
                    Console.WriteLine("August, summer");
                    break;
                case 9:
                    Console.WriteLine("September, autumn");
                    break;
                case 10:
                    Console.WriteLine("October, autumn");
                    break;
                case 11:
                    Console.WriteLine("November, autumn");
                    break;
                case 12:
                    Console.WriteLine("December, winter");
                    break;
                default:
                    Console.WriteLine("not a valid month");
                    return;
            }
        }
        else
        {
            Console.WriteLine("not a valid month");
        }
    }
    static void CalculatorOperationLevel2()
    {
        Console.Write("choose operation(+,-,*,/): ");
        char SelecredOperation;
        if (Char.TryParse(Console.ReadLine(), out SelecredOperation))
        {
            switch (SelecredOperation)
            {
                case '+':
                    Console.WriteLine("this is addition");
                    break;
                case '-':
                    Console.WriteLine("this is subtraction");
                    break;
                case '*':
                    Console.WriteLine("this is multiplication");
                    break;
                case '/':
                    Console.WriteLine("this is division");
                    break;
                default:
                    Console.WriteLine("invalid operation");
                    return;
            }
        }
        else
        {
            Console.WriteLine("invalid operation");
        }
    }
    static void FairyPlanetOfColoursLevel3()
    {
        List<string> Menu = new List<string> { "red", "orange", "black", "blue", "pink", "green", "yellow" };
        Console.WriteLine("colors for characters:");
        foreach (string item in Menu)
        {
            Console.WriteLine(item);
        }
        Console.Write("your color: ");
        string SelectedColour = Console.ReadLine();
        switch (SelectedColour)
        {
            case "red":
                Console.WriteLine("dragon");
                break;
            case "orange":
                Console.WriteLine("pig pepe");
                break;
            case "black":
                Console.WriteLine("batman");
                break;
            case "blue":
                Console.WriteLine("smurfik");
                break;
            case "pink":
                Console.WriteLine("fairy vinx");
                break;
            case "green":
                Console.WriteLine("forest spirit");
                break;
            case "yellow":
                Console.WriteLine("sunny elf");
                break;
            default:
                Console.WriteLine("in the list there is no such color");
                return;
        }
    }
    static void ChatBotLevel3()
    {
        List<string> Menu = new List<string> { "bus", "train", "plane", "bicycle" };
        Console.WriteLine("transport for checking:");
        foreach (string item in Menu)
        {
            Console.WriteLine(item);
        }
        Console.Write("your transport: ");
        string SelectedTransport = Console.ReadLine();
        switch (SelectedTransport)
        {
            case "bus":
                Console.WriteLine("+-7 hours");
                break;
            case "train":
                Console.WriteLine("+-4 hours");
                break;
            case "plane":
                Console.WriteLine("+-30 minutes");
                break;
            case "bicycle":
                Console.WriteLine("+-1 day");
                break;
            default:
                Console.WriteLine("unknown transport");
                return;
        }
    }
    static void PatternMatching()
    {
        Console.Write("enter something: ");
        string UserInput = Console.ReadLine();
        object obj = null;
        if (int.TryParse(UserInput, out int IntValue))
        {
            obj = IntValue;
        }
        else if (double.TryParse(UserInput, out double DoubleValue))
        {
            obj = DoubleValue;
        }
        else if (bool.TryParse(UserInput, out bool BoolValue))
        {
            obj = BoolValue;
        }
        else if (char.TryParse(UserInput, out char CharValue))
        {
            obj = CharValue;
        }
        else
        {
            obj = UserInput;
        }
        switch (obj)
        {
            case int i:
                Console.WriteLine("integer");
                break;
            case double d:
                Console.WriteLine("decimal");
                break;
            case bool b:
                Console.WriteLine("boolean");
                break;
            case string s:
                Console.WriteLine("string");
                break;
            case null:
                Console.WriteLine("null");
                break;
            default:
                Console.WriteLine("unknown type");
                return;
        }
    }
    static void MiniGame()
    {
        string className = "";
        int Hp = 0;
        string Ability = "";
        List<string> charakters = new List<string>
        {
            "1. warrior",
            "2. mage",
            "3. archer"
        };

        void Warrior()
        {
            className = "warrior";
            Hp = 100;
            Ability = "punch";
        }
        void Magicain()
        {
            className = "mage";
            Hp = 60;
            Ability = "death spell";
        }
        void Archer()
        {
            className = "archer";
            Hp = 70;
            Ability = "arrow";
        }

        foreach (string item in charakters)
        {
            Console.WriteLine(item);
        }
        Console.Write("character: ");
        string selectedCharakter = Console.ReadLine();
        if (int.TryParse(selectedCharakter, out int currentCharakter))
        {
            switch (currentCharakter)
            {
                case 1:
                    Warrior();
                    break;
                case 2:
                    Magicain();
                    break;
                case 3:
                    Archer();
                    break;
                default:
                    Console.WriteLine("character not found");
                    return;
            }
            Console.WriteLine($"your class: {className}, hp: {Hp}, ability: {Ability}");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("invalid input");
        }
    }
}
