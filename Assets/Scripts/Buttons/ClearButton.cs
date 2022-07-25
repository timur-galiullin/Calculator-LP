namespace Calculator
{ 
    public class ClearButton : BaseButton
    {
        protected override void Do()
        {
            _vm.Clear();
        }
    }
}