using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgProjekt.CharacterBuilder.Tests
{
    [TestFixture]
    public class CharacterBuilderTests
    {
        private CharacterBuilder builder;

        [SetUp]
        public void SetUp()
        {
            builder = new CharacterBuilder();
        }

        [Test]
        public void GivenSingleRollThree_ShouldReturnNegativeTwo()
        {
            Assert.That(builder.CalculateSingleStat(3), Is.EqualTo(-2));
        }

        [Test]
        public void GivenSingleRollFour_ShouldReturnNegativeOne()
        {
            Assert.That(builder.CalculateSingleStat(4), Is.EqualTo(-1));
        }

        [Test]
        public void GivenSingleRollSix_ShouldReturnZero()
        {
            Assert.That(builder.CalculateSingleStat(6), Is.EqualTo(0));
        }

        [Test]
        public void GivenSingleRollNine_ShouldReturnOne()
        {
            Assert.That(builder.CalculateSingleStat(9), Is.EqualTo(1));
        }

        [Test]
        public void GivenSingleRollTwelve_ShouldReturnTwo()
        {
            Assert.That(builder.CalculateSingleStat(12), Is.EqualTo(2));
        }

        [Test]
        public void GivenSingleRollFifteen_ShouldReturnThree()
        {
            Assert.That(builder.CalculateSingleStat(15), Is.EqualTo(3));
        }

        [Test]
        public void GivenSingleRollEighteen_ShouldReturnFour()
        {
            Assert.That(builder.CalculateSingleStat(18), Is.EqualTo(4));
        }

        [Test]
        public void RandomizeAllAbilities_ShouldFillInCommunicationOfAppropriateValue()
        {
            builder.RandomizeAllAbilities();
            Assert.That(builder.GetCharacter().Communication, Is.GreaterThanOrEqualTo(-2).And.LessThanOrEqualTo(4));
        }

        [Test]
        public void RandomizeAllAbilities_ShouldFillInConstitutionOfAppropriateValue()
        {
            builder.RandomizeAllAbilities();
            Assert.That(builder.GetCharacter().Constitution, Is.GreaterThanOrEqualTo(-2).And.LessThanOrEqualTo(4));
        }

        [Test]
        public void RandomizeAllAbilities_ShouldFillInCunningOfAppropriateValue()
        {
            builder.RandomizeAllAbilities();
            Assert.That(builder.GetCharacter().Cunning, Is.GreaterThanOrEqualTo(-2).And.LessThanOrEqualTo(4));
        }

        [Test]
        public void RandomizeAllAbilities_ShouldFillInDexterityOfAppropriateValue()
        {
            builder.RandomizeAllAbilities();
            Assert.That(builder.GetCharacter().Dexterity, Is.GreaterThanOrEqualTo(-2).And.LessThanOrEqualTo(4));
        }

        [Test]
        public void RandomizeAllAbilities_ShouldFillInMagicOfAppropriateValue()
        {
            builder.RandomizeAllAbilities();
            Assert.That(builder.GetCharacter().Magic, Is.GreaterThanOrEqualTo(-2).And.LessThanOrEqualTo(4));
        }

        [Test]
        public void RandomizeAllAbilities_ShouldFillInPerceptionOfAppropriateValue()
        {
            builder.RandomizeAllAbilities();
            Assert.That(builder.GetCharacter().Perception, Is.GreaterThanOrEqualTo(-2).And.LessThanOrEqualTo(4));
        }

        [Test]
        public void RandomizeAllAbilities_ShouldFillInStrengthOfAppropriateValue()
        {
            builder.RandomizeAllAbilities();
            Assert.That(builder.GetCharacter().Strength, Is.GreaterThanOrEqualTo(-2).And.LessThanOrEqualTo(4));
        }

        [Test]
        public void RandomizeAllAbilities_ShouldFillInWillpowerOfAppropriateValue()
        {
            builder.RandomizeAllAbilities();
            Assert.That(builder.GetCharacter().Willpower, Is.GreaterThanOrEqualTo(-2).And.LessThanOrEqualTo(4));
        }
    }
}
