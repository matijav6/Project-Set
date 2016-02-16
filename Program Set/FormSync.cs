using System;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;
using System.Linq;

namespace Program_Set
{
    public partial class FormSync : Form
    {
        public FormSync()
        {
            InitializeComponent();
            comboBox2.Hide();
            label4.Hide();
        }
        private void FormSync_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Application.StartupPath + "\\tmp", "*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string ime = Path.GetFileNameWithoutExtension(file);
                listBox1.Items.Add(ime);
            }

            DirectoryEntry root = new DirectoryEntry("WinNT:");
            foreach (DirectoryEntry computers in root.Children)
            {
                foreach (DirectoryEntry computer in computers.Children)
                {
                    if (computer.Name != "Schema")
                    {
                        comboBox1.Items.Add(computer.Name);
                        comboBox2.Items.Add(computer.Name);
                    }
                }
            }
        }
        private void buttonIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        string RemotePath;
        int p = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Niste odabrali udaljeno računalo!");
                goto end;
            }
            if (comboBox1.SelectedItem != null)
            {
                RemotePath = "\\\\" + comboBox1.SelectedItem.ToString() + "\\";

            }
        pocetak:
            foreach (string put in listBox1.Items)
            {
                string LocalPath = System.IO.File.ReadAllText(Application.StartupPath + "\\tmp\\" + put + ".txt");
                if (Directory.Exists(LocalPath.Replace("\\\\", "\\")) == false)
                {
                    File.Delete(Application.StartupPath + "\\tmp\\" + put + ".txt");
                }

                if (LocalPath.Contains("Vozila"))
                {
                    try
                    {
                        string RemoteKombi = System.IO.File.ReadAllText(Application.StartupPath + "\\RemoteKombi.txt");
                        //MessageBox.Show("Vozila");
                        File.Copy(LocalPath.Replace("\\\\", "\\"), RemotePath + RemoteKombi + put + ".mdb", true);

                        if (listBox1.Items.Count == 0) break;
                    }
                    catch
                    {
                        File.Delete(Application.StartupPath + "\\tmp\\" + put + ".txt");
                    }
                    finally
                    {
                    }
                }
                if (LocalPath.Contains("RASPORED") || LocalPath.Contains("Raspored"))
                {
                    try
                    {
                        if (put == "ZadnjiRaspored")
                        {
                            try
                            {
                                string RemoteRasporedZadnji = System.IO.File.ReadAllText(Application.StartupPath + "\\RemotePonuda.txt");
                                MessageBox.Show(Application.StartupPath + "\\ZadnjiRaspored.txt");
                                MessageBox.Show(RemotePath + RemoteRasporedZadnji + "\\ZadnjiRaspored.txt");
                                File.Copy(Application.StartupPath + "\\ZadnjiRaspored.txt", RemotePath + RemoteRasporedZadnji + "\\ZadnjiRaspored.txt", true);
                                if (listBox1.Items.Count == 0) break;
                            }
                            catch
                            {
                                File.Delete(Application.StartupPath + "\\tmp\\" + put + ".txt");
                            }
                            finally
                            {
                            }
                        }
                        else
                        {
                            string RemoteRaspored = System.IO.File.ReadAllText(Application.StartupPath + "\\RemoteRaspored.txt");
                            foreach (string newPath in Directory.GetFiles(LocalPath.Replace("\\\\", "\\"), "*.*",
                                   SearchOption.AllDirectories))
                                File.Copy(newPath, newPath.Replace(LocalPath.Replace("\\\\", "\\"), RemotePath + RemoteRaspored), true);
                        }
                        if (listBox1.Items.Count == 0) break;

                    }
                    catch
                    {
                        File.Delete(Application.StartupPath + "\\tmp\\" + put + ".txt");
                    }
                    finally
                    {
                    }
                }
                if (LocalPath.Contains("FAKTURE") || LocalPath.Contains("Fakture"))
                {
                    try
                    {
                        string pom = (File.ReadAllText("PutFakture.txt")).Replace("\\\\", "\\");
                        string a = LocalPath.Replace("\\\\", "\\");
                        string Remote = a.Replace(pom, "");
                        string RemoteFakture = System.IO.File.ReadAllText(Application.StartupPath + "\\RemoteFakture.txt");

                        String FinalRemote = RemotePath + RemoteFakture + Remote;
                        if (Directory.Exists(FinalRemote))
                        {
                            File.Copy(LocalPath.Replace("\\\\", "\\"), FinalRemote, true);
                            //MessageBox.Show("LOCAL     " + LocalPath.Replace("\\\\", "\\"));
                            //MessageBox.Show("REMOTE     " + FinalRemote);
                        }
                        else
                        {
                            string dir = Path.GetDirectoryName(FinalRemote);
                            Directory.CreateDirectory(dir);
                            //MessageBox.Show("Fakture");
                            File.Copy(LocalPath.Replace("\\\\", "\\"), FinalRemote, true);

                            //MessageBox.Show("LOCAL     " + LocalPath.Replace("\\\\", "\\"));
                            //MessageBox.Show("REMOTE     " + FinalRemote);
                        }
                        if (listBox1.Items.Count == 0) break;

                    }
                    catch
                    {
                        File.Delete(Application.StartupPath + "\\tmp\\" + put + ".txt");

                    }
                    finally
                    {
                    }
                }

                bool pomBrisanje = false;
                if (put.Contains("Ponuda"))
                {
                    if (put.Contains("PonudaBrisanje"))
                    {
                        pomBrisanje = true;
                    }
                    try
                    {
                        string RemotePonuda = System.IO.File.ReadAllText(Application.StartupPath + "\\RemotePonuda.txt");
                        string LocalPathPonuda = Application.StartupPath + "\\DataBase.mdb";

                        //sinkronizacija
                        if (pomBrisanje == true)
                        {
                            //treba popraviti!!

                            ////File.Copy(RemotePath + RemotePonuda, Application.StartupPath + "\\DataBaseTMP.mdb", true);
                            //string[] Brisanje = LocalPath.Split('|');
                            //int brojac = 0;
                            //foreach (string varijable in Brisanje)
                            //{
                            //    brojac++;
                            //    if (brojac == 1)
                            //    {
                            //        FirmaBrisanje = varijable;
                            //    }
                            //    if (brojac == 2)
                            //    {
                            //        RelacijOdBrisanje = varijable;
                            //    }
                            //    if (brojac == 3)
                            //    {
                            //        RelacijaDoBrisanje = varijable;
                            //    }
                            //    if (brojac == 4)
                            //    {
                            //        CijenaBrisanje = varijable;
                            //    }
                            //    if (brojac == 5)
                            //    {
                            //        NapomenaBrisanje = varijable;
                            //    }
                            //}
                            //string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + "\\DataBase.mdb";

                            ////klase za povezivanje na ACCESS bazu podataka//
                            //OleDbConnection conn = new OleDbConnection(connString);
                            //conn.Open();                       //otvara spoj s bazom podataka
                            //OleDbCommand brisanje = new OleDbCommand("DELETE * FROM sve " +
                            //    "WHERE Firma LIKE '" + FirmaBrisanje + "' AND Pocetak LIKE '" + RelacijOdBrisanje, conn);
                            //brisanje.ExecuteNonQuery();
                            //conn.Close();

                        }
                        else
                        {
                            // uzimanje vrijednosti s lokalne baze
                            //++++++++++++++++++++++++++++++++++++++++++++\\
                            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DataBase.mdb";
                            //----------SQL instrukcija-----------\\
                            string sql = "SELECT * FROM sve WHERE ID =" + LocalPath;

                            //klase za povezivanje na ACCESS bazu podataka//
                            OleDbConnection conn = new OleDbConnection(connString);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

                            DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                            conn.Open();                        //otvara spoj s bazom podataka

                            adapter.Fill(ds, "sve");       //puni se DataSet s podacima tabele t_razred
                            conn.Close();                       //zatvara se baza podataka

                            //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                            dataGridView1.DataSource = ds;      //upisivanje podataka id ds u dataGridView2
                            dataGridView1.DataMember = "sve";

                            dataGridView1.Rows[0].Selected = true;

                            DataGridViewRow dr = dataGridView1.SelectedRows[0];
                            string firma = dr.Cells[1].Value.ToString();
                            string RelacijaOd = dr.Cells[2].Value.ToString();
                            string RelacijaDo = dr.Cells[3].Value.ToString();
                            string CijenaGoriva = dr.Cells[4].Value.ToString();
                            string Cestarina = dr.Cells[5].Value.ToString();
                            string Trajekt = dr.Cells[6].Value.ToString();
                            string Vozac = dr.Cells[7].Value.ToString();
                            string Nama = dr.Cells[8].Value.ToString();
                            string UkupnaCijena = dr.Cells[9].Value.ToString();
                            string UkupnoKilometri = dr.Cells[10].Value.ToString();
                            string Napomene = dr.Cells[11].Value.ToString();
                            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++\\

                            //spremanje u udaljenu bazu
                            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\\
                            string connStringRemote = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + RemotePath + RemotePonuda;

                            //----------SQL instrukcija-----------\\
                            string sqlRemote = "SELECT * FROM sve";

                            //klase za povezivanje na ACCESS bazu podataka//
                            OleDbConnection connRemote = new OleDbConnection(connStringRemote);
                            OleDbDataAdapter adapterRemote = new OleDbDataAdapter(sqlRemote, connRemote);
                            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
                            connRemote.Open();
                            string inDB = "INSERT INTO sve (Firma,Pocetak,Zavrsetak,Gorivo,Cestarina,Trajekt,Vozac,Nama,Ukupna_Cijena,Ukupno_KM,Napomene) " +
                                                          "VALUES ('" + firma + "','" + RelacijaOd + "','" + RelacijaDo + "'," + CijenaGoriva + "," + Cestarina + "," + Trajekt + "," + Vozac + "," + Nama + "," + UkupnaCijena + "," + UkupnoKilometri + ",'" + Napomene + "')";



                            OleDbCommand upis = new OleDbCommand(inDB, connRemote);
                            upis.ExecuteNonQuery();
                            connRemote.Close();

                        }
                        if (listBox1.Items.Count == 0) break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                if (p == 1) goto end;
                if (comboBox2.SelectedItem != null)
                {
                    RemotePath = "\\\\" + comboBox2.SelectedItem.ToString() + "\\";
                    p = 1;
                    goto pocetak;

                }

                string[] files = Directory.GetFiles(Application.StartupPath + "\\tmp", "*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    string ime = Path.GetFileName(file);
                    File.Delete(Application.StartupPath + "\\tmp\\" + ime);
                }
            }
                MessageBox.Show("Sinkronizacija završena!");

            end:
                listBox1.Refresh();
                button1.Show();
            
        }

        private void comboBox2_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           comboBox2.Show();
            label4.Show();
        }
    }

}
