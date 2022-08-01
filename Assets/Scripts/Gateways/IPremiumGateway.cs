using System;

namespace Calculator
{
    public interface IPremiumGateway
    {
        public Action<string> OnResult { get; set; }
        public void ShowPremium(bool isFirstOperandZero);
    }
}