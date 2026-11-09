namespace OOPLearning.Classes;

internal class BankAccount
{
    internal string OwnerName { get; init; } = string.Empty; // можна ініціалізувати лише під час створення об'єкта
    internal decimal Balance { get; private set; } = 0m; // можливо лише для читання ззовні, змінюється лише методами класу

    internal void ShowAccountInfo()
    {
        Console.WriteLine($"owner of the account: {OwnerName}, funds: {Balance:F2}");
    }

    internal void WithdrawMoney(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds");
            return;

        }
        Balance -= amount;
        Console.WriteLine($"Amount withdrawn from the account: {amount}");
    }

    internal void DepositMoney(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Amount deposited to the account: {amount}");
    }
}