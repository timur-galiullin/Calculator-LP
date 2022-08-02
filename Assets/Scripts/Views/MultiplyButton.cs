namespace Calculator
{
    public class MultiplyButton : BaseButton
    {
        protected override void Do()
        {
            viewModel.SetOperation(CalculatorOperation.Multiply);
        }
    }
}