namespace Calculator
{
    public class SubtractionButton : BaseButton
    {
        protected override void Do()
        {
            _vm.SetOperation(CalculatorOperation.Subtraction);
        }
    }
}