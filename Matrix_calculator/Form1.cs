using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_calculator
{
    public partial class Form1 : Form
    {
        private int m_rows;
        private int m_columns;

        public Form1()
        {
            InitializeComponent();

            ClearTable();
            AddColumns();
            AddRows();
        }
        private void AddRows()
        {
            dataGridView1.Rows.Add();
            dataGridView2.Rows.Add();
            dataGridView3.Rows.Add();
            m_rows++;
            foreach (DataGridViewCell cell in dataGridView1.Rows[m_rows - 1].Cells) { cell.Value = "0"; }
            foreach (DataGridViewCell cell in dataGridView2.Rows[m_rows - 1].Cells) { cell.Value = "0"; }
        }

        private void AddColumns()
        {
            m_columns++;
            dataGridView1.Columns.Add("A" + (m_columns - 1).ToString(), "");
            dataGridView2.Columns.Add("B" + (m_columns - 1).ToString(), "");
            dataGridView3.Columns.Add("C" + (m_columns - 1).ToString(), "");
            dataGridView1.Columns[m_columns - 1].Width = 40;
            dataGridView2.Columns[m_columns - 1].Width = 40;
            dataGridView3.Columns[m_columns - 1].Width = 40;

            for (int i = 0; i < m_rows; i++)
            {
                dataGridView1.Rows[i].Cells[m_columns - 1].Value = "0";
                dataGridView2.Rows[i].Cells[m_columns - 1].Value = "0";
                //dataGridView1.Rows[i].Cells[m_columns - 1].Value = "0";
            }
        }

        private void DeleteRows()
        {
            if (m_rows > 1)
            {
                dataGridView1.Rows.RemoveAt(m_rows - 1);
                dataGridView2.Rows.RemoveAt(m_rows - 1);
                dataGridView3.Rows.RemoveAt(m_rows - 1);
                m_rows--;
            }
        }
        private void DeleteColumns()
        {
            if (m_columns > 1)
            {
                dataGridView1.Columns.RemoveAt(m_columns - 1);
                dataGridView2.Columns.RemoveAt(m_columns - 1);
                dataGridView3.Columns.RemoveAt(m_columns - 1);
                m_columns--;
            }
        }

        private void ClearTable()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();
            m_rows = 0;
            m_columns = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddRows();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteRows();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddColumns();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < m_rows; j++)
                for (int i = 0; i < m_columns; i++)
                {
                    float f1, f2;
                    float.TryParse(dataGridView1[i, j].Value.ToString(), out f1);
                    float.TryParse(dataGridView2[i, j].Value.ToString(), out f2);
                    dataGridView3[i, j].Value = f1 + f2;
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < m_rows; j++)
                for (int i = 0; i < m_columns; i++)
                {
                    float f1, f2;
                    float.TryParse(dataGridView1[i,j].Value.ToString(), out f1);
                    float.TryParse(dataGridView2[i,j].Value.ToString(), out f2);
                    dataGridView3[i,j].Value = f1 - f2;
                }
        }
        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            float f;
            if (dataGridView1[e.ColumnIndex, e.RowIndex].Value == null) dataGridView1[e.ColumnIndex, e.RowIndex].Value = "0";
            string s = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (!float.TryParse(s, out f))
            {
                MessageBox.Show("Только данные типа float", "Ошибка", MessageBoxButtons.OK);
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = "0";
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = "0";
        }

        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            float f;
            if (dataGridView2[e.ColumnIndex, e.RowIndex].Value == null) dataGridView2[e.ColumnIndex, e.RowIndex].Value = "0";
            string s = dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (!float.TryParse(s, out f))
            {
                MessageBox.Show("Только данные типа float", "Ошибка", MessageBoxButtons.OK);
                dataGridView2[e.ColumnIndex, e.RowIndex].Value = "0";
            }
        }
    }
}


