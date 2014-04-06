using System;
using System.Collections.Generic;

namespace DiceRollLib
{
    public class DiceRoller : IDiceRoller
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();

        public DiceRoller(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public List<int> RollDiceThisManyTimes(int numberOfDice)
        {
            if (numberOfDice <= 0)
                throw new ArgumentException("Must roll the die at least once");

            var result = new List<int>();

            int currentRoll = 0;
            while (currentRoll < numberOfDice)
            {
                result.Add(_randomNumberGenerator.GenerateRandomNumber(5) + 1);
                currentRoll++;
            }

            return result;
        }
    }
}