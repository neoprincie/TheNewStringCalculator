using System;
using System.Collections.Generic;
using System.Linq;

namespace TheNewStringCalculator
{
    public class Calculator
    {
        private Dictionary<String, Func<Double, Double, Double>> operators;
        private Random random;

        public Calculator()
        {
            ConfigureOperators();
            random = new Random();
        }

        private void ConfigureOperators()
        {
            operators = new Dictionary<String, Func<Double, Double, Double>>();
            operators.Add("^", (x, y) => Math.Pow(x, y));
            operators.Add("*", (x, y) => x * y);
            operators.Add("/", (x, y) => x / y);
            operators.Add("%", (x, y) => x % y);
            operators.Add("+", (x, y) => x + y);
            operators.Add("-", (x, y) => x - y);
            operators.Add("d", (x, y) => RollDice(x, y));
        }

        public Double Calculate(String expression)
        {
            var expressionWithoutParentheses = EvaluateAnyParentheses(expression);
            return Evaluate(expressionWithoutParentheses);
        }

        private String EvaluateAnyParentheses(String expression)
        {
            if (!expression.Contains(")"))
                return expression;

            expression = CheckForImplicitMultiplication(expression);

            var closeParenIndex = expression.IndexOf(")");
            var beginParenIndex = GetBeginningParenthesesIndex(expression, closeParenIndex);
            var parenExpression = expression.Substring(beginParenIndex + 1, closeParenIndex - beginParenIndex - 1);
            var result = Evaluate(parenExpression).ToString();
            expression = expression.Replace("(" + parenExpression + ")", result);
            
            return EvaluateAnyParentheses(expression);
        }

        private static string CheckForImplicitMultiplication(String expression)
        {
            for (var i = 1; i < expression.Count() - 1; i++)
                if ((expression[i] == ')' && Char.IsNumber(expression[i + 1])) ||
                   (expression[i] == '(' && Char.IsNumber(expression[i - 1])))
                    expression = expression.Insert(i + 1, "*");
            return expression;
        }

        private Int32 GetBeginningParenthesesIndex(String expression, Int32 closeParenIndex)
        {
            var beginParenIndex = 0;

            for (var i = closeParenIndex; i > 0; i--)
            {
                if (expression[i] == '(')
                {
                    beginParenIndex = i;
                    break;
                }
            }

            return beginParenIndex;
        }

        private Double Evaluate(String expression)
        {
            Double num;

            if (Double.TryParse(expression, out num))
                return num;
            else
            {
                expression = expression.Replace("--", "+");

                var op = GetLowestOperator(expression);
                var parts = expression.Split(op.ToCharArray()[0]);

                return operators[op](Evaluate(parts[0]), Evaluate(parts[1]));
            }
        }

        private String GetLowestOperator(String expression)
        {
            if (expression.Contains("+"))
                return "+";
            if (expression.Contains("-"))
                return "-";
            if (expression.Contains("%"))
                return "%";
            if (expression.Contains("/"))
                return "/";
            if (expression.Contains("*"))
                return "*";
            if (expression.Contains("d"))
                return "d";
            if (expression.Contains("^"))
                return "^";

            return null;
        }

        private double RollDice(double numberOfDice, double diceValue)
        {
            var roll = 0.0;

            for (var i = 0; i < numberOfDice; i++ )
                roll += random.Next(1, Convert.ToInt32(diceValue));

            return roll;
        }
    }
}
