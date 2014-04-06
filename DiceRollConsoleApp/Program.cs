using System;
using System.Threading;
using DiceRollLib;

namespace KataClubDiceRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            var diceRoller = new DiceRoller(new RandomNumberGenerator());
            var sequentialDicecounter = new SequentialDiceCounter();

            while (true)
            {
                Console.WriteLine("Rolling 5 dice...");
                const int numberOfDice = 5;
                var diceRolls = diceRoller.RollDiceThisManyTimes(numberOfDice);

                Console.Write("Dice rolls: {");
                int currentDiceRoll = 0;
                while (currentDiceRoll < numberOfDice)
                {
                    Console.Write(diceRolls[currentDiceRoll++]);

                    if (currentDiceRoll != numberOfDice)
                        Console.Write(",");
                }

                Console.Write("}");
                Console.WriteLine();

                var count = sequentialDicecounter.CalculateMaximumSequentialDiceCount(diceRolls);
                Console.WriteLine(string.Format("Maximum sequential dice count: {0}", count));

                Thread.Sleep(1000);
            }
            
        }
    }
}
