namespace Cijene
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_UcitajStupce = new System.Windows.Forms.Button();
            this.button_UpisiCijene = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCBM = new System.Windows.Forms.TextBox();
            this.textBoxZIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Zatvori = new System.Windows.Forms.Button();
            this.button_UcitajExcelDatoteku = new System.Windows.Forms.Button();
            this.textBoxCijene = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button_UcitajStupce
            // 
            this.button_UcitajStupce.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_UcitajStupce.Location = new System.Drawing.Point(4, 188);
            this.button_UcitajStupce.Name = "button_UcitajStupce";
            this.button_UcitajStupce.Size = new System.Drawing.Size(164, 47);
            this.button_UcitajStupce.TabIndex = 0;
            this.button_UcitajStupce.Text = "Učitaj stupce";
            this.button_UcitajStupce.UseVisualStyleBackColor = true;
            this.button_UcitajStupce.Click += new System.EventHandler(this.button_UcitajStupce_Click);
            // 
            // button_UpisiCijene
            // 
            this.button_UpisiCijene.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic);
            this.button_UpisiCijene.Location = new System.Drawing.Point(199, 188);
            this.button_UpisiCijene.Name = "button_UpisiCijene";
            this.button_UpisiCijene.Size = new System.Drawing.Size(141, 44);
            this.button_UpisiCijene.TabIndex = 1;
            this.button_UpisiCijene.Text = "Upiši cijene";
            this.button_UpisiCijene.UseVisualStyleBackColor = true;
            this.button_UpisiCijene.Click += new System.EventHandler(this.button_UpisiCijene_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stupac za kubike:";
            // 
            // textBoxCBM
            // 
            this.textBoxCBM.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Italic);
            this.textBoxCBM.Location = new System.Drawing.Point(199, 12);
            this.textBoxCBM.Name = "textBoxCBM";
            this.textBoxCBM.Size = new System.Drawing.Size(100, 36);
            this.textBoxCBM.TabIndex = 4;
            this.textBoxCBM.DoubleClick += new System.EventHandler(this.textBoxCBM_DoubleClick);
            // 
            // textBoxZIP
            // 
            this.textBoxZIP.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Italic);
            this.textBoxZIP.Location = new System.Drawing.Point(199, 79);
            this.textBoxZIP.Name = "textBoxZIP";
            this.textBoxZIP.Size = new System.Drawing.Size(100, 36);
            this.textBoxZIP.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(-1, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 58);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stupac za\r\npoštanske:";
            // 
            // button_Zatvori
            // 
            this.button_Zatvori.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic);
            this.button_Zatvori.Location = new System.Drawing.Point(199, 256);
            this.button_Zatvori.Name = "button_Zatvori";
            this.button_Zatvori.Size = new System.Drawing.Size(141, 44);
            this.button_Zatvori.TabIndex = 8;
            this.button_Zatvori.Text = "Zatvori";
            this.button_Zatvori.UseVisualStyleBackColor = true;
            this.button_Zatvori.Click += new System.EventHandler(this.button_Zatvori_Click);
            // 
            // button_UcitajExcelDatoteku
            // 
            this.button_UcitajExcelDatoteku.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_UcitajExcelDatoteku.Location = new System.Drawing.Point(4, 241);
            this.button_UcitajExcelDatoteku.Name = "button_UcitajExcelDatoteku";
            this.button_UcitajExcelDatoteku.Size = new System.Drawing.Size(164, 59);
            this.button_UcitajExcelDatoteku.TabIndex = 7;
            this.button_UcitajExcelDatoteku.Text = "Učitaj EXCEL datoteku";
            this.button_UcitajExcelDatoteku.UseVisualStyleBackColor = true;
            this.button_UcitajExcelDatoteku.Click += new System.EventHandler(this.button_UcitajExcelDatoteku_Click);
            // 
            // textBoxCijene
            // 
            this.textBoxCijene.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Italic);
            this.textBoxCijene.Location = new System.Drawing.Point(199, 129);
            this.textBoxCijene.Name = "textBoxCijene";
            this.textBoxCijene.Size = new System.Drawing.Size(100, 36);
            this.textBoxCijene.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(-1, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Stupac za cijene:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(94, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 45);
            this.label4.TabIndex = 11;
            this.label4.Text = "Gotovo!";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 212);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(336, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(352, 306);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCijene);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Zatvori);
            this.Controls.Add(this.button_UcitajExcelDatoteku);
            this.Controls.Add(this.textBoxZIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCBM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_UpisiCijene);
            this.Controls.Add(this.button_UcitajStupce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_UcitajStupce;
        private System.Windows.Forms.Button button_UpisiCijene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCBM;
        private System.Windows.Forms.TextBox textBoxZIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Zatvori;
        private System.Windows.Forms.Button button_UcitajExcelDatoteku;
        private System.Windows.Forms.TextBox textBoxCijene;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

