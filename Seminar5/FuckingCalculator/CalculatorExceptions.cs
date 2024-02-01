using System.CodeDom.Compiler;
using System.Windows;

namespace FuckingCalculator
{
    class CalculatorExceptions : CalculatorArithmetic
    {
        //public decimal result { get; private set; } = 0;
        //Stack<decimal> results = new Stack<decimal>();

        /// <summary>
        /// Складывает с результатом предыдущих вычислений введенное число
        /// </summary>
        /// <param name="value"></param>
        public override void Add(int value)
        {
            try
            {
                base.Add(value);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Вычитает из результата предыдущих вычислений введенное число
        /// </summary>
        /// <param name="value"></param>
        public override void Sub(int value)
        {
            try
            {
                base.Sub(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }        

        /// <summary>
        /// Умножает результат предыдущих вычислений на введенное число
        /// </summary>
        /// <param name="value"></param>
        public override void Mult(int value)
        {
            try
            {
                base.Mult(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// Обработка деления на ноль
        /// </summary>
        /// <param name="value"></param>
        public override void Div(int value)
        {
            try
            {
                base.Div(value);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Add(decimal value)
        {
            results.Push(value);
            result += value;
            base.Calculation();
        }

        public void Sub(decimal value)
        {
            results.Push(value);
            result -= value;
            base.Calculation();
        }

        public void Mult(decimal value)
        {
            results.Push(value);
            result *= value;
            base.Calculation();
        }

        public void Div(decimal value)
        {
            results.Push(value);            
            
            try
            {
                result /= value;
                base.Calculation();
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
