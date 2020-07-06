using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CryptoAlex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            using (StreamReader file = new StreamReader(files[0], Encoding.UTF8))
            {
                textBox1.Text = file.ReadToEnd();                             
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Coder code = new Coder();
            var textToCode = textBox1.Text;
            var codedText = "";

            if (!string.IsNullOrEmpty(textToCode))
            {
                codedText = code.Code(textToCode);
                textBox2.Text = codedText;
            }
            else
            {
                MessageBox.Show("Введите текст для шифрования!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Coder code = new Coder();
            var text = textBox2.Text;
            var encoded = "";

            if (!string.IsNullOrEmpty(text))
            {
                encoded = code.Encode(text);
                textBox2.Text = encoded;
            }
            else
            {
                MessageBox.Show("Введите текст для дешифрования!");
            }
            

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(dialog.FileName, Encoding.UTF8);
            }
        }
    }
}
