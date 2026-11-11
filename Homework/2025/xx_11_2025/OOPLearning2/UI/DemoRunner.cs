using OOPLearning2.Application.Formatters;
using OOPLearning2.Domain.Classes;

namespace OOPLearning2.UI;

internal static class DemoRunner
{
    internal static void RunScenarioDemo()
    {
        App settings = new()
        {
            Name = "Settings",
            BatteryConsumption = 25,
            RequiredBatteryForInstallation = 10,
            RequiredBatteryForDelete = 15
        };
        App calls = new()
        {
            Name = "Calls",
            BatteryConsumption = 15,
            RequiredBatteryForInstallation = 7,
            RequiredBatteryForDelete = 12
        };

        Smartphone myPhone = new()
        {
            Model = "SuperHeroPhone Ultimate Luxury Pro++ Delux",
            BatteryLevel = 100,
            InstalledApps = new List<App> { settings, calls }
        };

        var actions = new List<Action>
        {
            () => myPhone.DisplayInfo(),
            () => myPhone.StartApp(settings),
            () => myPhone.DisplayInfo(),
            () => myPhone.StartApp(calls),
            () => myPhone.DisplayInfo(),
            () => myPhone.RemoveApp(settings),
            () => myPhone.DisplayInfo(),
            () => myPhone.AddApp(settings),
            () => myPhone.DisplayInfo(),
            () => myPhone.StartApp(calls),
            () => myPhone.StartApp(calls),
            () => myPhone.StartApp(calls),
            () => myPhone.AddApp(calls),
            () => myPhone.DisplayInfo(),
            () => myPhone.ChargeBattery(30),
            () => myPhone.StartApp(settings),
            () => myPhone.DisplayInfo(),
        };

        Console.WriteLine(new string('=', 10) + " Start of demo for actions with objects " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Method Action", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " End of demo for actions with objects " + new string('=', 10));
    }
}
