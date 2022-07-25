using UnityEngine;

namespace Calculator
{
    public class Premium : MonoBehaviour
    {
        [SerializeField] private CalculatorVM _vm;
        [SerializeField] private InputView _inputView;

        private void Awake()
        {
            _vm.OnDivideByZero += ShowDialog;
        }

        private void OnDestroy()
        {
            _vm.OnDivideByZero -= ShowDialog;
        }

        private void ShowDialog()
        {
// #if UNITY_ANDROID && !UNITY_EDITOR
            AndroidExtensions.ShowAlertDialog("Get Premium to unlock this feature", "Get Premium", "Cancel",
                i =>
                {
                    if (i == 0)
                    {
                        if (_vm.FirstOperand == 0)
                        {
                            _inputView.ShowManual("∞");
                        }
                        else
                        {
                            _inputView.ShowManual(@" ̄\_(ツ)_/ ̄");
                        }
                    }
                    else
                    {
                        AndroidExtensions.ShowNotification("Zero", "No money – no honey");
                    }
                });
// #endif
        }
    }
}