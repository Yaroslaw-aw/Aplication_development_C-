using System.Windows.Controls;

namespace FuckingCalculator
{
    class CalculatorArgs : EventArgs
    {
        public decimal answer;
    }

    class CalculatorArithmetic
    {
        public event EventHandler<CalculatorArgs>? Result;
        public decimal result { get; protected set; } = 0;

        protected Stack<decimal> results = new Stack<decimal>();

        /// <summary>
        /// Запускает обработку события
        /// </summary>
        protected void Calculation()
        {
            Result?.Invoke(this, new CalculatorArgs { answer = result });
        }

        /// <summary>
        /// Складывает с результатом предыдущих вычислений введенное число
        /// </summary>
        /// <param name="value"></param>
        public virtual void Add(int value)
        {
            results.Push(result);
            result += value;
            Calculation();
        }

        /// <summary>
        /// Вычитает из результата предыдущих вычислений введенное число
        /// </summary>
        /// <param name="value"></param>
        public virtual void Sub(int value)
        {
            results.Push(result);
            result -= value;
            Calculation();
        }

        /// <summary>
        /// Делит результат предыдущих вычислений на введенное число
        /// </summary>
        /// <param name="value"></param>
        public virtual void Div(int value)
        {
            results.Push(result);
            if (value != 0)
                result /= value;
            else result = 0;
            Calculation();
        }

        /// <summary>
        /// Умножает результат предыдущих вычислений на введенное число
        /// </summary>
        /// <param name="value"></param>
        public virtual void Mult(int value)
        {
            results.Push(result);
            result *= value;
            Calculation();
        }

        /// <summary>
        /// Возврат на предыдущий шаг
        /// </summary>
        public void Back()
        {
            if (results.Count > 0)
            {
                result = results.Pop();
                Calculation();
            }
        }

        /// <summary>
        /// Сбрасывает все вычисления
        /// </summary>
        public void Cancel()
        {
            result = 0;
            results = new Stack<decimal>();
            Calculation();
        }
    }
}
