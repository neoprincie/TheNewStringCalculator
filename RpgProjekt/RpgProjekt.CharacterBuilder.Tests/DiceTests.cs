using NUnit.Framework;

namespace RpgProjekt.CharacterBuilder.Tests
{
    public class DiceTests
    {
        [Test]
        public void RollD6_ShouldReturnInt()
        {
            var dice = new Dice();
            Assert.That(dice.RollD6(), Is.InstanceOf<int>());
        }

        [Test]
        public void RollD6_ShouldReturnValueBetweenOneAndSix()
        {
            var dice = new Dice();
            Assert.That(dice.RollD6(), Is.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(6));
        }

        [Test]
        public void RollD6Thrice_ShouldReturnValueBetweenThreeAndEighteen()
        {
            var dice = new Dice();
            Assert.That(dice.RollD6(3), Is.GreaterThanOrEqualTo(3).And.LessThanOrEqualTo(18));
        }
    }
}
