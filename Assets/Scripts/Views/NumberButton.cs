using UnityEngine;

namespace Calculator
{
    public class NumberButton : BaseButton
    {
        [SerializeField] [Range(0, 9)] protected int _number;

        protected override void Do()
        {
            switch (viewModel.Data.stage)
            {
                case CalculatorStage.Start:
                case CalculatorStage.FirstOperand:
                    SetFirstOperand();
                    break;
                case CalculatorStage.SecondOperand:
                case CalculatorStage.AfterOperation:
                    SetSecondOperand();
                    break;
            }
        }

        private void SetFirstOperand()
        {
            if (!viewModel.Data.hasFirstOperand)
            {
                viewModel.SetFirstOperand(_number);
            }
            else
            {
                if (int.TryParse(viewModel.Data.firstOperand.ToString() + _number, out var newNumber))
                {
                    viewModel.SetFirstOperand(newNumber);
                }
            }
        }

        private void SetSecondOperand()
        {
            if (!viewModel.Data.hasSecondOperand)
            {
                viewModel.SetSecondOperand(_number);
            }
            else if (int.TryParse(viewModel.Data.secondOperand.ToString() + _number, out var newNumber))
            {
                viewModel.SetSecondOperand(newNumber);
            }
        }
    }
}