using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace WPFCalculatorWithClasses
{
    

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;

        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator(txtBox); // создаем экземпляр калькулятора с нашим текстовым полем
            txtBox.Focus(); // текстбокс автоматически становится в фокусе
        }

        // в зависимости от нажатия кнопок на калькуляторе вызываем методы класса Calculator

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressTheNumberButton((Button)sender);
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressDotButton();
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            calculator.doAction(Act.Divide);
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            calculator.doAction(Act.Multiply);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            calculator.doAction(Act.Substraction);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            calculator.doAction(Act.Addition);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            calculator.pressBackButton();
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressCEButton();
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressCButton();
        }

        private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            calculator.pressPlusMinusButton();            
        }

        private void btnSquareRoot_Click(object sender, RoutedEventArgs e)
        {
            calculator.squareRoot();
        }

        private void btnPersent_Click(object sender, RoutedEventArgs e)
        {
            calculator.getPercent();
        }

        private void btnOneX_Click(object sender, RoutedEventArgs e)
        {
            calculator.oneDevideByX();
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            calculator.getResult();
        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            calculator.pressKey(e);
        }        
    }
}
