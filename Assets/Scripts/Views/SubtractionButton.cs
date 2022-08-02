namespace Calculator
{
    public class SubtractionButton : BaseButton
    {
        protected override void Do()
        {
            viewModel.SetOperation(CalculatorOperation.Subtraction);
        }
    }
}