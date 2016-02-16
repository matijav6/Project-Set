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
    public partial class FormIzmjena : Form
    {
        string put = System.IO.File.ReadAllText(Application.StartupPath + "\\Fakture\\PutFakture.txt");        

        public FormIzmjena()
        {
            InitializeComponent();
            listBox4.Hide();
            listBox2.Hide();
            listBox5.Hide();

            string[] files = Directory.GetDirectories(put, "*", SearchOption.TopDirectoryOnly);
            foreach (string f in files)
            {
                string entry1 = Path.GetFullPath(f);
                string entry = Path.GetFileName(f);
                listBox1.Items.Add(entry);
            }              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox4.Hide();
            listBox4.Items.Clear();
            if (Convert.ToString(listBox1.SelectedItem) == "BOXMARK----")
            {
                listBox4.Show();

                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                listBox5.Items.Clear();
                button2.Enabled = true;
                button3.Enabled = true;

                string[] files1 = Directory.GetDirectories(put + "\\" + listBox1.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f1 in files1)
                {
                    string entry11 = Path.GetFullPath(f1);
                    string entry1 = Path.GetFileName(f1);
                    listBox4.Items.Add(entry1);
                }

                listBox4.Items.Remove("BOXMARK");

            }
            else
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                button2.Enabled = true;
                button3.Enabled = true;

                string[] files1 = Directory.GetDirectories(put + "\\" + listBox1.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f1 in files1)
                {
                    string entry11 = Path.GetFullPath(f1);
                    string entry1 = Path.GetFileName(f1);
                    listBox4.Show();
                    listBox4.Items.Add(entry1);

                }
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            if (Convert.ToString(listBox1.SelectedItem) == "BOXMARK----")
            {
                listBox2.Hide();
                string[] files1 = Directory.GetDirectories(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f1 in files1)
                {
                    string entry11 = Path.GetFullPath(f1);
                    string entry1 = Path.GetFileName(f1);
                    listBox5.Show();
                    listBox5.Items.Add(entry1);

                }

            }
            else
            {
                listBox2.Hide();
                string[] files1 = Directory.GetDirectories(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f1 in files1)
                {
                    string entry11 = Path.GetFullPath(f1);
                    string entry1 = Path.GetFileName(f1);
                    listBox5.Show();
                    listBox5.Items.Add(entry1);

                }
            }
            }
            

        

        private void button2_Click(object sender, EventArgs e)
        {


            if (Convert.ToString(listBox1.SelectedItem) == "BOXMARK----")
            {
                if (put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem + "\\" + listBox3.SelectedItem == put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + "PLAČENO" + "\\" + listBox3.SelectedItem)
                {
                    MessageBox.Show("FAKTURA S ISTIM IMENOM VEĆ POSTOJI!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string putNe = put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem + "\\" ;
                    string putDa = put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + "PLAČENO" + "\\";

                    if (Directory.Exists(putDa) == false)
                    {
                        DirectoryInfo kreiraj = new DirectoryInfo(putDa);
                        kreiraj.Create();
                    }
                    File.Move(putNe + listBox3.SelectedItem, putDa + listBox3.SelectedItem);
                }

                listBox3.Items.Clear();
                string[] files = Directory.GetFiles(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem +"\\"+ listBox2.SelectedItem, "*.xlsx", SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    string ime = Path.GetFileName(f);
                    listBox3.Items.Add(ime);
                }

                MessageBox.Show("Uspješno prebačeno", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }


            else
            {
                string putNe = put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem + "\\";
                string putDa = put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + "PLAČENO" + "\\";
                if (Directory.Exists(putDa) == false)
                {
                    DirectoryInfo kreiraj = new DirectoryInfo(putDa);
                    kreiraj.Create();
                }
                File.Move( putNe + listBox3.SelectedItem, putDa + listBox3.SelectedItem);

                listBox3.Items.Clear();
                string[] files = Directory.GetFiles(putDa, "*.xlsx", SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    string ime = Path.GetFileName(f);
                    listBox3.Items.Add(ime);
                }

                MessageBox.Show("Uspješno prebačeno", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            if (Convert.ToString(listBox1.SelectedItem) == "BOXMARK----")
            {
                File.Move(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem + "\\" + listBox3.SelectedItem, put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + "NEPLAČENO" + "\\" + listBox3.SelectedItem);

                listBox3.Items.Clear();
                string[] files = Directory.GetFiles(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem, "*.xlsx", SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    string ime = Path.GetFileName(f);
                    listBox3.Items.Add(ime);
                }

                MessageBox.Show("Uspješno prebačeno", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                string putA=put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem + "\\" + listBox3.SelectedItem;
                string putB = put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + "NEPLAČENO" + "\\" + listBox3.SelectedItem;
               
                if ( putA==putB )
                {
                    MessageBox.Show("FAKTURA S ISTIM IMENOM VEĆ POSTOJI!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string putDa = put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem + "\\";
                    string putNe = put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + "NEPLAČENO" + "\\";
                    if (Directory.Exists(putNe) == false)
                    {
                        DirectoryInfo kreiraj = new DirectoryInfo(putNe);
                        kreiraj.Create();
                    }
                    File.Move( putDa + listBox3.SelectedItem, putNe + listBox3.SelectedItem);

                    listBox3.Items.Clear();
                    string[] files = Directory.GetFiles(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem, "*.xlsx", SearchOption.AllDirectories);
                    foreach (string f in files)
                    {
                        string ime = Path.GetFileName(f);
                        listBox3.Items.Add(ime);
                    }
                }
                MessageBox.Show("Uspješno prebaćeno", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    

        private void FormIzmjena_Load(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox5.Items.Clear();
            listBox5.Hide();
            button2.Enabled = true;
            button3.Enabled = true;
            if (Convert.ToString(listBox1.SelectedItem) == "BOXMARK----")
            {
                string[] files1 = Directory.GetDirectories(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f1 in files1)
                {
                    string entry11 = Path.GetFullPath(f1);
                    string entry1 = Path.GetFileName(f1);
                    listBox2.Items.Add(entry1);
                    listBox2.Show();
                }
                
            }
            else
            {
                listBox2.Visible = true;
                string[] files1 = Directory.GetDirectories(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f1 in files1)
                {
                    string entry11 = Path.GetFullPath(f1);
                    string entry1 = Path.GetFileName(f1);
                    listBox2.Items.Add(entry1);
                }
                
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            if (Convert.ToString(listBox1.SelectedItem) == "BOXMARK----")
            {
                if (Convert.ToString(listBox5.SelectedItem) == "PLAČENO" || Convert.ToString(listBox5.SelectedItem) == "NEPLAČENO")
                {
                   
                    string[] dirs = Directory.GetFiles(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem, "*.xlsx", SearchOption.AllDirectories);
                   
                    foreach (string dir in dirs)
                    {                                               
                            string ime = Path.GetFileName(dir);
                            listBox3.Items.Add(ime);
                        

                    }



                }
                else MessageBox.Show("Označite jedno polje!", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                if (Convert.ToString(listBox5.SelectedItem) == "PLAČENO")
                {
                    button2.Enabled = false;
                    button3.Enabled = true;
                }
                else
                {
                    button2.Enabled = true;
                    button3.Enabled = false;
                }

            }


            else
            {
                if (Convert.ToString(listBox5.SelectedItem) == "PLAČENO" || Convert.ToString(listBox5.SelectedItem) == "NEPLAČENO")
                 {

                     string[] files = Directory.GetFiles(put + "\\" + listBox1.SelectedItem + "\\" + listBox4.SelectedItem + "\\" + listBox2.SelectedItem + "\\" + listBox5.SelectedItem, "*.xlsx", SearchOption.AllDirectories);
                     foreach (string f in files)
                     {
                         string ime = Path.GetFileName(f);
                         listBox3.Items.Add(ime);
                     }



                 }
                 else MessageBox.Show("Označite jedno polje!", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                
                 if (Convert.ToString(listBox5.SelectedItem) == "PLAČENO")
                 {
                     button2.Enabled = false;
                     button3.Enabled = true;
                 }
                 else
                 {
                     button2.Enabled = true;
                     button3.Enabled = false;
                 }

            }
            
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
