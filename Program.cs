using System;

class SlotMachine
{
    const int STARTING_COINS = 1000;
    const int MIN_BET = 1;
    const int MAX_BET = 1000;

    static void Main()
    {
        int coins = STARTING_COINS;
        int[,] spin = new int[3, 3];
        Random rand = new Random();
        bool playAgain = true;

        SlotMachineUI.WelcomeMessage(coins);

        while (true)
        {
            int winnings = 0;
            int betAmount = SlotMachineUI.GetBetAmount(MIN_BET, MAX_BET);

            if (betAmount < MIN_BET || betAmount > MAX_BET)
            {
                SlotMachineUI.InvalidBetMessage();
                continue;
            }

            if (coins < betAmount)
            {
                SlotMachineUI.NotEnoughCoinsMessage();
                continue;
            }

            coins -= betAmount;

            for (int i = 0; i < spin.GetLength(0); i++)
            {
                for (int j = 0; j < spin.GetLength(1); j++)
                {
                    spin[i, j] = rand.Next(0, 3);
                }
            }

            SlotMachineUI.DisplaySpin(spin);

            int matches = CalculateMatches(spin);

            if (matches > 0)
            {
                winnings = matches * betAmount;
                coins += winnings;
                SlotMachineUI.DisplayWinnings(matches, winnings);
            }
            else
            {
                if (coins <= 0)
                {
                    SlotMachineUI.GameOverMessage();
                    break;
                }
            }

            SlotMachineUI.DisplayCoins(coins);
            playAgain = SlotMachineUI.PlayAgainPrompt();

            if (!playAgain)
            {
                break;
            }

            Console.WriteLine();
        }
    }

    static int CalculateMatches(int[,] spin)
    {
        int matches = 0;

        // check horizontal lines
        for (int i = 0; i < 3; i++)
        {
            if (spin[i, 0] == spin[i, 1] && spin[i, 1] == spin[i, 2])
            {
                matches++;
            }
        }

        // check vertical lines
        for (int i = 0; i < 3; i++)
        {
            if (spin[0, i] == spin[1, i] && spin[1, i] == spin[2, i])
            {
                matches++;
            }
        }

        // check diagonals
        if (spin[0, 0] == spin[1, 1] && spin[1, 1] == spin[2, 2])
        {
            matches++;
        }

        if (spin[2, 0] == spin[1, 1] && spin[1, 1] == spin[0, 2])
        {
            matches++;
        }

        return matches;
    }
}


