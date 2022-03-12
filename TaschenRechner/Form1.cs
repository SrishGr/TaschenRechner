using System;
using System.Windows.Forms;

namespace TaschenRechner
{
    public partial class Form1 : Form
    {
        private const double startingVlue = 0.0F;
        private double firstNum = startingVlue;
        private double secondNum = 0.0F;

        private const string startingOperator = "";
        private string currentOperator = startingOperator;
        private bool isCalculateOperation = false;

        public Form1()
        {
            InitializeComponent();
            resultLabel.Text = firstNum.ToString();
        }

        /// <summary> 
        /// Deals with the numbers button clicks 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void numPressed(object sender, EventArgs e)
        {
            Button btnPressed = (Button)sender;

            resultLabel.Text += btnPressed.Text;
        }

        /// <summary> 
        /// Deals with all the operator button clicks 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void operatorPressed(object sender, EventArgs e)
        {
            Button operatorPressed = (Button)sender;
            double doubleVal = 0.0F;

            currentOperator = operatorPressed.Text;

            try
            {
                doubleVal = Convert.ToDouble(resultLabel.Text);
                firstNum = doubleVal;
                resultLabel.Text = startingVlue.ToString();
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Casting Error{0}Check Input!", Environment.NewLine));
            }
        }

        private void equalOperatorPressed(object sender, EventArgs e)
        {
            double doubleVal = 0.0F;
            try
            {
                doubleVal = Convert.ToDouble(resultLabel.Text);
                secondNum = doubleVal;
                resultLabel.Text = GetResult();

                firstNum = startingVlue;
                secondNum = startingVlue;
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Casting Error{0}Check Input!", Environment.NewLine));
            }
        }

        /// <summary> 
        /// Calculates a result based on the numbers and operators in memory 
        /// </summary> 
        /// <returns></returns> 
        private string GetResult()
        {
            string toReturn = string.Empty;
            switch (currentOperator)
            {
                case "÷": toReturn = (firstNum / secondNum).ToString(); break;
                case "*": toReturn = (firstNum * secondNum).ToString(); break;
                case "-": toReturn = (firstNum - secondNum).ToString(); break;
                case "+": toReturn = (firstNum + secondNum).ToString(); break;
                case "%": toReturn = (firstNum % secondNum).ToString(); break;
                default: toReturn = startingVlue.ToString(); break;
            }
            return toReturn;
        }

        /// <summary> 
        /// Deals with the back button click 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void backspacePressed(object sender, EventArgs e)
        {
            //content can be 0, 10, 1000 
            if (resultLabel.Text != startingVlue.ToString())
            {
                if (resultLabel.Text.Length == 1)
                {
                    resultLabel.Text = startingVlue.ToString();
                }
                else
                {
                    resultLabel.Text = resultLabel.Text.Substring(0, resultLabel.Text.Length - 1);
                }
            }
        }

        /// <summary> 
        /// Deals with the clear button click 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void clearPressed(object sender, EventArgs e)
        {
            firstNum = startingVlue;
            secondNum = startingVlue;
            resultLabel.Text = firstNum.ToString();
        }
    }
}