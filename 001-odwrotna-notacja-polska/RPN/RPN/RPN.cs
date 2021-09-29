using System;
using System.Collections.Generic;

namespace RPNCalulator {
	public class RPN {
		private Stack<int> _operators;
		Dictionary<string, Func<int, int, int>> _operationBinaryFunction;
        Dictionary<string, Func<int, int>> _operationUnaryFunction;

        public int EvalRPN(string input) {
            _operationUnaryFunction = new Dictionary<string, Func<int, int>>
            {
                ["|"] = num => Math.Abs(num),
                ["!"] = num => Factorial(num),
                ["!!"] = num => Semifactorial(num)
            };

            _operationBinaryFunction = new Dictionary<string, Func<int, int, int>>
            {
                ["+"] = (fst, snd) => (fst + snd),
				["-"] = (fst, snd) => (fst - snd),
				["*"] = (fst, snd) => (fst * snd),
				["/"] = (fst, snd) => (fst / snd),
                ["^"] = (fst, snd) => ((int)(Math.Pow(fst, snd)))
            };

            _operators = new Stack<int>();

			var splitInput = input.Split(' ');
			foreach (var op in splitInput)
			{
				if (IsNumber(op))
					_operators.Push(Int32.Parse(op));
				else
                if (IsSingleOperandOperator(op))
                {
                    var num1 = _operators.Pop();
                    _operators.Push(_operationUnaryFunction[op](num1));
                }
                else
                if (IsDoubleOperandOperator(op))
				{
					var num2 = _operators.Pop();
					var num1 = _operators.Pop();
					_operators.Push(_operationBinaryFunction[op](num1, num2));				}
			}

			var result = _operators.Pop();
			if (_operators.IsEmpty)
			{
				return result;
			}
			throw new InvalidOperationException();
		}

		private bool IsNumber(String input) => Int32.TryParse(input, out _);

        private bool IsSingleOperandOperator(String input) =>
            input.Equals("|") || input.Equals("!") ||
            input.Equals("!!");

        private bool IsDoubleOperandOperator(String input) =>
			input.Equals("+") || input.Equals("-") ||
			input.Equals("*") || input.Equals("/") ||
            input.Equals("^");

        private int Factorial(int num)
        {
            if (num == 1)
                return 1;
            else if (num < 0)
                throw new InvalidOperationException("Can not factorize negative number!");
            else
                return checked(num * Factorial(--num));
        }

        private int Semifactorial(int num)
        {
            if (num == 0 || num == 1)
                return 1;
            else if (num < 0)
                throw new InvalidOperationException("Can not factorize negative number!");
            else
                return checked(num * Semifactorial(num - 2));
        }

        private Func<int, int, int> Operation(String input) =>
			(x, y) =>
			(
				(input.Equals("+") ? x + y :
					(input.Equals("*") ? x * y : int.MinValue)
				)
			);
	}
}