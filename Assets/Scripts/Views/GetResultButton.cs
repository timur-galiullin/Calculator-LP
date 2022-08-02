namespace Calculator
{
    public class GetResultButton : BaseButton
    {
        protected override void Do()
        {
            viewModel.GetResult();
        }
    }
}