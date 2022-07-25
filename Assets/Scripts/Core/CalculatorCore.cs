namespace Calculator
{
    public class CalculatorCore
    {
        public long Calculate(CalculatorOperation operation, long operand1, long operand2)
        {
            var result = 0L;
            switch (operation)
            {
                case CalculatorOperation.Add:
                    result = operand1 + operand2;
                    break;
                case CalculatorOperation.Divide:
                    result = operand1 / operand2;
                    break;
                case CalculatorOperation.Multiply:
                    result = operand1 * operand2;
                    break;
                case CalculatorOperation.Subtraction:
                    result = operand1 - operand2;
                    break;
            }

            return result;
        }
    }
}