using System.Windows.Controls;
using System.Windows.Input;

namespace WPFCalculatorWithClasses
{
    public interface ICalculator
    {
        // Чтобы ничего не забыть при создании нового класса калькулятора
        void doAction(Act action);
        void pressDotButton();
        void pressBackButton();
        void pressCEButton();
        void pressCButton();
        void pressPlusMinusButton();
        void pressTheNumberButton(Button btn);
        void squareRoot();
        void getPercent();
        void oneDevideByX();
        void getResult();
        void pressKey(KeyEventArgs e);
    }
}
