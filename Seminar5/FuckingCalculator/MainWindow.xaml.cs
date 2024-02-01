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

            int comma = 0;
            foreach (Char ch in input)
            {
                if ('0' <= ch && ch <= '9')
                    result.Append(ch);

                if (comma > 0 && ch == ',' || ch == '.')
                {
                    MessageBox.Show("ЭЭЭ, АЛЁ блять! На клавиатуру смотри !\n\nКуда ты точки там свои ставишь?!");
                }

                if (comma == 0 && ch == ',' || ch == '.' )
                {                    
                    result.Append(',');
                    comma++;
                }                
            }

            string? name = (e.Source as FrameworkElement)?.Name;
             
            if (!decimal.TryParse(result.ToString(), out decimal value) && name != "Cancel" && name != "Back")
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
                case "Back":
                    InputText.Text = string.Empty;
                    calculator.Back();
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