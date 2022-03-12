using System;
using System.Windows.Forms;

namespace TaschenRechner
{
    public partial class Form2 : Form
    {
       private const double startingValue = 0.0F;
        private double firstNum = 0.0F;
        private double secondNum = 0.0F;
        private string memory = "";

        private const string startingOperator = "";
        private string currentOperator = startingOperator;


        public Form2()
        {
            InitializeComponent();
            //resultLabel.Text = startingValue.ToString();
            resultLabel.Text = firstNum.ToString();
            memoryLabel.Text = startingValue.ToString();
    
        }

        private void numPressed(object sender, EventArgs e)
        {
            if(resultLabel.Text == "0")
            {
                resultLabel.Text = "";
            }
            Button btnPressed = (Button)sender;
            resultLabel.Text += btnPressed.Text;

            try
            {
                firstNum = Convert.ToDouble(resultLabel.Text);
                memory += btnPressed.Text;
                memoryLabel.Text = memory;
                
            }
            catch (Exception)
            {

            }
           



        }

        private void operatorPressed(object sender, EventArgs e)
        {
            Button operatorPressed = (Button)sender;
            double doubleVal = 0.0F;
            currentOperator = operatorPressed.Text;
           

            try
            {
                doubleVal = Convert.ToDouble(resultLabel.Text);
                secondNum = doubleVal;
                memory += currentOperator;
                memoryLabel.Text = memory;
                resultLabel.Text = startingValue.ToString();
                
            }
            catch (Exception)
            {

            }
            
            
        }

        private void equalOperatorPressed(object sender, EventArgs e)
        {
            double doubleVal = 0.0F;

            try
            {
                
                resultLabel.Text = GetResult();
                memory += "=" + resultLabel.Text;
                memoryLabel.Text = memory;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GetResult()
        {
            string toReturn = "";
            switch (currentOperator)
            {
                case "/": toReturn = (firstNum / secondNum).ToString(); break;
                case "*": toReturn = (firstNum * secondNum).ToString(); break;
                case "-": toReturn = (firstNum - secondNum).ToString(); break;
                case "+": toReturn = (firstNum + secondNum).ToString(); break;
                case "%": toReturn = (firstNum % secondNum).ToString(); break;
                default: toReturn = startingValue.ToString(); break;
            }
            return toReturn;
        }

        private void backspacePressed(object sender, EventArgs e)
        {
            if (resultLabel.Text != "0")
            {
                if(resultLabel.Text.Length == 1)
                {
                    resultLabel.Text = "0";
                }
                else
                {
                    resultLabel.Text = resultLabel.Text.Substring(0, resultLabel.Text.Length - 1);

                }

            }
        }

        private void clearPressed(object sender, EventArgs e)
        {
            firstNum = startingValue;
            secondNum = startingValue;
            currentOperator = startingOperator;
            memory = "";
            resultLabel.Text = firstNum.ToString();
            memoryLabel.Text = firstNum.ToString();
        }

       
    }
}