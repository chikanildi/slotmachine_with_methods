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
        bool playAgain = true;

        SlotMachineUI.WelcomeMessage(coins);

        while (true)
        {
            int winnings = 0;
            int betAmount = SlotMachineLogic.CheckBetAmount(coins, MIN_BET, MAX_BET);

            coins -= betAmount;

            SlotMachineLogic.GenerateSpin(spin);

            SlotMachineUI.DisplaySpin(spin);

            int matches = SlotMachineLogic.CalculateMatches(spin);

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
}
