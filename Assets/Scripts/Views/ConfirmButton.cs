namespace Calculator
{
    public class ConfirmButton : BaseButton
    {
        protected override void Do()
        {
            viewModel.Confirm();
        }
    }
}