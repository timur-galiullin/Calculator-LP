using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Calculator
{
    [RequireComponent(typeof(TMP_InputField))]
    public class InputView : MonoBehaviour
    {
        [SerializeField] private CalculatorVM _vm;

        private TMP_InputField _field;

        private Dictionary<CalculatorOperation, string> _operationMatcher = new Dictionary<CalculatorOperation, string>
        {
            { CalculatorOperation.Add, "+" },
            { CalculatorOperation.Subtraction, "-" },
            { CalculatorOperation.Divide, "/" },
            { CalculatorOperation.Multiply, "X" }
        };

        public void ShowManual(string result)
        {
            _field.text = result;
        }

        private void Awake()
        {
            _field = GetComponent<TMP_InputField>();

            _vm.OnUpdateInput += UpdateView;
        }

        private void Start()
        {
            UpdateView();
        }

        private void OnDestroy()
        {
            _vm.OnUpdateInput -= UpdateView;
        }

        private void UpdateView()
        {
            var firstOperand = _vm.FirstOperand is null ? "" : _vm.FirstOperand.ToString();
            var operation = _vm.Operation == CalculatorOperation.None ? "" : _operationMatcher[_vm.Operation];
            var secondOperand = _vm.SecondOperand is null ? "" : _vm.SecondOperand.ToString();
            var result = _vm.Result is null ? "" : "=" + _vm.Result;
            _field.text = firstOperand + operation + secondOperand + result;
        }
    }
}