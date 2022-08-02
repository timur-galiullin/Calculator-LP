using System;
using UnityEngine;

namespace Calculator
{
    public class CalculatorViewModel : MonoBehaviour
    {
        private ICalculationUseCase _calculationUseCase;

        public CalculatorData Data => _calculationUseCase.Data;

        public Action OnUpdateData { get; set; }

        public void SetFirstOperand(int operand)
        {
            _calculationUseCase.SetFirstOperand(operand);
        }

        public void SetSecondOperand(int operand)
        {
            _calculationUseCase.SetSecondOperand(operand);
        }

        public void SetOperation(CalculatorOperation operation)
        {
            _calculationUseCase.SetOperation(operation);
        }

        public void Clear()
        {
            _calculationUseCase.Clear();
        }

        public void GetResult()
        {
            _calculationUseCase.Calculate();
        }

        public void Confirm()
        {
            switch (Data.stage)
            {
                case CalculatorStage.FirstOperand:
                    _calculationUseCase.SetStage(CalculatorStage.PreOperation);
                    break;
                case CalculatorStage.Operation:
                    _calculationUseCase.SetStage(CalculatorStage.AfterOperation);
                    break;
                case CalculatorStage.SecondOperand:
                    _calculationUseCase.SetStage(CalculatorStage.GetResult);
                    break;
            }
        }

        private void Awake()
        {
            _calculationUseCase = new CalculationUseCase();
            _calculationUseCase.OnUpdateData += UpdateData;
            UpdateData();
        }

        private void OnDestroy()
        {
            _calculationUseCase.OnUpdateData -= UpdateData;
        }

        private void UpdateData()
        {
            OnUpdateData?.Invoke();
        }
    }
}