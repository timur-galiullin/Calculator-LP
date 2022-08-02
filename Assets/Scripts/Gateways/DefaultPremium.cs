using System;

namespace Calculator
{
    public class DefaultPremium : IPremiumGateway
    {
        public Action<string> OnResult { get; set; }

        public void ShowPremium(bool isFirstOperandZero)
        {
            OnResult?.Invoke(string.Empty);
        }
    }
}