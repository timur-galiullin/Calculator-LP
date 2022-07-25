namespace Calculator
{
    public class ConfirmButton : BaseButton
    {
        protected override void Do()
        {
            _vm.Confirm();
        }
    }
}