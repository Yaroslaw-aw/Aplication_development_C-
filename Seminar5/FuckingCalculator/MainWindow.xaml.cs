using System.Text;
using System.Windows;

namespace FuckingCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            calculator.Result += Calculator_Result;
        }

        private void Calculator_Result(object? sender, CalculatorArgs e)
        {
            Answer.Content = e.answer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {               
            string input = InputText.Text;

            StringBuilder result = new StringBuilder();

            foreach (Char ch in input)
            {
                if ('0' <= ch && ch <= '9')
                    result.Append(ch);
            }

            string? name = (e.Source as FrameworkElement)?.Name;

            if (!int.TryParse(result.ToString(), out int value) && name != "Cancel")
            {
                MessageBox.Show("Ты че, пьяный?");
                return;
            }            

            switch (name)
            {
                case "Add":
                    calculator.Add(value);
                    InputText.Text = string.Empty;
                    break;
                case "Sub":
                    calculator.Sub(value);
                    InputText.Text = string.Empty;
                    break;
                case "Mult":
                    calculator.Mult(value);
                    InputText.Text = string.Empty;
                    break;
                case "Div":
                    calculator.Div(value);
                    InputText.Text = string.Empty;
                    break;
                case "Cancel":
                    InputText.Text = string.Empty;
                    calculator.Cancel();
                    break;
                default:
                    MessageBox.Show("Какая-то ошибка");
                    InputText.Text = string.Empty;
                    break;
            }
        }
    }
}