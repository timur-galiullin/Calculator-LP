using UnityEngine;
using UnityEngine.UI;

namespace Calculator
{
    [RequireComponent(typeof(Button))]
    public class BaseButton : MonoBehaviour
    {
        [SerializeField] protected CalculatorVM _vm;

        protected Button _button;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Do);
        }

        protected virtual void Do()
        {
        }
    }
}