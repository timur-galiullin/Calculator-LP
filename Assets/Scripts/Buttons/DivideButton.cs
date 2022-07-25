namespace Calculator
{
    public class DivideButton : BaseButton
    {
        protected override void Do()
        {
            _vm.SetOperation(CalculatorOperation.Divide);
        }
    }
}