namespace Calculator
{
    public class GetResultButton : BaseButton
    {
        protected override void Do()
        {
            _vm.GetResult();
        }
    }
}