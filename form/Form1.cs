using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Display selected file path in txtFilePath TextBox
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            try
            {
                // File path for the compressed file, you could allow the user to select this too
                string compressedFilePath = txtFilePath.Text + ".huff";

                // Create an instance of the Huffman class and call CompressFile
                HuffmanArch.Huffman huffman = new Huffman();
                huffman.CompressFile(txtFilePath.Text, compressedFilePath);

                MessageBox.Show("File compressed successfully to " + compressedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
