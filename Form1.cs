using Course;
using System.Windows.Forms;
namespace arch
{
    public partial class Form1 : Form
    {
        public event EventHandler CompressFileSelected;
        public event EventHandler DecompressFileSelected;
        public event EventHandler CompressButtonClicked;
        public event EventHandler DecompressButtonClicked;
        public Form1()
        {
            InitializeComponent();
            this.CompressFileSelected += OnCompressFileSelected;
            this.DecompressFileSelected += OnDecompressFileSelected;
            this.CompressButtonClicked += OnCompressButtonClicked;
            this.DecompressButtonClicked += OnDecompressButtonClicked;
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            CompressButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            CompressFileSelected?.Invoke(this, EventArgs.Empty);
        }

        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            DecompressFileSelected?.Invoke(this, EventArgs.Empty);
            
        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            DecompressButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void OnCompressFileSelected(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblFilePath.Text = openFileDialog.FileName;
            }
        }


        private void OnDecompressFileSelected(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblFilePath2.Text = openFileDialog1.FileName;
            }
        }

        private void OnCompressButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblFilePath.Text))
            {
                MessageBox.Show("Пожалуйста, выберите файл.");
                return;
            }

            try
            {
                string compressedFilePath = lblFilePath.Text + ".huf";

                Huffman huffman = new Huffman();
                huffman.CompressFile(lblFilePath.Text, compressedFilePath);

                MessageBox.Show("Файл успешно архивирован " + compressedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

       
        private void OnDecompressButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblFilePath2.Text))
            {
                MessageBox.Show("Пожалуйста, выберите файл.");
                return;
            }

            try
            {
                string decompressedFilePath = lblFilePath2.Text.Replace(".huf", "_decompressed");

                Huffman huffman = new Huffman();
                huffman.DecompressFile(lblFilePath2.Text, decompressedFilePath);

                MessageBox.Show("Файл успешно разархивирован " + decompressedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
