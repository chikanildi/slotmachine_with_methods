using System;

class SlotMachineLogic
{
    public static void GenerateSpin(int[,] spin)
    {
        Random rand = new Random();

        for (int i = 0; i < spin.GetLength(0); i++)
        {
            for (int j = 0; j < spin.GetLength(1); j++)
            {
                spin[i, j] = rand.Next(0, 3);
            }
        }
    }

    public static int CalculateMatches(int[,] spin)
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

    public static int CheckBetAmount(int coins, int minBet, int maxBet)
    {
        while (true)
        {
            int betAmount = SlotMachineUI.GetBetAmount(minBet, maxBet);

            if (betAmount < minBet || betAmount > maxBet)
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
