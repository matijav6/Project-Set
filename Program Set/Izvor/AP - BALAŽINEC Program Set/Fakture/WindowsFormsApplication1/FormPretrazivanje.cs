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
    public partial class FormPretrazivanje : Form
    {
        string put = System.IO.File.ReadAllText(Application.StartupPath + "\\Fakture\\PutFakture.txt");
        public FormPretrazivanje()
        {
            InitializeComponent();
            ucitavanje();
            listBox_placene.Sorted = true;
            

        }
        public void ucitavanje()
        {
            try
            {
                string[] dirs3 = Directory.GetDirectories(put, "PLAČENO", SearchOption.AllDirectories);
                foreach (string dir3 in dirs3)
                {

                    string[] files3 = Directory.GetFiles(dir3, "*.xlsx", SearchOption.AllDirectories);
                    foreach (string f3 in files3)
                    {
                        string ime3 = Path.GetFileNameWithoutExtension(f3);
                        listBox_placene.Items.Add(ime3);
                    }

                }

            }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }


            //traženje za NEPLAČENO
            try
            {
                string[] dirs4 = Directory.GetDirectories(put, "NEPLAČENO", SearchOption.AllDirectories);
                foreach (string dir4 in dirs4)
                {

                    string[] files4 = Directory.GetFiles(dir4, "*.xlsx", SearchOption.AllDirectories);
                    foreach (string f4 in files4)
                    {
                        string ime4 = Path.GetFileNameWithoutExtension(f4);
                        listBox_nePlacene.Items.Add(ime4);
                    }

                }


            }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }

            //dodavanje firma
            string[] firme = Directory.GetDirectories(put, "*", SearchOption.TopDirectoryOnly);
            foreach( string strFirme in firme)
            {
                listBox_firme.Items.Add(strFirme.Replace(put, ""));
            }         
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPoBrojuFakture_Load(object sender, EventArgs e)
        {

        }

        private void buttonUPlacene_Click(object sender, EventArgs e)
        {
            try
            {
                string oznaceno = Convert.ToString(listBox_nePlacene.SelectedItem);
                string ime;
                string full;
                string full3;
                string mov2;
                string gotovo;
                string[] dirs = Directory.GetDirectories(put, "NEPLAČENO", SearchOption.AllDirectories);
                foreach (string dir in dirs)
                {

                    string[] files = Directory.GetFiles(dir, oznaceno + ".xlsx", SearchOption.AllDirectories);
                    foreach (string f in files)
                    {
                        ime = Path.GetFullPath(f);
                        full = Path.GetFullPath(f);

                        gotovo = ime.Replace("NEPLAČENO", "PLAČENO");


                        mov2 = gotovo.Replace("\\", "\\\\");


                        full3 = full.Replace("\\", "\\\\");

                        if (Directory.Exists(mov2) == false)
                        {
                            string pom = dir.Replace("\\", "\\\\");
                            string pom1 = pom.Replace("NEPLAČENO", "PLAČENO");
                            DirectoryInfo kreiraj = new DirectoryInfo(pom1);
                            kreiraj.Create();
                        }
                        File.Move(full3, mov2);
                        MessageBox.Show("Uspješno prebačeno!", "obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listBox_placene.Items.Add(Path.GetFileNameWithoutExtension(f));
                        listBox_nePlacene.Items.Remove(Path.GetFileNameWithoutExtension(f));
                        goto kraj;
                    }

                }
            kraj:
                listBox_placene.Refresh();
                //listBox1.Items.Clear();
                //listBox2.Items.Clear();
                //ucitavanje();
            }
            catch
            {
                MessageBox.Show("Došlo je do greške prilikom prebacivanja!");
            }
            finally { }
        }

        private void buttonUNePlacene_Click(object sender, EventArgs e)
        {
            try
            {
                string oznaceno = Convert.ToString(listBox_placene.SelectedItem);
                string ime;
                string full;
                string full3;
                string mov2;
                string gotovo;
                string[] dirs = Directory.GetDirectories(put, "PLAČENO", SearchOption.AllDirectories);
                foreach (string dir in dirs)
                {

                    string[] files = Directory.GetFiles(dir, oznaceno + ".xlsx", SearchOption.AllDirectories);
                    foreach (string f in files)
                    {
                        ime = Path.GetFullPath(f);
                        full = Path.GetFullPath(f);

                        gotovo = ime.Replace("PLAČENO", "NEPLAČENO");


                        mov2 = gotovo.Replace("\\", "\\\\");


                        full3 = full.Replace("\\", "\\\\"); //postoji

                        if (Directory.Exists(mov2) == false)
                        {
                            string pom = dir.Replace("\\", "\\\\");
                            string pom1 = pom.Replace("PLAČENO", "NEPLAČENO");
                            DirectoryInfo kreiraj = new DirectoryInfo(pom1);
                            kreiraj.Create();
                        }

                        File.Move(full3, mov2);
                        MessageBox.Show("Uspješno prebačeno!", "obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listBox_nePlacene.Items.Add(Path.GetFileNameWithoutExtension(f));
                        listBox_placene.Items.Remove(Path.GetFileNameWithoutExtension(f));
                        goto kraj;
                    }
                }
            kraj:
                listBox_placene.Refresh();
                //listBox1.Items.Clear();
                //listBox2.Items.Clear();
                //ucitavanje();
            }
            catch
            {
                MessageBox.Show("Došlo je do greške prilikom prebacivanja!");
            }
            finally
            { }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string open = listBox_nePlacene.SelectedItem.ToString();
            string[] dirs = Directory.GetDirectories(put, "NEPLAČENO", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {

                string[] files = Directory.GetFiles(dir, open + ".xlsx", SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    string ime = Path.GetFullPath(f);
                    string open1 = ime.Replace("\\", "\\\\");
                    System.Diagnostics.Process.Start(open1);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string open = listBox_placene.SelectedItem.ToString();
            string[] dirs = Directory.GetDirectories(put, "PLAČENO", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {

                string[] files = Directory.GetFiles(dir, open + ".xlsx", SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    string ime = Path.GetFullPath(f);
                    string open1 = ime.Replace("\\", "\\\\");
                    System.Diagnostics.Process.Start(open1);
                }

            }
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void textBoxPlacene_TextChanged(object sender, EventArgs e)
        {
            listBox_placene.Items.Clear();
            try
            {
                string[] dirs3 = Directory.GetDirectories(put, "PLAČENO", SearchOption.AllDirectories);
                foreach (string dir3 in dirs3)
                {

                    string[] files3 = Directory.GetFiles(dir3, textBoxPlacene.Text +"*.xlsx", SearchOption.AllDirectories);
                    foreach (string f3 in files3)
                    {
                        string ime3 = Path.GetFileNameWithoutExtension(f3);
                        listBox_placene.Items.Add(ime3);
                    }

                }

            }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }
        }

        private void textBoxNePlacene_TextChanged(object sender, EventArgs e)
        {
            listBox_nePlacene.Items.Clear();
            try
            {
                string[] dirs4 = Directory.GetDirectories(put, "NEPLAČENO", SearchOption.AllDirectories);
                foreach (string dir4 in dirs4)
                {

                    string[] files4 = Directory.GetFiles(dir4, textBoxNePlacene.Text + "*.xlsx", SearchOption.AllDirectories);
                    foreach (string f4 in files4)
                    {
                        string ime4 = Path.GetFileNameWithoutExtension(f4);
                        listBox_nePlacene.Items.Add(ime4);
                    }

                }


            }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }                     
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox_placene.Items.Clear();
            listBox_nePlacene.Items.Clear();
            try
            {          
                    string[] files4 = Directory.GetFiles(put, textBox1.Text + "*.xlsx", SearchOption.AllDirectories);
                    foreach (string f4 in files4)
                    {
                    if (f4.Contains("\\PLAČENO\\"))
                    {
                        string ime4 = Path.GetFileNameWithoutExtension(f4);
                        listBox_placene.Items.Add(ime4);
                        buttonUNePlacene.Show();
                        buttonUPlacene.Hide();
                    }
                    if (f4.Contains("\\NEPLAČENO\\"))
                        {
                            string ime4 = Path.GetFileNameWithoutExtension(f4);
                            listBox_nePlacene.Items.Add(ime4);
                            buttonUNePlacene.Hide();
                            buttonUPlacene.Show();
                        }
                    }

                }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }
        }

        private void textBox_traziFirme_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int index = listBox_firme.FindString(textBox_traziFirme.Text, -1);
                if (index != -1)
                {
                    // Select the found item:
                    listBox_firme.SetSelected(index, true);
                }

            }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }
        }

        private void listBox_firme_DoubleClick(object sender, EventArgs e)
        {
            listBox_placene.Items.Clear();
            try
            {
                string[] dirs3 = Directory.GetDirectories(put + "\\" + listBox_firme.SelectedItem.ToString(), "PLAČENO", SearchOption.AllDirectories);
                foreach (string dir3 in dirs3)
                {

                    string[] files3 = Directory.GetFiles(dir3, "*.xlsx", SearchOption.AllDirectories);
                    foreach (string f3 in files3)
                    {
                        string ime3 = Path.GetFileNameWithoutExtension(f3);
                        listBox_placene.Items.Add(ime3);
                    }

                }

            }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }

            listBox_nePlacene.Items.Clear();
            try
            {
                string[] dirs4 = Directory.GetDirectories(put + "\\" + listBox_firme.SelectedItem.ToString(), "NEPLAČENO", SearchOption.AllDirectories);
                foreach (string dir4 in dirs4)
                {

                    string[] files4 = Directory.GetFiles(dir4,  "*.xlsx", SearchOption.AllDirectories);
                    foreach (string f4 in files4)
                    {
                        string ime4 = Path.GetFileNameWithoutExtension(f4);
                        listBox_nePlacene.Items.Add(ime4);
                    }

                }


            }
            catch
            {
                MessageBox.Show("ERROR");
                this.Close();
            }
        }
    }
}


