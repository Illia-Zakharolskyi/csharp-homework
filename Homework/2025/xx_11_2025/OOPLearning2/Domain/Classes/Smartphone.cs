namespace OOPLearning2.Domain.Classes;

internal class Smartphone
{
    internal string Model { get; init; } = "unknown brand";
    internal List<App> InstalledApps { get; set; } = new List<App>();
    private int batteryLevel;

    internal int BatteryLevel
    {
        get => batteryLevel;
        set
        {
            if (value is < 0 or > 100)
            {
                Console.WriteLine("Battery level must be between 0 and 100. Default value of 100 set.");
                batteryLevel = 100;
            }
            else
            {
                batteryLevel = value;
            }
        }
    }

    internal void DisplayInfo()
    {
        Console.WriteLine($"Model: {Model}, Current battery level: {BatteryLevel}%, Number of installed apps: {InstalledApps.Count}");
    }

    internal void StartApp(App app)
    {
        if (!InstalledApps.Contains(app))
        {
            Console.WriteLine($"App {app.Name} is not installed on the smartphone.");
            return;
        }

        if (BatteryLevel < app.BatteryConsumption)
        {
            Console.WriteLine($"Not enough battery level to launch app {app.Name}.");
            return;
        }

        app.Run(this);

        if (BatteryLevel < 0)
        {
            BatteryLevel = 0;
        }
    }

    internal void ConsumeBattery(int amount)
    {
        if (batteryLevel < 0)
        {
            Console.WriteLine($"The smartphone is dead and cannot be discharged further.");
            return;
        }

        batteryLevel -= amount;

        if (batteryLevel < 0)
        {
            batteryLevel = 0;
        }

        Console.WriteLine($"The smartphone is discharged by {amount}%, current battery level: {batteryLevel}%");
    }

    internal void ChargeBattery(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("The smartphone cannot be charged with a negative amount.");
            return;
        }

        batteryLevel += amount;

        if (batteryLevel > 100)
        {
            batteryLevel = 100;
        }

        Console.WriteLine($"The smartphone is charged by {amount}%. Current battery level: {BatteryLevel}%");
    }

    internal void AddApp(App app)
    {
        if (InstalledApps.Contains(app))
        {
            Console.WriteLine($"App {app.Name} is already installed on the smartphone.");
            return;
        }

        if (BatteryLevel < app.RequiredBatteryForInstallation)
        {
            Console.WriteLine($"Not enough battery level to install app {app.Name}.");
            return;
        }

        BatteryLevel -= app.RequiredBatteryForInstallation;
        InstalledApps.Add(app);

        if (BatteryLevel < 0)
        {
            BatteryLevel = 0;
        }

        Console.WriteLine($"App {app.Name} successfully installed, battery used: {app.RequiredBatteryForInstallation}");
    }
    internal void RemoveApp(App app)
    {
        if (!InstalledApps.Contains(app))
        {
            Console.WriteLine($"App {app.Name} is not installed on the smartphone.");
            return;
        }

        _ = InstalledApps.Remove(app);
        Console.WriteLine($"App {app.Name} successfully removed.");
    }
}