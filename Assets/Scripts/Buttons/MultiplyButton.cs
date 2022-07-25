namespace Calculator
{
    public class MultiplyButton : BaseButton
    {
        protected override void Do()
        {
            _vm.SetOperation(CalculatorOperation.Multiply);
        }
    }
}