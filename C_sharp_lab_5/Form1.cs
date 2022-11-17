using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C_sharp_lab_5
{
    public partial class Form1 : Form
    {
        int status = -1;
        string name_file = "";
        public Form1()
        {
            InitializeComponent();

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        // сохранение файла
        void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
            button7.Enabled = true;
        }
        // открытие файла
        void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
            name_file = filename;
            button7.Enabled = true;
            return;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String_text_changer Test = new String_text_changer();
            string result = "";
            if (status == 1)
                result = Test.give_result(textBox1.Text, textBox3.Text);
            if (status == 2)
                result = Test.give_result_non_string(textBox1.Text, textBox3.Text);
            textBox2.Text = result;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            button4.Enabled = false;
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox2.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (status == -1)
            {
                button3.Enabled = true;
                makeResultToolStripMenuItem.Enabled = true;
            }
            status = 2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (status == -1)
            {
                button3.Enabled = true;
                makeResultToolStripMenuItem.Enabled = true;
            }
            status = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            name_file = "unnamed";
            button7.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            // сохраняем текст в файл
            System.IO.File.WriteAllText(name_file, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e) // open
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
            name_file = filename;
            button7.Enabled = true;
            saveFileAsToolStripMenuItem.Enabled = true;
            return;
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e) // new
        {
            textBox1.Text = "";
            name_file = "";
            button7.Enabled = false;

            //saveFileAsToolStripMenuItem.Enabled = false;

            makeResultToolStripMenuItem.Enabled = true;
            clearResultToolStripMenuItem.Enabled = false;
            saveResultToolStripMenuItem.Enabled = false;

            textBox2.Clear();
        }

        private void saveFileAsToolStripMenuItem_Click(object sender, EventArgs e) // save
        {
            if(name_file != "")
            {
                System.IO.File.WriteAllText(name_file, textBox1.Text);
                MessageBox.Show("Файл сохранен " + name_file);
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                // сохраняем текст в файл
                System.IO.File.WriteAllText(filename, textBox1.Text);
                MessageBox.Show("Файл сохранен " + name_file);
                button7.Enabled = true;
                //saveFileAsToolStripMenuItem.Enabled = true;
                name_file = filename;
            }

        }

        private void saveFileAsToolStripMenuItem1_Click(object sender, EventArgs e) // save as
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен " + name_file);
            button7.Enabled = true;
            //saveFileAsToolStripMenuItem.Enabled = true;
            name_file = filename;
        }

        private void makeResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String_text_changer Test = new String_text_changer();
            string result = "";
            if (status == 1)
                result = Test.give_result(textBox1.Text, textBox3.Text);
            if (status == 2)
                result = Test.give_result_non_string(textBox1.Text, textBox3.Text);
            textBox2.Text = result;
            button4.Enabled = true;
            button5.Enabled = true;
            //saveResultToolStripMenuItem.Enabled = true;
            clearResultToolStripMenuItem.Enabled = true;
        }

        private void saveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox2.Text);
            MessageBox.Show("Файл сохранен");
            button7.Enabled = true;
            //saveFileAsToolStripMenuItem.Enabled = true;
            name_file = filename;
        }
    }
}
