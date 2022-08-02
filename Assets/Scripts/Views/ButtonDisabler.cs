using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator
{
    [RequireComponent(typeof(Button))]
    public class ButtonDisabler : MonoBehaviour
    {
        [SerializeField] private CalculatorViewModel viewModel;
        [SerializeField] private List<CalculatorStage> _activeStages;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            UpdateView();
        }

        private void OnEnable()
        {
            viewModel.OnUpdateData += UpdateView;
        }

        private void OnDisable()
        {
            viewModel.OnUpdateData -= UpdateView;
        }

        private void UpdateView()
        {
            _button.interactable = false;
            foreach (var stage in _activeStages)
            {
                if (stage == viewModel.Data.stage)
                {
                    _button.interactable = true;
                    break;
                }
            }
        }
    }
}