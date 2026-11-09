namespace OOPLearning.Classes;

internal class Trap
{
    internal bool isTriggered { get; private set; } = false;

    internal void TriggerTrap()
    {
        if (isTriggered)
        {
            Console.WriteLine("trap has already been triggered!");
            return;
        }

        isTriggered = true;
        Console.WriteLine("trap has been triggered!");
    }

    internal void ResetTrap()
    {
        if (!isTriggered)
        {
            Console.WriteLine("trap has already been reset and is ready for activation!");
            return;
        }

        isTriggered = false;
        Console.WriteLine("trap has been reset");
    }
}
