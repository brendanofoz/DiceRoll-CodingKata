using System;
using System.Collections.Generic;

namespace DiceRollLib
{
    public class SequentialDiceCounter
    {
        public int CalculateMaximumSequentialDiceCount(List<int> diceRolls)
        {
            if (diceRolls == null)
                throw new ArgumentNullException("diceRolls");

            if (diceRolls.Count == 0)
                return 0;

            // sort them - because a straight is in ascending order
            var diceRollsForAnalysis = new List<int>(diceRolls);
            diceRollsForAnalysis.Sort();

            // iterate over each dice roll and if it is equal to the previous roll = 1, it forms part of a straight!
            int? previousDiceRoll = null;
            int maximumSequentialDiceCount = 1;
            foreach (var diceRoll in diceRollsForAnalysis)
            {
                if (previousDiceRoll != null)
                {
                    if (diceRoll == previousDiceRoll + 1)
                        maximumSequentialDiceCount++;
                }

                previousDiceRoll = diceRoll;
            }

            return maximumSequentialDiceCount;
        }
    }
}
