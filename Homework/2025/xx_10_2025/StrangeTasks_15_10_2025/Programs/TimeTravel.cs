using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;

namespace StrangeTasks_15_10_2025.Programs;

internal class TimeTravel : IRunnable
{
    public void Run()
    {
        Random rnd = new();
        int startYear = 0;
        double energy = 100.00;

        GetStartingYearOfTravel(ref startYear);
        int endYear;
        GetEndYearOfTravel(rnd, startYear, out endYear);

        Console.WriteLine($"Starting year of travel: {startYear}, End year of travel: {endYear}, Energy before travel: {energy}");

        UpdateEnergyAfterTraveled(ref energy, startYear, endYear);

        Console.WriteLine($"Remaining energy after travel: {energy:F2}");
    }
    private static void GetStartingYearOfTravel(ref int year)
    {
        year = DateTime.Now.Year;
    }
    private static void GetEndYearOfTravel(Random rnd, int startYear, out int endYear)
    {
        endYear = startYear + rnd.Next(startYear);
    }
    private static void UpdateEnergyAfterTraveled(ref double energy, int startYear, int EndYear)
    {
        const double minusEnergyAfterOneYear = 0.01;
        int intervalBetweenYears = EndYear - startYear;

        energy /= (intervalBetweenYears == 0 ? 1 : intervalBetweenYears * minusEnergyAfterOneYear);
    }
}
