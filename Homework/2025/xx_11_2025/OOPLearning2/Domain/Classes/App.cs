namespace OOPLearning2.Domain.Classes;

internal class App
{
    internal string Name { get; init; } = "unknown app";
    internal int RequiredBatteryForInstallation { get; init; } = 5;
    internal int RequiredBatteryForDelete { get; init; } = 8;
    private int batteryConsumption;

    internal int BatteryConsumption
    {
        get => batteryConsumption;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Battery consumption cannot be negative. Default value of 10% set.");
                batteryConsumption = 10;
            }
            else
            {
                batteryConsumption = value;
            }
        }
    }

    internal void Run(Smartphone smartphone)
    {
        smartphone.ConsumeBattery(BatteryConsumption);
        Console.WriteLine($"App {Name} launched, it consumes {BatteryConsumption}% battery.");
    }
}
