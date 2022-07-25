namespace Calculator
{
    public class AddButton : BaseButton
    {
        protected override void Do()
        {
            _vm.SetOperation(CalculatorOperation.Add);
        }
    }
}