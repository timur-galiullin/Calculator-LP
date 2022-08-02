using System;

namespace Calculator
{
    public class CalculationUseCase : ICalculationUseCase
    {
        private ISaveGateway _saveGateway;
        private IPremiumGateway _premiumGateway;
        private CalculatorCore _calculatorCore;

        public CalculatorData Data { get; private set; }

        public Action OnUpdateData { get; set; }

        public CalculationUseCase()
        {
            _saveGateway = new PlayerPrefsSaveGateway();
            _calculatorCore = new CalculatorCore();
#if UNITY_ANDROID && !UNITY_EDITOR
            _premiumGateway = new AndroidPremium();
#else
            _premiumGateway = new DefaultPremium();
#endif
            _premiumGateway.OnResult += s =>
            {
                Data.error = s;
                OnUpdateData?.Invoke();
            };
            Load();
        }

        public void Calculate()
        {
            if (Data.secondOperand == 0 && Data.operation == CalculatorOperation.Divide)
            {
                Data.result = 0;
                _premiumGateway.ShowPremium(Data.firstOperand == 0);
            }
            else
            {
                Data.result = _calculatorCore.Calculate(Data.operation, Data.firstOperand, Data.secondOperand);
            }

            Data.hasResult = true;
            Data.stage = CalculatorStage.Clear;
            Save();
            OnUpdateData?.Invoke();
        }

        public void Clear()
        {
            Data = new CalculatorData();
            Save();
            OnUpdateData?.Invoke();
        }

        public void SetFirstOperand(int value)
        {
            Data.firstOperand = value;
            Data.hasFirstOperand = true;
            Data.stage = CalculatorStage.FirstOperand;
            Save();
            OnUpdateData?.Invoke();
        }

        public void SetSecondOperand(int value)
        {
            Data.secondOperand = value;
            Data.hasSecondOperand = true;
            Data.stage = CalculatorStage.SecondOperand;
            Save();
            OnUpdateData?.Invoke();
        }

        public void SetOperation(CalculatorOperation operation)
        {
            Data.operation = operation;
            Data.stage = CalculatorStage.Operation;
            Save();
            OnUpdateData?.Invoke();
        }

        public void SetStage(CalculatorStage stage)
        {
            Data.stage = stage;
            Save();
            OnUpdateData?.Invoke();
        }

        private void Save()
        {
            _saveGateway.Save(Data);
        }

        private void Load()
        {
            if (!_saveGateway.HasSave())
            {
                Clear();
                return;
            }

            var data = _saveGateway.Load();
            Data = data;
            OnUpdateData?.Invoke();
        }
    }
}