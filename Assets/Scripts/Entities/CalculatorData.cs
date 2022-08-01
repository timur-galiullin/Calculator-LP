using System;

namespace Calculator
{
    [Serializable]
    public class CalculatorData
    {
        public long firstOperand;
        public long secondOperand;
        public long result;
        public bool hasFirstOperand;
        public bool hasSecondOperand;
        public bool hasResult;
        public string error;
        public CalculatorOperation operation;
        public CalculatorStage stage;
    }
}