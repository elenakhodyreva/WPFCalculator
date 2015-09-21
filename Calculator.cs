using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFCalculatorWithClasses
{
    public enum Act { Multiply, Divide, Addition, Substraction, None } /*перечисление с действиями*/

    public class Calculator :ICalculator
    {
        public Act MyAction { get; set; } // Действия сложения, умножения, вычитания, деления
        public TextBox TxtBox { get; set; }

        private string value1; // Здесь сохраняем первое значение введенное в текстбокс
        private string value2; // Здесь сохраняем второе значение

        // конструктор
        public Calculator(TextBox textBox)
        {
            TxtBox = textBox;
        }       

        //нажать кнопку точка
        public void pressDotButton() {

            if (TxtBox.Text.IndexOf('.') == -1)
                TxtBox.Text += ".";
            else { }
        }

        // выполнить действие сложения, умножения, вычитания, деления, передаем в параметре значение перечисления
        public void doAction(Act action)
        {
            MyAction = action;
            value1 = TxtBox.Text;
            TxtBox.Text = string.Empty;
        }

        //кнопка удалить предыдущее введенное значение
        public void pressBackButton() {

            if (TxtBox.Text.Length == 0)
                TxtBox.Text = string.Empty;
            else
                TxtBox.Text = TxtBox.Text.Substring(0, TxtBox.Text.Length - 1);
        }

        public void pressCEButton() {

            TxtBox.Text = "0";
        }

        public void pressCButton()
        {
            TxtBox.Text = "0";
            MyAction = Act.None;
            value1 = string.Empty;
            value2 = string.Empty;
            TxtBox.Focus();
        }

        //меняет введенные числа с положительного на отрицательное и наоборот
        public void pressPlusMinusButton() {

            if (TxtBox.Text == "0")
                TxtBox.Text = "-";
            else
            {
                if (TxtBox.Text.First() == '-')
                    TxtBox.Text = TxtBox.Text.Substring(1, TxtBox.Text.Length - 1);
                else
                    TxtBox.Text = "-" + TxtBox.Text;
            }
        }

        //обработка нажатия кнопки с цифрой, логика та же, меняется только сама кнопка, которую передаем в параметрах
        public void pressTheNumberButton(Button btn)
        {
            if (TxtBox.Text.Length<10)
            {
                if (TxtBox.Text == "0")
                    TxtBox.Text = btn.Content.ToString();
                else
                    TxtBox.Text += btn.Content.ToString();
            }                         

        }

        public void squareRoot() {

           TxtBox.Text = Math.Sqrt(double.Parse(TxtBox.Text)).ToString();
        }

        public void getPercent() {

            if (MyAction == Act.Substraction)
            {
                value2 = TxtBox.Text;
                TxtBox.Text = ((double.Parse(value1) / 100) * double.Parse(value2)).ToString();
            }
        }

        public void oneDevideByX() {

            value1 = TxtBox.Text;
            TxtBox.Text = (1 / double.Parse(value1)).ToString();
        }

        //кнопка равно, в зависимости от значения MyAction, которое присвоили в методе doAction считаем результат
        public void getResult()
        {
            value2 = TxtBox.Text;

            try
            {
                switch (MyAction)
                {
                    case Act.Multiply:
                        TxtBox.Text = ((double.Parse(value1)) * (double.Parse(value2))).ToString();
                        break;
                    case Act.Divide:
                        if (value2 == "0")
                           MessageBox.Show("Невозможно делить на ноль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            TxtBox.Text = ((double.Parse(value1)) / (double.Parse(value2))).ToString();
                        break;
                    case Act.Addition:
                        TxtBox.Text = ((double.Parse(value1)) + (double.Parse(value2))).ToString();
                        break;
                    case Act.Substraction:
                        TxtBox.Text = ((double.Parse(value1)) - (double.Parse(value2))).ToString();
                        break;
                    case Act.None:

                        break;
                }
            }
            catch (Exception ex) //если вдруг возникнет исключение, перехватываем его и выводим сообщение о нем
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //обработка событий клавиатуры
        public void pressKey(KeyEventArgs e)
        {
            // проверяем цифры ли введены
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                if (TxtBox.Text == "0")
                {
                    TxtBox.Text = string.Empty;
                    e.Handled = false;
                }

                else
                    e.Handled = false;
            }

            else if (e.Key == Key.OemPeriod) // введен ли знак точки
            {
                if (TxtBox.Text.IndexOf(".") == -1)
                { }
                else { e.Handled = true; }
            }

            else
            {
                e.Handled = true;
                // во всех остальных случаях находим кнопки минус плюс умножить разделить и равно, и присваиваем MyAction 
                // действие в методе doAction
                if (e.Key == Key.Add)
                    doAction(Act.Addition);
                else if (e.Key == Key.Subtract)
                    doAction(Act.Substraction);
                else if (e.Key == Key.Multiply)
                    doAction(Act.Multiply);
                else if (e.Key == Key.Divide)
                    doAction(Act.Divide);
                else if (e.Key == Key.Enter)
                    getResult();
            }
        }
    }
}
