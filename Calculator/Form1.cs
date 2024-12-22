using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double _firstValue;
        private string _operation;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultTextBox.Text == "0")
                resultTextBox.Clear();
            resultTextBox.Text += button.Text; 
        }
        private void btn1_Click(object sender, EventArgs e) => btn_Click(sender, e);
        private void btn2_Click(object sender, EventArgs e) => btn_Click(sender, e);

        private void btn3_Click(object sender, EventArgs e) => btn_Click(sender, e);

        private void btn4_Click(object sender, EventArgs e) => btn_Click(sender, e);
        private void btn5_Click(object sender, EventArgs e) => btn_Click(sender, e);
        private void btn6_Click(object sender, EventArgs e) => btn_Click(sender, e);
        private void btn7_Click(object sender, EventArgs e) => btn_Click(sender, e);

        private void btn8_Click(object sender, EventArgs e) => btn_Click(sender, e);

        private void btn9_Click(object sender, EventArgs e) { btn_Click(sender, e); }
        private void btn0_Click(object sender, EventArgs e) => btn_Click(sender, e);

        private void btnAdd_Click(object sender, EventArgs e) => SetOperation("+");
        private void btnSubtract_Click(object sender, EventArgs e) => SetOperation("-");
        private void btnMultiply_Click(object sender, EventArgs e) => SetOperation("*");
        private void btnDivide_Click(object sender, EventArgs e) => SetOperation("/");

        private void btnEqual_Click(object sender, EventArgs e)
        {
            double secondValue = Convert.ToDouble(resultTextBox.Text);
            double result;
            try
            {
                switch (_operation)
                {
                    case "+":
                        result = _firstValue + secondValue;
                        break;
                    case "-":
                        result = _firstValue - secondValue;
                        break;
                    case "*":
                        result = _firstValue * secondValue;
                        break;
                    case "/":
                        if (secondValue == 0)
                            throw new DivideByZeroException();
                        result = _firstValue / secondValue;
                        break;
                    default:
                        return;
                }
                resultTextBox.Text = result.ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Ошибка: Деление на ноль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultTextBox.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultTextBox.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
            _firstValue = 0;
            _operation = string.Empty;
        }

        private void SetOperation(string operation)
        {
            if (string.IsNullOrWhiteSpace(resultTextBox.Text))
            {
                MessageBox.Show("Введите число перед выполнением операции.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(resultTextBox.Text, out _firstValue))
            {
                MessageBox.Show("Некорректный ввод. Пожалуйста, введите числовое значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resultTextBox.Text = "0";
                return;
            }
            _operation = operation;
            resultTextBox.Text = "0"; 
        }
    }
}
