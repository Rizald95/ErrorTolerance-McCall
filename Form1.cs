using System;
using System.IO;
using System.Windows.Forms;

namespace Error_Tolerance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;

            try
            {
                string[] lines = File.ReadAllLines(fileName);
                int komputasiCount = 0;
                int kontrolCount = 0;
                int errorHandlerCount = 0;

                foreach (string line in lines)
                {
                    if (line.Contains("+") || line.Contains("-") || line.Contains("*") || line.Contains("/"))
                    {
                        komputasiCount++;
                    }

                    if (line.Contains("if") || line.Contains("for") || line.Contains("while") || line.Contains("switch"))
                    {
                        kontrolCount++;
                    }

                    if (line.Contains("catch"))
                    {
                        errorHandlerCount++;
                    }
                }

                // Hitung persentase error tolerance
                double persentaseErrorTolerance = (double)errorHandlerCount / (komputasiCount + kontrolCount) * 100;

                // Menampilkan hasil analisis dalam textBox3
                textBox3.Text = "Komputasi: " + komputasiCount + Environment.NewLine
                            + "Struktur Kontrol: " + kontrolCount + Environment.NewLine
                            + "Error Handler: " + errorHandlerCount + Environment.NewLine
                            + "Error Tolerance: " + persentaseErrorTolerance.ToString("0.00") + "%";
            }
            catch (FileNotFoundException)
            {
                textBox3.Text = "File tidak ditemukan.";
            }
            catch (Exception ex)
            {
                textBox3.Text = "Terjadi kesalahan: " + ex.Message;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Tidak ada filter file yang ditetapkan
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        
    }
}
