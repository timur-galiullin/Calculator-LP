using System;
using UnityEngine;

namespace Calculator
{
    public class CalculatorVM : MonoBehaviour
    {
        private ISaveGateway _saveGateway;
        private CalculatorCore _calculatorCore;

        private long? _firstOperand;
        private long? _secondOperand;
        private long? _result;
        private CalculatorOperation _operation;
        private CalculatorStage _stage;

        public long? FirstOperand
        {
            get => _firstOperand;
            private set
            {
                _firstOperand = value;
                OnUpdateInput?.Invoke();
            }
        }

        public long? SecondOperand
        {
            get => _secondOperand;
            private set
            {
                _secondOperand = value;
                OnUpdateInput?.Invoke();
            }
        }

        public long? Result
        {
            get => _result;
            private set
            {
                _result = value;
                OnUpdateInput?.Invoke();
            }
        }

        public CalculatorOperation Operation
        {
            get => _operation;
            private set
            {
                _operation = value;
                OnUpdateInput?.Invoke();
            }
        }

        public CalculatorStage Stage
        {
            get => _stage;
            private set
            {
                _stage = value;
                OnUpdateStage?.Invoke();
            }
        }

        public Action OnUpdateStage { get; set; }
        public Action OnUpdateInput { get; set; }

        public Action OnDivideByZero { get; set; }

        public void SetFirstOperand(int operand)
        {
            FirstOperand = operand;
            Stage = CalculatorStage.FirstOperand;
        }

        public void SetSecondOperand(int operand)
        {
            SecondOperand = operand;
            Stage = CalculatorStage.SecondOperand;
        }

        public void SetOperation(CalculatorOperation operation)
        {
            Operation = operation;
            Stage = CalculatorStage.Operation;
        }

        public void Clear()
        {
            Stage = CalculatorStage.Start;
            FirstOperand = null;
            SecondOperand = null;
            Result = null;
            Operation = CalculatorOperation.None;
        }

        public void Confirm()
        {
            switch (Stage)
            {
                case CalculatorStage.FirstOperand:
                    Stage = CalculatorStage.PreOperation;
                    break;
                case CalculatorStage.Operation:
                    Stage = CalculatorStage.AfterOperation;
                    break;
                case CalculatorStage.SecondOperand:
                    Stage = CalculatorStage.GetResult;
                    break;
            }
        }

        public void GetResult()
        {
            if (SecondOperand.GetValueOrDefault() == 0 && Operation == CalculatorOperation.Divide)
            {
                Result = 0;
                OnDivideByZero?.Invoke();
            }
            else
            {
                Result = _calculatorCore.Calculate(Operation, FirstOperand.GetValueOrDefault(), SecondOperand.GetValueOrDefault());
            }

            Stage = CalculatorStage.Clear;
        }

        private void Awake()
        {
            _saveGateway = new PlayerPrefsSaveGateway();
            _calculatorCore = new CalculatorCore();
            Clear();
            Load();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void Save()
        {
            var data = new CalculatorData
            {
                firstOperand = FirstOperand.GetValueOrDefault(),
                hasFirstOperand = FirstOperand.HasValue,
                secondOperand = SecondOperand.GetValueOrDefault(),
                hasSecondOperand = SecondOperand.HasValue,
                result = Result.GetValueOrDefault(),
                hasResult = Result.HasValue,
                operation = Operation,
                stage = Stage
            };
            _saveGateway.Save(data);
        }

        private void Load()
        {
            if (!_saveGateway.HasSave())
            {
                return;
            }

            var data = _saveGateway.Load();
            FirstOperand = data.hasFirstOperand ? data.firstOperand : null;
            SecondOperand = data.hasSecondOperand ? data.secondOperand : null;
            Result = data.hasResult ? data.result : null;
            Operation = data.operation;
            Stage = data.stage;
        }
    }
}