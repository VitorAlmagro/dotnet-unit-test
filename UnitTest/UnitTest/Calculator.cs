namespace UnitTest
{
    public class Calculator
    {
        public decimal Value { get; private set; } = 0;

        public decimal Add(decimal value)
        {
            return Value += value;
        }

        public decimal Subtract(decimal value)
        {
            return Value -= value;
        }

        public decimal Multiply(decimal value)
        {
            return Value *= value;
        }

        public decimal Divide(decimal value)
        {
            return Value /= value;
        }
    }
}
