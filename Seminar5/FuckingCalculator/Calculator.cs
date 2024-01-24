namespace FuckingCalculator
{
    class CalculatorArgs : EventArgs
    {
        public int answer;
    }

    class Calculator
    {
        public event EventHandler<CalculatorArgs> Result;
        public int result { get; private set; } = 0;

        Stack<int> results = new Stack<int>();

        private void Calculation()
        {
            Result.Invoke(this, new CalculatorArgs { answer = result }); 
        }

        public void Add(int value)
        {
            results.Push(result);
            result += value;
            Calculation();
        }

        public void Sub(int value)
        {
            results.Push(result);
            result -= value;
            Calculation();
        }

        public void Div(int value)
        {
            results.Push(result);
            if (value != 0)
                result /= value;
            else result = 0;
            Calculation();
        }

        public void Mult(int value)
        {
            results.Push(result);
            result *= value;
            Calculation();
        }

        public void Cancel()
        {
            if (results.Count > 0)
            {
                result = results.Pop();
                Calculation();
            }

        }
    }
}
