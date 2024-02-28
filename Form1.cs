using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomHomeGenerator
{
    public partial class Form1 : Form
    {
        static int sed =555;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int KB = Convert.ToInt32(textBox1.Text);
            KB *= 4;
            List<byte> data = new List<byte>(KB * 256);
            for (int i = 0; i < KB; i++)
            {
                sed += i * 211;
                byte[] A = new byte[256];
                A = FreshMAT();
                for (int j = 0; j < 256; j++)
                { data.Add(A[j]); }
            }



            // Настройка свойств диалога сохранения
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Binary files (*.bin)|*.bin";
            saveFileDialog1.Title = "Save Data File";
            saveFileDialog1.FileName = "dataFile.bin";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream fileStream = saveFileDialog1.OpenFile())
                {
                    foreach (byte value in data)
                    {
                        fileStream.WriteByte(value);
                    }
                }
            }
            MessageBox.Show("OK");

        }

            byte[] FreshMAT()
            {
            List<byte> numbers = new List<byte>(256);
                for (int i = 0; i < 256; i++)
                {
                    numbers.Add((byte)i);
                    
                }

                byte[] result = new byte[256];
                Random random = new Random(sed);
                for (int i = 0; i < 256; i++)
                {
                    int index = random.Next(numbers.Count);
                    result[i] = numbers[index];
                    numbers.RemoveAt(index);
                }
                return result;
            }

        private void textBox1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '1')
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

