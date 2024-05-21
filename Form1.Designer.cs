namespace arch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog = new OpenFileDialog();
            btnCompress = new Button();
            btnSelectFile = new Button();
            label1 = new Label();
            lblFilePath = new Label();
            lblFilePath2 = new Label();
            label3 = new Label();
            btnSelectFile2 = new Button();
            btnDecompress = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // btnCompress
            // 
            btnCompress.Location = new Point(78, 203);
            btnCompress.Name = "btnCompress";
            btnCompress.Size = new Size(147, 32);
            btnCompress.TabIndex = 0;
            btnCompress.Text = "Архивировать";
            btnCompress.UseVisualStyleBackColor = true;
            btnCompress.Click += btnCompress_Click;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(78, 143);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(118, 29);
            btnSelectFile.TabIndex = 2;
            btnSelectFile.Text = "Выбрать";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(77, 90);
            label1.Name = "label1";
            label1.Size = new Size(303, 25);
            label1.TabIndex = 3;
            label1.Text = "Выберите файл для архивации";
            label1.Click += label1_Click;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFilePath.Location = new Point(219, 147);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(131, 18);
            lblFilePath.TabIndex = 4;
            lblFilePath.Text = "Выбранный файл";
            lblFilePath.Click += label2_Click;
            // 
            // lblFilePath2
            // 
            lblFilePath2.AutoSize = true;
            lblFilePath2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFilePath2.Location = new Point(220, 400);
            lblFilePath2.Name = "lblFilePath2";
            lblFilePath2.Size = new Size(131, 18);
            lblFilePath2.TabIndex = 8;
            lblFilePath2.Text = "Выбранный файл";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(78, 343);
            label3.Name = "label3";
            label3.Size = new Size(335, 25);
            label3.TabIndex = 7;
            label3.Text = "Выберите файл для разархивации";
            // 
            // btnSelectFile2
            // 
            btnSelectFile2.Location = new Point(79, 396);
            btnSelectFile2.Name = "btnSelectFile2";
            btnSelectFile2.Size = new Size(118, 29);
            btnSelectFile2.TabIndex = 6;
            btnSelectFile2.Text = "Выбрать";
            btnSelectFile2.UseVisualStyleBackColor = true;
            btnSelectFile2.Click += btnSelectFile2_Click;
            // 
            // btnDecompress
            // 
            btnDecompress.Location = new Point(79, 456);
            btnDecompress.Name = "btnDecompress";
            btnDecompress.Size = new Size(174, 32);
            btnDecompress.TabIndex = 5;
            btnDecompress.Text = "Разархивировать";
            btnDecompress.UseVisualStyleBackColor = true;
            btnDecompress.Click += btnDecompress_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 616);
            Controls.Add(lblFilePath2);
            Controls.Add(label3);
            Controls.Add(btnSelectFile2);
            Controls.Add(btnDecompress);
            Controls.Add(lblFilePath);
            Controls.Add(label1);
            Controls.Add(btnSelectFile);
            Controls.Add(btnCompress);
            Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Button btnCompress;
        private Button btnSelectFile;
        private Label label1;
        private Label lblFilePath;
        private Label lblFilePath2;
        private Label label3;
        private Button btnSelectFile2;
        private Button btnDecompress;
        private OpenFileDialog openFileDialog1;
    }
}
