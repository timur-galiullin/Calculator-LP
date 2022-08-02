namespace Calculator
{ 
    public class ClearButton : BaseButton
    {
        protected override void Do()
        {
            viewModel.Clear();
        }
    }
}