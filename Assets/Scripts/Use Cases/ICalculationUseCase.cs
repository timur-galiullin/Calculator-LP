using System;

namespace Calculator
{
    public interface ICalculationUseCase
    {
        public Action OnUpdateData { get; set; }
        public CalculatorData Data { get; }
        public void Calculate();
        public void Clear();

        public void SetFirstOperand(int value);
        public void SetSecondOperand(int value);
        public void SetOperation(CalculatorOperation operation);
        public void SetStage(CalculatorStage stage);
    }
}