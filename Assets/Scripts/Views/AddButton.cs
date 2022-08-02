namespace Calculator
{
    public class AddButton : BaseButton
    {
        protected override void Do()
        {
            viewModel.SetOperation(CalculatorOperation.Add);
        }
    }
}