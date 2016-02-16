using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormApplication1
{
    public partial class FormPojedinacno : Form
    {
        string put = System.IO.File.ReadAllText(Application.StartupPath + "\\Fakture\\PutFakture.txt");
        public FormPojedinacno()
        {
            InitializeComponent();
            listBox7.Hide();
            string[] files = Directory.GetDirectories(put, "*", SearchOption.TopDirectoryOnly);
            foreach (string f in files)
            {
                string entry1 = Path.GetFullPath(f);
                string entry = Path.GetFileName(f);
                listBox5.Items.Add(entry);
            }

        }





        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPojedinacno_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox7.Hide();
            listBox7.Items.Clear();
            listBox8.Hide();
            listBox8.Items.Clear();
            if (Convert.ToString(listBox5.SelectedItem) == "BOXMARK----")
            {
                listBox6.Visible = true;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                listBox6.Items.Clear();
                listBox7.Items.Clear();
                listBox8.Items.Clear();

                int count1 = 0, count2 = 0;

                //traženje za PLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\", "PLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {

                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count1 = count1 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.AllDirectories);
                        foreach (string f in files)
                        {
                            string ime = Path.GetFileName(f);
                            listBox3.Items.Add(ime);
                        }

                    }

                    listBox1.Items.Add(count1);
                }
                catch
                {
                    listBox1.Items.Add("0");
                    listBox3.Items.Add("");

                }



                //traženje za NEPLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\", "NEPLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {
                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count2 = count2 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.TopDirectoryOnly);
                        foreach (string f in files)
                        {
                            string ime = Path.GetFileName(f);
                            listBox4.Items.Add(ime);
                        }
                    }


                    listBox2.Items.Add(count2);
                }
                catch
                {
                    listBox2.Items.Add("0");
                    listBox4.Items.Add("");

                }
                string[] file = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f in file)
                {
                    string entry1 = Path.GetFullPath(f);
                    string entry = Path.GetFileName(f);                    
                    listBox6.Items.Add(entry);
                }
                listBox6.Items.Remove("BOXMARK");
            }

            else
            {
                listBox6.Visible = true;
                listBox7.Hide();
                listBox8.Hide();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                listBox6.Items.Clear();
                listBox7.Items.Clear();
               // listBox8.Items.Clear();

                int count1 = 0, count2 = 0;

                //traženje za PLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\", "PLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {

                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count1 = count1 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.AllDirectories);
                        foreach (string f1 in files)
                        {
                            string ime = Path.GetFileName(f1);
                            listBox3.Items.Add(ime);
                        }

                    }

                    listBox1.Items.Add(count1);
                }
                catch
                {
                    listBox1.Items.Add("0");
                    listBox3.Items.Add("");

                }



                //traženje za NEPLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\", "NEPLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {
                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count2 = count2 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.TopDirectoryOnly);
                        foreach (string f1 in files)
                        {
                            string ime = Path.GetFileName(f1);
                            listBox4.Items.Add(ime);
                        }
                    }


                    listBox2.Items.Add(count2);
                }
                catch
                {
                    listBox2.Items.Add("0");
                    listBox4.Items.Add("");

                }
                string[] file = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f in file)
                {
                    string entry1 = Path.GetFullPath(f);
                    string entry = Path.GetFileName(f);
                    listBox6.Items.Add(entry);
                }
            }
        }
        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(listBox5.SelectedItem) == "BOXMARK----")
            {

                string[] file = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f in file)
                {
                    string entry1 = Path.GetFullPath(f);
                    string entry = Path.GetFileName(f);                    
                    listBox7.Items.Add(entry);

                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox4.Items.Clear();

                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox4.Items.Clear();


                    int count1 = 0, count2 = 0;

                    //traženje za PLAČENO
                    try
                    {
                        string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\", listBox6.SelectedItem + "\\PLAČENO", SearchOption.AllDirectories);

                        foreach (string dir in dirs)
                        {

                            int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                            count1 = count1 + fCount;

                            string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.AllDirectories);
                            foreach (string fa in files)
                            {
                                string ime = Path.GetFileName(fa);
                                listBox3.Items.Add(ime);
                            }

                        }

                        listBox1.Items.Add(count1);
                    }
                    catch
                    {
                        listBox1.Items.Add("0");
                        listBox3.Items.Add("");

                    }



                    //traženje za NEPLAČENO
                    try
                    {
                        string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\", listBox6.SelectedItem + "\\NEPLAČENO", SearchOption.AllDirectories);

                        foreach (string dir in dirs)
                        {
                            int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                            count2 = count2 + fCount;

                            string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.TopDirectoryOnly);
                            foreach (string fb in files)
                            {
                                string ime = Path.GetFileName(fb);
                                listBox4.Items.Add(ime);
                            }
                        }


                        listBox2.Items.Add(count2);
                    }
                    catch
                    {
                        listBox2.Items.Add("0");
                        listBox4.Items.Add("");

                    }

                    listBox7.Visible = true;
                }
                

            }
            else
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();


                int count1 = 0, count2 = 0;

                //traženje za PLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\", listBox6.SelectedItem + "\\PLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {

                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count1 = count1 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.AllDirectories);
                        foreach (string f in files)
                        {
                            string ime = Path.GetFileName(f);
                            listBox3.Items.Add(ime);
                        }

                    }

                    listBox1.Items.Add(count1);
                }
                catch
                {
                    listBox1.Items.Add("0");
                    listBox3.Items.Add("");

                }



                //traženje za NEPLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\", listBox6.SelectedItem + "\\NEPLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {
                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count2 = count2 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.TopDirectoryOnly);
                        foreach (string f in files)
                        {
                            string ime = Path.GetFileName(f);
                            listBox4.Items.Add(ime);
                        }
                    }


                    listBox2.Items.Add(count2);
                }
                catch
                {
                    listBox2.Items.Add("0");
                    listBox4.Items.Add("");

                }
                string[] file = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                foreach (string f in file)
                {
                    string entry1 = Path.GetFullPath(f);
                    string entry = Path.GetFileName(f);
                    listBox8.Items.Add(entry);
                    listBox6.Hide();
                    listBox8.Visible = true;
                }
            }
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            int count1 = 0, count2 = 0;

            //traženje za PLAČENO
            try
            {
                string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem + "\\", listBox7.SelectedItem + "\\PLAČENO", SearchOption.AllDirectories);

                foreach (string dir in dirs)
                {
                    
                    int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                    count1 = count1 + fCount;

                    string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.AllDirectories);
                    foreach (string f1 in files)
                    {
                        string ime = Path.GetFileName(f1);
                        listBox3.Items.Add(ime);
                    }

                }

                listBox1.Items.Add(count1);
               
            }
            catch
            {
                listBox1.Items.Add("0");
                listBox3.Items.Add("");

            }



            //traženje za NEPLAČENO
            try
            {
                string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem, listBox7.SelectedItem + "\\NEPLAČENO", SearchOption.AllDirectories);

                foreach (string dir in dirs)
                {
                    int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                    count2 = count2 + fCount;

                    string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.TopDirectoryOnly);
                    foreach (string f2 in files)
                    {
                        string ime = Path.GetFileName(f2);
                        listBox4.Items.Add(ime);
                    }
                }


                listBox2.Items.Add(count2);
            }
            catch
            {
                listBox2.Items.Add("0");
                listBox4.Items.Add("");

            }
           /* string[] file = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem+"\\"+listBox7.SelectedItem, "*", SearchOption.TopDirectoryOnly);
            foreach (string f in file)
            {
                string entry1 = Path.GetFullPath(f);
                string entry = Path.GetFileName(f);
                listBox8.Items.Add(entry);
                listBox6.Hide();
                listBox8.Visible = true;
            }*/
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  if (Convert.ToString(listBox5.SelectedItem) == "BOXMARK----")
            {

                string[] file = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem + "\\" + listBox7.SelectedItem + "\\" + listBox8.SelectedItem, "*", SearchOption.TopDirectoryOnly);
                
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
               // listBox6.Items.Clear();
                //listBox7.Items.Clear();
               // listBox8.Items.Clear();
                listBox8.Items.Add("listbox8");
                int count1 = 0, count2 = 0;

                //traženje za PLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem + "\\" + listBox7.SelectedItem + "\\" , listBox8.SelectedItem+"\\PLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {

                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count1 = count1 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.AllDirectories);
                        foreach (string f in files)
                        {
                            string ime = Path.GetFileName(f);
                            listBox3.Items.Add(ime);
                        }

                    }

                    listBox1.Items.Add(count1);
                }
                catch
                {
                    listBox1.Items.Add("0");
                    listBox3.Items.Add("");

                }



                //traženje za NEPLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem + "\\" + listBox7.SelectedItem + "\\"  , listBox8.SelectedItem+"\\NEPLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {
                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count2 = count2 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.TopDirectoryOnly);
                        foreach (string f in files)
                        {
                            string ime = Path.GetFileName(f);
                            listBox4.Items.Add(ime);
                        }
                    }


                    listBox2.Items.Add(count2);
                }
                catch
                {
                    listBox2.Items.Add("0");
                    listBox4.Items.Add("");

                }

            }*/
            //else
           // {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();


                int count1 = 0, count2 = 0;

                //traženje za PLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem + "\\" ,  listBox8.SelectedItem+"\\PLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {

                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count1 = count1 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.AllDirectories);
                        foreach (string f in files)
                        {
                            string ime = Path.GetFileName(f);
                            listBox3.Items.Add(ime);
                        }

                    }

                    listBox1.Items.Add(count1);
                }
                catch
                {
                    listBox1.Items.Add("0");
                    listBox3.Items.Add("");

                }



                //traženje za NEPLAČENO
                try
                {
                    string[] dirs = Directory.GetDirectories(put + "\\" + listBox5.SelectedItem + "\\" + listBox6.SelectedItem + "\\" , listBox8.SelectedItem + "\\NEPLAČENO", SearchOption.AllDirectories);

                    foreach (string dir in dirs)
                    {
                        int fCount = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Length;
                        count2 = count2 + fCount;

                        string[] files = Directory.GetFiles(dir, "*.xlsx", SearchOption.TopDirectoryOnly);
                        foreach (string f in files)
                        {
                            string ime = Path.GetFileName(f);
                            listBox4.Items.Add(ime);
                        }
                    }


                    listBox2.Items.Add(count2);
                }
                catch
                {
                    listBox2.Items.Add("0");
                    listBox4.Items.Add("");

                }
            //}




        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          
            try
            {
                string[] files = Directory.GetFiles(put, listBox3.SelectedItem.ToString(), SearchOption.AllDirectories);
                foreach (string f in files)
                {

                    string open1 = f.Replace("\\", "\\\\");
                    System.Diagnostics.Process.Start(open1);
                }
            }
            catch
            {
                MessageBox.Show("Označite fakturu!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = Directory.GetFiles(put, listBox4.SelectedItem.ToString(), SearchOption.AllDirectories);
                foreach (string f in files)
                {

                    string open1 = f.Replace("\\", "\\\\");
                    System.Diagnostics.Process.Start(open1);
                }
            }
            catch
            {
                MessageBox.Show("Označite fakturu!");
            }
        }
    }
}
