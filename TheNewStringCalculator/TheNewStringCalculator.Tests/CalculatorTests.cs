using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TheNewStringCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator evaluator;

        [SetUp]
        public void Setup()
        {
            evaluator = new Calculator();
        }

        [Test]
        public void TestBaseCase()
        {
            var input = "1";
            var result = evaluator.Calculate(input);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestNegativeBaseCase()
        {
            var input = "-1";
            var result = evaluator.Calculate(input);

            Assert.That(result, Is.EqualTo(-1));
        }

        [TestCase("1+1", 2)]
        [TestCase("1*1", 1)]
        [TestCase("4/2", 2)]
        [TestCase("4-2", 2)]
        [TestCase("5%2", 1)]
        [TestCase("1*(2+4)", 6)]
        [TestCase("2*(3+2*3)", 18)]
        [TestCase("(3+(5-2))*2", 12)]
        [TestCase("6%2", 0)]
        [TestCase("7%2", 1)]
        [TestCase("14123%7", 4)]
        [TestCase("1445233123%77", 26)]
        [TestCase("3^4", 81)]
        [TestCase("4+3^4*2", 166)]
        [TestCase("(5+(4-2))2+5/(10-8)", 16.5)]
        public void TestRecursiveCase(String expression, Double expected)
        {
            var result = evaluator.Calculate(expression);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("-1+3", 2)]
        [TestCase("3+-1", 2)]
        [TestCase("3--1", 4)]
        public void TestAddingNegatives(String expression, Double expected)
        {
            var result = evaluator.Calculate(expression);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestMultipleExpression()
        {
            var input = "1+2*4";
            var result = evaluator.Calculate(input);

            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void TestSimpleDice()
        {
            var input = "1d1";

            for (var i = 0; i < 100; i++)
            {
                var result = evaluator.Calculate(input);

                Assert.That(result, Is.GreaterThanOrEqualTo(1));
                Assert.That(result, Is.LessThanOrEqualTo(1));
            }
        }

        [Test]
        public void TestRegularSixSidedDice()
        {
            var input = "1d6";

            for (var i = 0; i < 100; i++)
            {
                var result = evaluator.Calculate(input);

                Assert.That(result, Is.GreaterThanOrEqualTo(1));
                Assert.That(result, Is.LessThanOrEqualTo(6));
            }
        }

        [Test]
        public void TestDifferentDiceRolls()
        {
            var input = "1d6";
            var results = new List<double>();

            for (var i = 0; i < 100; i++)
                results.Add(evaluator.Calculate(input));

            Assert.That(results.Distinct().Count(), Is.GreaterThan(1));
        }

        [Test]
        public void TestRegularTwelveSidedDice()
        {
            var input = "1d12";

            for (var i = 0; i < 100; i++)
            {
                var result = evaluator.Calculate(input);

                
            }
        }

        [Test]
        public void TestMoreSixSidedDice()
        {
            var input = "2d6";

            for (var i = 0; i < 100; i++)
            {
                var result = evaluator.Calculate(input);

                Assert.That(result, Is.GreaterThanOrEqualTo(2));
                Assert.That(result, Is.LessThanOrEqualTo(12));
            }
        }

        [Test]
        public void TestExpressionWithDice()
        {
            var input = "2d6*4+8/2";
            var result = evaluator.Calculate(input);

            Assert.That(result, Is.GreaterThanOrEqualTo(6));
            Assert.That(result, Is.LessThanOrEqualTo(51));
        }
    }
}
