using System;
using System.Collections.Generic;
using DiceRollLib;
using NUnit.Framework;

namespace DiceRollTest
{
    [TestFixture]
    public class SequentialDiceCounterTest
    {
        private static SequentialDiceCounter GetSystemUnderTest()
        {
            return new SequentialDiceCounter();
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void CalculateMaximumSequentialDiceCount_NullRolls_Throws()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            sut.CalculateMaximumSequentialDiceCount(null);
        }

        [Test]
        public void CalculateMaximumSequentialDiceCount_NoRolls_Returns0()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            int result = sut.CalculateMaximumSequentialDiceCount(new List<int>());

            // assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalculateMaximumSequentialDiceCount_OneRoll_Returns1()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            int result = sut.CalculateMaximumSequentialDiceCount(new List<int>{1});

            // assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CalculateMaximumSequentialDiceCount_RollsOf11222_Returns2()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            int result = sut.CalculateMaximumSequentialDiceCount(new List<int> {1, 1, 2, 2, 2});

            // assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CalculateMaximumSequentialDiceCount_RollsOf12312_Returns3()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            int result = sut.CalculateMaximumSequentialDiceCount(new List<int>{1, 2, 3, 1, 2});

            // assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void CalculateMaximumSequentialDiceCount_RollsOf12345_Returns5()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            int result = sut.CalculateMaximumSequentialDiceCount(new List<int> { 1, 2, 3, 4, 5 });

            // assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void CalculateMaximumSequentialDiceCount_RollsOf32541_Returns5()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            int result = sut.CalculateMaximumSequentialDiceCount(new List<int> {3, 2, 5, 4, 1});

            // assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void CalculateMaximumSequentialDiceCount_RollsOf32541_ShouldNotChangeInputOrder()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            var diceRolls = new List<int> {3, 2, 5, 4, 1};
            int result = sut.CalculateMaximumSequentialDiceCount(diceRolls);

            // assert
            Assert.AreEqual(new List<int> { 3, 2, 5, 4, 1 }, diceRolls);
        }

        [Test]
        public void CalculateMaximumSequentialDiceCount_RollsOf666666_Returns1()
        {
            // arrange
            SequentialDiceCounter sut = GetSystemUnderTest();

            // act
            int result = sut.CalculateMaximumSequentialDiceCount(new List<int> { 6, 6, 6, 6, 6 });

            // assert
            Assert.AreEqual(1, result);
        }
    }
}