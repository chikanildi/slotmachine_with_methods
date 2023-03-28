using System;

class SlotMachineUI
{
    public static void WelcomeMessage(int coins)
    {
        Console.WriteLine("Welcome to the Slot Machine game!");
        Console.WriteLine($"You have {coins} coins");
    }

    public static int GetBetAmount(int minBet, int maxBet)
    {
        Console.WriteLine($"How much would you like to bet? ({minBet}-{maxBet})");
        Console.Write("Bet: ");
        int betAmount = int.Parse(Console.ReadLine());
        return betAmount;
    }

    public static void DisplaySpin(int[,] spin)
    {
        for (int i = 0; i < spin.GetLength(0); i++)
        {
            for (int j = 0; j < spin.GetLength(1); j++)
            {
                Console.Write($"{spin[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public static void DisplayWinnings(int matches, int winnings)
    {
        Console.WriteLine();
        Console.WriteLine($"The number of matches: {matches}");
        Console.WriteLine($"You won {winnings} dollars!");
    }

    public static void DisplayCoins(int coins)
    {
        Console.WriteLine($"You have {coins} coins");
    }

    public static bool PlayAgainPrompt()
    {
        Console.Write("Would you like to play again? (y/n) ");
        string playAgainStr = Console.ReadLine();

        if (playAgainStr.ToLower() == "y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void InvalidBetMessage()
    {
        Console.WriteLine("Invalid bet amount. Please try again.");
    }

    public static void NotEnoughCoinsMessage()
    {
        Console.WriteLine("You don't have enough coins to place that bet.");
    }

    public static void GameOverMessage()
    {
        Console.WriteLine("You are out of coins");
        Console.WriteLine("\nSorry, you lost.");
        Console.ReadLine();
    }

    public static int CheckBetAmount(int coins, int minBet, int maxBet)
    {
        while (true)
        {
            int betAmount = SlotMachineUI.GetBetAmount(minBet, maxBet);

            if (betAmount < SlotMachine.MIN_BET || betAmount > SlotMachine.MAX_BET)
            {
                SlotMachineUI.InvalidBetMessage();
                continue;
            }

            if (coins < betAmount)
            {
                SlotMachineUI.NotEnoughCoinsMessage();
                continue;
            }

            return betAmount;
        }
    }
}
