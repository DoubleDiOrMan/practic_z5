using System;
using System.Linq;
using System.Windows.Forms;

namespace Tema_5
{
    public partial class Form1 : Form
    {
        int n;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 5;
            numericUpDown1.Value = 5;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Name = (i + 1).ToString();
                dataGridView2.Columns[i].Name = (i + 1).ToString();
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textbox = (TextBox)sender;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' && textbox.TextLength < 8)
                return;

            if (e.KeyChar == '-' && textbox.SelectionStart == 0 && textbox.SelectionLength == 0 && !textbox.Text.Contains('-'))
                return;

            // разрешает использовать backspace.
            if (e.KeyChar == (char)Keys.Back)
                return;
            // разрешает использовать Enter.
            if (e.KeyChar == (char)Keys.Enter)
                return;

            // если условия не совпадают ничего не вводить.
            e.KeyChar = '\0';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount == 1)
            {
                MessageBox.Show("Массив должен состоять минимум из двух элементов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                label1.Text = "Результат:";
                int[] arr = new int[dataGridView1.ColumnCount];
                try
                {
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        if (dataGridView1.Rows[0].Cells[i].Value == null)
                            throw new Exception("Не все значения введены");
                        arr[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);
                    }

                    int a = multiply2.Min(arr, out int ind);
                    label1.Text += $"\nПервый минимальный элемент = {a} (i = {ind})";

                    int ind2 = multiply2.LastMin(arr);
                    label1.Text += $"\nИндекс последнего минимального элемента = {ind2}";

                    for (int i = 0; i < ind; i++)
                    {
                        arr[i] *= 2;
                    }

                    for (int i = 0; i < dataGridView2.ColumnCount; i++)
                    {
                        dataGridView2.Rows[0].Cells[i].Value = arr[i];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            if (n == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }

            dataGridView1.RowCount = 1;
            dataGridView2.RowCount = 1;

            // устанавливаем количество колонок
            dataGridView1.ColumnCount = n;
            dataGridView2.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = (i + 1).ToString();
                dataGridView1.Columns[i].Width = 60;

                dataGridView2.Columns[i].Name = (i + 1).ToString();
                dataGridView2.Columns[i].Width = 60;

                if (radioButton2.Checked == true)
                {
                    dataGridView1.Rows[0].Cells[i].Value = r.Next(-100, 100);
                }
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.RowCount = 1;
            dataGridView2.RowCount = 1;

            // устанавливаем количество колонок
            dataGridView1.ColumnCount = n;
            dataGridView2.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                // строка заголовков столбцов
                dataGridView1.Columns[i].Name = (i + 1).ToString();
                dataGridView1.Columns[i].Width = 60;

                dataGridView2.Columns[i].Name = (i + 1).ToString();
                dataGridView2.Columns[i].Width = 60;

                if (radioButton2.Checked)
                {
                    // заполняет таблицу случайными значениями
                    dataGridView1.Rows[0].Cells[i].Value = r.Next(-100, 100);
                }

            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0;i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[0].Cells[i].Value = null;
        }
    }
}
