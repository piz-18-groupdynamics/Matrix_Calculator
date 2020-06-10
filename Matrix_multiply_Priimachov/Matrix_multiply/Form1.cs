using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_multiply
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonScalar_Click(object sender, EventArgs e)
        {
            labelSc.Visible = true;
            textBox1.Visible = true;
            textBox1.Enabled = true;
            buttonMorV.Visible = false;
            buttonMorV.Enabled = false;
            buttonScalar.Visible = false;
            buttonScalar.Enabled = false;
        }

        private void buttonMorV_Click(object sender, EventArgs e)
        {
            dataGridView2.Enabled = true;
            dataGridView2.Visible = true;
            buttonMorV.Visible = false;
            buttonMorV.Enabled = false;
            buttonScalar.Visible = false;
            buttonScalar.Enabled = false;
            buttonAddCol2.Enabled = true;
            buttonAddCol2.Visible = true;
            buttonDelCol2.Enabled = true;
            buttonDelCol2.Visible = true;
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.RowCount - 1].Cells) { cell.Value = "0"; }
        }

        private void buttonDelRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);
            }
        }

        private void buttonAddCol_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0)
            {
                dataGridView2.Rows.Add();
                foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.RowCount - 1].Cells) { cell.Value = "0"; }
            }
            dataGridView2.Rows.Add();
            foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.RowCount - 1].Cells) { cell.Value = "0"; }
            dataGridView1.Columns.Add((dataGridView1.ColumnCount - 1).ToString(), "");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Value = "0";
            }
        }

        private void buttonDelCol_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount > 1)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.ColumnCount - 1);
            }
            if (dataGridView2.RowCount > 1)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.RowCount - 1);
            }
        }

        private void buttonAddCol2_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Add((dataGridView2.ColumnCount - 1).ToString(), "");
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Cells[dataGridView2.ColumnCount - 1].Value = "0";
            }
        }

        private void buttonDelCol2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.ColumnCount > 1)
            {
                dataGridView2.Columns.RemoveAt(dataGridView2.ColumnCount - 1);
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            double num;
            if (dataGridView1[e.ColumnIndex, e.RowIndex].Value == null) dataGridView1[e.ColumnIndex, e.RowIndex].Value = "0";
            string isdouble = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (!double.TryParse(isdouble, out num))
            {
                MessageBox.Show("Неверный формат данных", "Ошибка", MessageBoxButtons.OK);
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = "0";
            }
        }

        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            double num;
            if (dataGridView2[e.ColumnIndex, e.RowIndex].Value == null) dataGridView2[e.ColumnIndex, e.RowIndex].Value = "0";
            string isdouble = dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (!double.TryParse(isdouble, out num))
            {
                MessageBox.Show("Неверный формат данных", "Ошибка", MessageBoxButtons.OK);
                dataGridView2[e.ColumnIndex, e.RowIndex].Value = "0";
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            double num;
            if (textBox1.Text == null) textBox1.Text = "0";
            string isdouble = textBox1.Text.ToString();
            if(!double.TryParse(isdouble, out num))
            {
                MessageBox.Show("Неверный формат данных", "Ошибка", MessageBoxButtons.OK);
                textBox1.Text = "0";
            }
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Enabled)
            {
                for (int i = 0; i < dataGridView2.ColumnCount-1; i++)
                {
                    dataGridViewEq.Columns.Add(i.ToString(), "");
                }
                dataGridViewEq.Rows.Add(dataGridView1.RowCount);

                for (var i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (var j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        dataGridViewEq[j, i].Value = 0;
                        for (var k = 0; k < dataGridView1.ColumnCount; k++)
                        {
                            double v1, v2, veq;
                            double.TryParse(dataGridView1[k, i].Value.ToString(), out v1);
                            double.TryParse(dataGridView2[j, k].Value.ToString(), out v2);
                            double.TryParse(dataGridViewEq[j, i].Value.ToString(), out veq);
                            dataGridViewEq[j, i].Value =veq + v1 * v2;
                        }
                    }
                }
            }
            else if (textBox1.Enabled)
            {
                for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                {
                    dataGridViewEq.Columns.Add(i.ToString(), "");
                }
                dataGridViewEq.Rows.Add(dataGridView1.RowCount);

                for (var i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (var j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        double v1, v2;
                        double.TryParse(dataGridView1[j, i].Value.ToString(), out v1);
                        double.TryParse(textBox1.Text, out v2);
                        dataGridViewEq[j, i].Value = v1 * v2; 
                    }
                }
            }
            else
            {
                MessageBox.Show("Счачала введите матрицу/вектор/скаляр", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridViewEq.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridViewEq.Columns.Clear();
            textBox1.Clear();
            labelSc.Visible = false;
            textBox1.Enabled = false;
            textBox1.Visible = false;
            dataGridView2.Enabled = false;
            dataGridView2.Visible = false;
            buttonMorV.Enabled = true;
            buttonMorV.Visible = true;
            buttonScalar.Enabled = true;
            buttonScalar.Visible = true;
        }
    }
}
