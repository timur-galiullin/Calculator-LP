using System;
using UnityEngine;

namespace Calculator
{
    public class NumberButton : BaseButton
    {
        [SerializeField] [Range(0, 9)] protected int _number;

        protected override void Do()
        {
            switch (_vm.Stage)
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
            if (_vm.FirstOperand is null)
            {
                _vm.SetFirstOperand(_number);
            }
            else
            {
                if (int.TryParse(_vm.FirstOperand.ToString() + _number, out int newNumber))
                {
                    _vm.SetFirstOperand(newNumber);
                }
            }
        }

        private void SetSecondOperand()
        {
            if (_vm.SecondOperand is null)
            {
                _vm.SetSecondOperand(_number);
            }
            else if (int.TryParse(_vm.SecondOperand.ToString() + _number, out int newNumber))
            {
                _vm.SetSecondOperand(newNumber);
            }
        }
    }
}