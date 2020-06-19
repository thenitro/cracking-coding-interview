using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodingInterview.Moderate
{
    public class Task1626
    {
        public Task1626()
        {
            Console.WriteLine(-27 == Solution("2-6-7*8/2+5"));
            Console.WriteLine(23.5 == Solution("2*3+5/6*3+15"));
        }

        private double Solution(string sequence)
        {
            var numbers = new Stack<double>();
            var operators = new Stack<Operator>();

            for (var i = 0; i < sequence.Length; i++)
            {
                var value = ParseNextNumber(sequence, i);
                numbers.Push((double)value.Item1);

                i += value.Item2;
                if (i >= sequence.Length)
                {
                    break;
                }

                var op = ParseNextOperator(sequence, i);
                CollapseTop(op, numbers, operators);
                operators.Push(op);
            }

            CollapseTop(Operator.Blank, numbers, operators);
            if (numbers.Count == 1 && operators.Count == 0)
            {
                return numbers.Pop();
            }
            
            return 0;
        }

        private void CollapseTop(Operator future, Stack<double> numbers, Stack<Operator> operators)
        {
            while (operators.Count >= 1 && numbers.Count >= 2)
            {
                if ((int) future <= (int) operators.Peek())
                {
                    var second = numbers.Pop();
                    var first = numbers.Pop();
                    var op = operators.Pop();
                    var collapsed = ApplyOperator(first, op, second);
                    numbers.Push(collapsed);
                }
                else
                {
                    break;
                }
            }
        }

        private double ApplyOperator(double first, Operator op, double second)
        {
            if (op == Operator.Add) return first + second;
            if (op == Operator.Subtract) return first - second;
            if (op == Operator.Multiply) return first * second;
            if (op == Operator.Divide) return first / second;

            return second;
        }

        private Tuple<int, int> ParseNextNumber(string sequence, int offset)
        {
            var sb = new StringBuilder();

            while (offset < sequence.Length && char.IsDigit(sequence[offset]))
            {
                sb.Append(sequence[offset]);
                offset++;
            }

            return new Tuple<int, int>(int.Parse(sb.ToString()), sb.Length);
        }

        private Operator ParseNextOperator(string sequence, int offset)
        {
            var c = sequence[offset];

            switch (c)
            {
                case '+': return Operator.Add;
                case '-': return Operator.Subtract;
                case '*': return Operator.Multiply;
                case '/': return Operator.Divide;
            }

            return Operator.Blank;
        }

        private enum Operator
        {
            Blank = 0,
            Add = 1,
            Subtract = 2,
            Multiply = 3,
            Divide = 4,
        }
    }
}