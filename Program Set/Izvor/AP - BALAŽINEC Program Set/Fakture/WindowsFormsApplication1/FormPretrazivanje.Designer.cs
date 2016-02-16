namespace WindowsFormApplication1
{
    partial class FormPretrazivanje
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
            this.listBox_placene = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonUPlacene = new System.Windows.Forms.Button();
            this.buttonUNePlacene = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox_nePlacene = new System.Windows.Forms.ListBox();
            this.textBoxPlacene = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNePlacene = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_traziFirme = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_firme = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_placene
            // 
            this.listBox_placene.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox_placene.FormattingEnabled = true;
            this.listBox_placene.ItemHeight = 24;
            this.listBox_placene.Location = new System.Drawing.Point(346, 111);
            this.listBox_placene.Name = "listBox_placene";
            this.listBox_placene.Size = new System.Drawing.Size(402, 268);
            this.listBox_placene.Sorted = true;
            this.listBox_placene.TabIndex = 0;
            this.listBox_placene.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(1101, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Zatvori";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(837, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = " NEPLAČENE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(423, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = " PLAČENE";
            // 
            // buttonUPlacene
            // 
            this.buttonUPlacene.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUPlacene.Location = new System.Drawing.Point(885, 412);
            this.buttonUPlacene.Name = "buttonUPlacene";
            this.buttonUPlacene.Size = new System.Drawing.Size(210, 78);
            this.buttonUPlacene.TabIndex = 5;
            this.buttonUPlacene.Text = "Prebaci u plačene";
            this.buttonUPlacene.UseVisualStyleBackColor = true;
            this.buttonUPlacene.Click += new System.EventHandler(this.buttonUPlacene_Click);
            // 
            // buttonUNePlacene
            // 
            this.buttonUNePlacene.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUNePlacene.Location = new System.Drawing.Point(336, 412);
            this.buttonUNePlacene.Name = "buttonUNePlacene";
            this.buttonUNePlacene.Size = new System.Drawing.Size(210, 78);
            this.buttonUNePlacene.TabIndex = 6;
            this.buttonUNePlacene.Text = "Prebaci u ne plačene";
            this.buttonUNePlacene.UseVisualStyleBackColor = true;
            this.buttonUNePlacene.Click += new System.EventHandler(this.buttonUNePlacene_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(1063, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "OTVORI";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(657, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 40);
            this.button3.TabIndex = 8;
            this.button3.Text = "OTVORI";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox_nePlacene
            // 
            this.listBox_nePlacene.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox_nePlacene.FormattingEnabled = true;
            this.listBox_nePlacene.ItemHeight = 24;
            this.listBox_nePlacene.Location = new System.Drawing.Point(765, 111);
            this.listBox_nePlacene.Name = "listBox_nePlacene";
            this.listBox_nePlacene.Size = new System.Drawing.Size(402, 268);
            this.listBox_nePlacene.Sorted = true;
            this.listBox_nePlacene.TabIndex = 9;
            this.listBox_nePlacene.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged_1);
            // 
            // textBoxPlacene
            // 
            this.textBoxPlacene.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPlacene.Location = new System.Drawing.Point(481, 45);
            this.textBoxPlacene.Name = "textBoxPlacene";
            this.textBoxPlacene.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxPlacene.Size = new System.Drawing.Size(127, 44);
            this.textBoxPlacene.TabIndex = 10;
            this.textBoxPlacene.TextChanged += new System.EventHandler(this.textBoxPlacene_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "TRAŽENJE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(772, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "TRAŽENJE:";
            // 
            // textBoxNePlacene
            // 
            this.textBoxNePlacene.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNePlacene.Location = new System.Drawing.Point(923, 45);
            this.textBoxNePlacene.Name = "textBoxNePlacene";
            this.textBoxNePlacene.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxNePlacene.Size = new System.Drawing.Size(127, 44);
            this.textBoxNePlacene.TabIndex = 12;
            this.textBoxNePlacene.TextChanged += new System.EventHandler(this.textBoxNePlacene_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(669, 446);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(127, 44);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(642, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 31);
            this.label5.TabIndex = 15;
            this.label5.Text = "TRAŽENJE:";
            // 
            // textBox_traziFirme
            // 
            this.textBox_traziFirme.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_traziFirme.Location = new System.Drawing.Point(18, 44);
            this.textBox_traziFirme.Name = "textBox_traziFirme";
            this.textBox_traziFirme.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_traziFirme.Size = new System.Drawing.Size(293, 44);
            this.textBox_traziFirme.TabIndex = 20;
            this.textBox_traziFirme.TextChanged += new System.EventHandler(this.textBox_traziFirme_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 31);
            this.label7.TabIndex = 17;
            this.label7.Text = "Pretraži firme:";
            // 
            // listBox_firme
            // 
            this.listBox_firme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox_firme.FormattingEnabled = true;
            this.listBox_firme.ItemHeight = 24;
            this.listBox_firme.Location = new System.Drawing.Point(12, 111);
            this.listBox_firme.Name = "listBox_firme";
            this.listBox_firme.Size = new System.Drawing.Size(328, 268);
            this.listBox_firme.Sorted = true;
            this.listBox_firme.TabIndex = 21;
            this.listBox_firme.DoubleClick += new System.EventHandler(this.listBox_firme_DoubleClick);
            // 
            // FormPretrazivanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1187, 527);
            this.Controls.Add(this.listBox_firme);
            this.Controls.Add(this.textBox_traziFirme);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNePlacene);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPlacene);
            this.Controls.Add(this.listBox_nePlacene);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonUNePlacene);
            this.Controls.Add(this.buttonUPlacene);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox_placene);
            this.Name = "FormPretrazivanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormPoBrojuFakture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_placene;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonUPlacene;
        private System.Windows.Forms.Button buttonUNePlacene;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox_nePlacene;
        private System.Windows.Forms.TextBox textBoxPlacene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNePlacene;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_traziFirme;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox_firme;
    }
}