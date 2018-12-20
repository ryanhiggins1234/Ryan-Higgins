using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BetCalculatorApp
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string myoperator;
        double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }
        
        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        void OnSquareRoot(object sender, EventArgs e)
        {
            if((currentState == -1 || currentState == 1))
            {
                var result = Math.Sqrt(firstNumber);
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        void OnPercentage(object sender, EventArgs e)
        {
            if((currentState == -1) || (currentState == 1))
                {
                var result = firstNumber / 100;
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            if (this.resultText.Text == "0"|| currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }
            this.resultText.Text += pressed;
            double number;
            if(double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if(currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }

        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
             {
                var result = OperatorHelper.Calculate(firstNumber, secondNumber, myoperator);
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        void squareclicked(object sender, EventArgs e)
        {
            if ((currentState == -1|| currentState == 1))
            {
                var result = firstNumber * firstNumber;
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            myoperator = pressed;
        }
    }
}
