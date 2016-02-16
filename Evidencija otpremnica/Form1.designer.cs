namespace Evidencija_otpremnica
{
    partial class Form1
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
            this.textBox_BrojOtpremnice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_DodajOtpremnicu = new System.Windows.Forms.Button();
            this.button_izlaz = new System.Windows.Forms.Button();
            this.button_Evidencija = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_odredisnaFirma = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_BrojOtpremnice
            // 
            this.textBox_BrojOtpremnice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_BrojOtpremnice.Location = new System.Drawing.Point(224, 12);
            this.textBox_BrojOtpremnice.Name = "textBox_BrojOtpremnice";
            this.textBox_BrojOtpremnice.Size = new System.Drawing.Size(130, 38);
            this.textBox_BrojOtpremnice.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj otpremnice:";
            // 
            // button_DodajOtpremnicu
            // 
            this.button_DodajOtpremnicu.AutoSize = true;
            this.button_DodajOtpremnicu.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DodajOtpremnicu.Location = new System.Drawing.Point(224, 100);
            this.button_DodajOtpremnicu.Name = "button_DodajOtpremnicu";
            this.button_DodajOtpremnicu.Size = new System.Drawing.Size(130, 40);
            this.button_DodajOtpremnicu.TabIndex = 2;
            this.button_DodajOtpremnicu.Text = "Dodaj";
            this.button_DodajOtpremnicu.UseVisualStyleBackColor = true;
            this.button_DodajOtpremnicu.Click += new System.EventHandler(this.button_DodajOtpremnicu_Click);
            // 
            // button_izlaz
            // 
            this.button_izlaz.AutoSize = true;
            this.button_izlaz.BackColor = System.Drawing.Color.Red;
            this.button_izlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_izlaz.ForeColor = System.Drawing.Color.White;
            this.button_izlaz.Location = new System.Drawing.Point(12, 113);
            this.button_izlaz.Name = "button_izlaz";
            this.button_izlaz.Size = new System.Drawing.Size(122, 84);
            this.button_izlaz.TabIndex = 4;
            this.button_izlaz.Text = "IZLAZ";
            this.button_izlaz.UseVisualStyleBackColor = false;
            this.button_izlaz.Click += new System.EventHandler(this.button_izlaz_Click);
            // 
            // button_Evidencija
            // 
            this.button_Evidencija.AutoSize = true;
            this.button_Evidencija.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Evidencija.Location = new System.Drawing.Point(224, 159);
            this.button_Evidencija.Name = "button_Evidencija";
            this.button_Evidencija.Size = new System.Drawing.Size(130, 40);
            this.button_Evidencija.TabIndex = 3;
            this.button_Evidencija.Text = "Pregled";
            this.button_Evidencija.UseVisualStyleBackColor = true;
            this.button_Evidencija.Click += new System.EventHandler(this.button_Evidencija_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Istovar:";
            // 
            // textBox_odredisnaFirma
            // 
            this.textBox_odredisnaFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_odredisnaFirma.Location = new System.Drawing.Point(115, 56);
            this.textBox_odredisnaFirma.Name = "textBox_odredisnaFirma";
            this.textBox_odredisnaFirma.Size = new System.Drawing.Size(239, 38);
            this.textBox_odredisnaFirma.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(370, 204);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_odredisnaFirma);
            this.Controls.Add(this.button_Evidencija);
            this.Controls.Add(this.button_izlaz);
            this.Controls.Add(this.button_DodajOtpremnicu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_BrojOtpremnice);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_BrojOtpremnice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_DodajOtpremnicu;
        private System.Windows.Forms.Button button_izlaz;
        private System.Windows.Forms.Button button_Evidencija;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_odredisnaFirma;
    }
}

