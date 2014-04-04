using System;
using NUnit.Framework;

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
    }
}
