using System;

namespace Calculator
{
    public class AndroidPremium : IPremiumGateway
    {
        public Action<string> OnResult { get; set; }

        public void ShowPremium(bool isFirstOperandZero)
        {
            AndroidExtensions.ShowAlertDialog("Get Premium to unlock this feature", "Get Premium", "Cancel",
                i =>
                {
                    if (i == 0)
                    {
                        if (isFirstOperandZero)
                        {
                            OnResult?.Invoke("∞");
                        }
                        else
                        {
                            OnResult?.Invoke(@" ̄\_(ツ)_/ ̄");
                        }
                    }
                    else
                    {
                        AndroidExtensions.ShowNotification("Zero", "No money – no honey");
                    }
                });
        }
    }
}