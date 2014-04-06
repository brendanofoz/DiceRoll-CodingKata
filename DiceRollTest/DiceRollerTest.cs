using System;
using DiceRollLib;
using NUnit.Framework;
using Rhino.Mocks;

namespace DiceRollTest
{
    [TestFixture]
    public class DiceRollerTest
    {
        [Test, ExpectedException(typeof(ArgumentException), ExpectedMessage = "Must roll the die at least once")]
        public void RollDiceThisManyTimes_ZeroTimes_Throws()
        {
            // arrange
            var sut = new DiceRoller(null);

            // act
            sut.RollDiceThisManyTimes(0);
        }

        [Test]
        public void RollDiceThisManyTimes_OneTime_CallsRandomNumberGenerator()
        {
            // arrange
            var mockRandomNumberGenerator = MockRepository.GenerateMock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.Expect(x => x.GenerateRandomNumber(5)).Return(1);
            var sut = new DiceRoller(mockRandomNumberGenerator);
            
            // act
            sut.RollDiceThisManyTimes(1);

            // assert
            mockRandomNumberGenerator.VerifyAllExpectations();
        }

        [Test]
        public void RollDiceThisManyTimes_TwoTimes_CallsRandomNumberGeneratorTwice()
        {
            // arrange
            var mockRandomNumberGenerator = MockRepository.GenerateStrictMock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.Expect(x => x.GenerateRandomNumber(5)).Repeat.Twice().Return(1);
            var sut = new DiceRoller(mockRandomNumberGenerator);

            // act
            sut.RollDiceThisManyTimes(2);

            // assert
            mockRandomNumberGenerator.VerifyAllExpectations();
        }

    }
}
