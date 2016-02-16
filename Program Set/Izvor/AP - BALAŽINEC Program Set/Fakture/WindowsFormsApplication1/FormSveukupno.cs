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

namespace WindowsFormApplication1
{
    public partial class FormSveukupno : Form
    {
        
        public FormSveukupno()
        {
            InitializeComponent();

             string put = System.IO.File.ReadAllText(Application.StartupPath + "\\Fakture\\PutFakture.txt");            

            int count1=0,count2=0;
            //traženje za PLAČENO
            try
            {
                    string[] dirs = Directory.GetDirectories(put, "PLAČENO", SearchOption.AllDirectories);
                    foreach (string dir in dirs)
                    {
                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count1 = count1 + fCount;

                    }
                
                listBox1.Items.Add(count1);
            }
            catch 
            {
                MessageBox.Show("ERROR");
                this.Close();
            }

            

            //traženje za NEPLAČENO
            try
            {
                string[] dirs = Directory.GetDirectories(put, "NEPLAČENO", SearchOption.AllDirectories);               
                foreach (string dir in dirs)
                {
                    int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                    count2 = count2 + fCount;
                    
                }
                listBox2.Items.Add(count2);

            }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }                     

         }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxUkupnoPlacene_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormSveukupno_Load(object sender, EventArgs e)
        {

        }
    }
}
