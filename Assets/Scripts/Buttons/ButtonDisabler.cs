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
        [SerializeField] private CalculatorVM _vm;
        [SerializeField] private List<CalculatorStage> _activeStages;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();

            _vm.OnUpdateStage += UpdateView;
        }

        private void Start()
        {
            UpdateView();
        }

        private void OnDestroy()
        {
            _vm.OnUpdateStage -= UpdateView;
        }

        private void UpdateView()
        {
            _button.interactable = false;
            foreach (var stage in _activeStages)
            {
                if (stage == _vm.Stage)
                {
                    _button.interactable = true;
                    break;
                }
            }
        }
    }
}