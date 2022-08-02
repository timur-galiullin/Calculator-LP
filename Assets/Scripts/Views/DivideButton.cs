namespace Calculator
{
    public class DivideButton : BaseButton
    {
        protected override void Do()
        {
            viewModel.SetOperation(CalculatorOperation.Divide);
        }
    }
}