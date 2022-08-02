namespace Calculator
{
    public interface ISaveGateway
    {
        public void Save(CalculatorData data);
        public bool HasSave();
        public CalculatorData Load();
    }
}