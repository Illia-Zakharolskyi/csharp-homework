// .Net 9.0

// Application
using CardGame.src.Application.Utilities.Validators;

namespace CardGame.src.Domain.Models;

public class Character
{
    internal readonly string Name;

    internal readonly int MaxHealth;
    internal int CurrentHealth;

    internal readonly int MaxMana;
    internal int CurrentMana;

    private readonly bool IsPlayer;

    internal int LastDamageDealt = 0;

    private readonly List<Card> Deck = new();
    internal List<Card> Hand { get; private set; }

    private readonly Random _rnd = new();

    private readonly Dictionary<string, double> _characterManaRegen = new()
    {
        { "Vampire", 0.1 },
        { "Ghost", 0.1 },
        { "Werewolf", 0.1 },
        { "Nymph", 0.1 },
        { "Witch", 0.07 }
    };

    internal Character(string name, int maxHealth, int maxMana, bool isPlayer, List<Card> deck)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxMana = maxMana;
        CurrentMana = maxMana;
        IsPlayer = isPlayer;
        Deck = deck;
        Hand = new();
    }

    internal bool IsAlive() => CurrentHealth > 0;
    internal List<Card> GetHand() => Hand;
    internal void ResetStats()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
    }

    protected void TakeDamage(Character attacker, Card card)
    {
        CurrentHealth -= card.AttackPower;
    }
    internal void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    internal void UseMana(Card card)
    {
        CurrentMana -= card.ManaCost;
        if (CurrentMana < 0)
        {
            CurrentMana = 0;
        }
    }

    internal void HandClear()
    {
        Hand.Clear();
    }

    internal void DrawCard()
    {
        if (Deck.Count <= 0)
        {
            return;
        }

        double roll = _rnd.NextDouble() * 100;

        Dictionary<string, int> rarityChances = new()
        {
            { "Common", 50 },
            { "Rare", 30 },
            { "Epic", 15 },
            { "Legendary", 5 }
        };

        double cumulative = 0;
        string? selectedRarity = null;

        foreach (var rc in rarityChances)
        {
            cumulative += rc.Value;

            if (roll <= cumulative)
            {
                selectedRarity = rc.Key; break;
            }
        }

        List<Card> filteredDeck = Deck.Where(card => card.Rarity == selectedRarity).ToList();

        Card drawnCard = filteredDeck[_rnd.Next(filteredDeck.Count)];
        Hand.Add(drawnCard);
    }
    internal void Attack(Character target)
    {
        if (IsPlayer)
        {
            PlayerAttackLogic(target);
        }
        else
        {
            EnemyAttackLogic(target);
        }

        RegenerateManaPercent(_characterManaRegen[Name]);
    }
    private void PlayerAttackLogic(Character target)
    {
        List<Card> availableCards = Hand.Where(card => card.ManaCost <= CurrentMana).ToList();

        if (availableCards.Count == 0)
        {
            Console.WriteLine("You don't have enough mana to use any cards. Skipping turn.");
            return;
        }

        int userChoice = InetegerValidator.ReadInteger(
            promptMessage: "Choose a card to attack with (enter the card number): ",
            invalidInputMessage: "Invalid input. Please try again.",
            allowedAnswers: Enumerable.Range(1, Hand.Count).ToList(),
            invalidChoiceMessage: "That card is not in your hand."
        );

        Card playerCard = Hand[userChoice - 1];

        if (playerCard.ManaCost > CurrentMana)
        {
            Console.WriteLine("Not enough mana for that card, choose another.");
            Attack(target);
            return;
        }

        _ = Hand.Remove(playerCard);
        UseMana(playerCard);
        target.TakeDamage(this, playerCard);
        LastDamageDealt = playerCard.AttackPower;

        Console.WriteLine($"Player used card '{playerCard.Name}' dealing {playerCard.AttackPower} damage to the enemy.");
        return;
    }
    private void EnemyAttackLogic(Character target)
    {
        List<Card> availableCards = Hand.Where(card => card.ManaCost <= CurrentMana).ToList();

        if (availableCards.Count == 0)
        {
            Console.WriteLine("The enemy doesn't have enough mana to use any cards and skips their turn.");
            return;
        }

        Thread.Sleep(2);

        int choice = _rnd.Next(availableCards.Count);
        Card enemyCard = availableCards[choice];

        _ = Hand.Remove(enemyCard);
        UseMana(enemyCard);
        target.TakeDamage(this, enemyCard);
        LastDamageDealt = enemyCard.AttackPower;

        Console.WriteLine($"The enemy used card '{enemyCard.Name}' dealing {enemyCard.AttackPower} damage to the player.");
        return;
    }
    private void RegenerateManaPercent(double percent)
    {
        int regen = (int)Math.Ceiling(MaxMana * percent);
        CurrentMana = Math.Min(MaxMana, CurrentMana + regen);
    }
}