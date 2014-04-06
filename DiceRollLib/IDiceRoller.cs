using System.Collections.Generic;

namespace DiceRollLib
{
    public interface IDiceRoller
    {
        List<int> RollDiceThisManyTimes(int numberOfDice);
    }
}