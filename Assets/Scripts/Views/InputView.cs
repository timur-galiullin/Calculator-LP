using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Calculator
{
    [RequireComponent(typeof(TMP_InputField))]
    public class InputView : MonoBehaviour
    {
        [SerializeField] private CalculatorViewModel viewModel;

        private TMP_InputField _field;

        private Dictionary<CalculatorOperation, string> _operationMatcher = new Dictionary<CalculatorOperation, string>
        {
            { CalculatorOperation.Add, "+" },
            { CalculatorOperation.Subtraction, "-" },
            { CalculatorOperation.Divide, "/" },
            { CalculatorOperation.Multiply, "X" }
        };

        private void Awake()
        {
            _field = GetComponent<TMP_InputField>();
        }

        private void OnEnable()
        {
            viewModel.OnUpdateData += UpdateView;
        }

        private void OnDisable()
        {
            viewModel.OnUpdateData -= UpdateView;
        }

        private void Start()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            if (!string.IsNullOrEmpty(viewModel.Data.error))
            {
                _field.text = viewModel.Data.error;
                return;
            }

            var firstOperand = viewModel.Data.hasFirstOperand ? viewModel.Data.firstOperand.ToString() : "";
            var operation = viewModel.Data.operation == CalculatorOperation.None ? "" : _operationMatcher[viewModel.Data.operation];
            var secondOperand = viewModel.Data.hasSecondOperand ? viewModel.Data.secondOperand.ToString() : "";
            var result = viewModel.Data.hasResult ? "=" + viewModel.Data.result : "";
            _field.text = firstOperand + operation + secondOperand + result;
        }
    }
}