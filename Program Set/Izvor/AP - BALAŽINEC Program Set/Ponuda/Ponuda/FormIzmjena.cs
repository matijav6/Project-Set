using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Globalization;

namespace Ponuda
{
    public partial class FormIzmjena : Form
    {
        public FormIzmjena()
        {
            InitializeComponent();
        }
        int i = 0;
        int ponuda = 0;

        public void Velicina()
        {
            this.Height = 601;
            this.Width = 1501;

            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Show();
            labelValuta.Hide();
            labelKlik.Hide();

            textBoxCestarina.Hide();
            textBoxCijenaGoriva.Hide();
            textBoxNama.Hide();
            textBoxTrajekt.Hide();
            textBoxVozac.Hide();
            textBoxUkupnaCijena.Hide();
            textBoxUkupnoKm.Hide();
            textBoxFirma.Hide();
            textBoxRelacijaDo.Hide();
            textBoxRelacijaOd.Hide();
            textBoxEur.Hide();
            textBoxNapomene.Hide();

            SpremanjeUBazu.Hide();
            Povratak.Hide();
            buttonracunaj.Hide();
            buttonUpute.Hide();

            dataGridView2.Show();
            buttonOdaberi.Show();
            
        }
        string PutBaze;
        public void ucitavanje()
        {           

             PutBaze = File.ReadAllText(Application.StartupPath + "\\Ponuda\\BazaPonuda.txt");

            dataGridView2.ClearSelection();

            if (File.Exists(@"privPonuda.txt"))
            {
                string PutKriterij = System.IO.File.ReadAllText(@"privPonuda.txt");

                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                //----------SQL instrukcija-----------\\

                string sql = "SELECT * FROM sve WHERE Firma LIKE '" + PutKriterij + "%'";

                //klase za povezivanje na ACCESS bazu podataka//
                OleDbConnection conn = new OleDbConnection(connString);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

                DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                conn.Open();                        //otvara spoj s bazom podataka

                adapter.Fill(ds, "sve");       //puni se DataSet s podacima tabele t_razred
                conn.Close();                       //zatvara se baza podataka

                //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                dataGridView2.DataSource = ds;      //upisivanje podataka id ds u dataGridView2
                dataGridView2.DataMember = "sve";
                ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");


                goto kraj;
            }
            if (File.Exists(@"privOd.txt"))
            {
                dataGridView2.ClearSelection();
                string PutOd = System.IO.File.ReadAllText(@"privOd.txt");

                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                //----------SQL instrukcija-----------\\

                string sql = "SELECT * FROM sve WHERE Pocetak LIKE '" + PutOd + "%'";

                //klase za povezivanje na ACCESS bazu podataka//
                OleDbConnection conn = new OleDbConnection(connString);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

                DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                conn.Open();                        //otvara spoj s bazom podataka

                adapter.Fill(ds, "sve");       //puni se DataSet s podacima tabele t_razred
                conn.Close();                       //zatvara se baza podataka

                //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                dataGridView2.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
                dataGridView2.DataMember = "sve";
                ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
                

                goto kraj;

            }

            if (File.Exists(@"privDo.txt"))
            {
                dataGridView2.ClearSelection();
                string PutDo = System.IO.File.ReadAllText(@"privDo.txt");

                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                //----------SQL instrukcija-----------\\

                string sql = "SELECT * FROM sve WHERE Zavrsetak LIKE '" + PutDo + "%'";

                //klase za povezivanje na ACCESS bazu podataka//
                OleDbConnection conn = new OleDbConnection(connString);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

                DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                conn.Open();                        //otvara spoj s bazom podataka

                adapter.Fill(ds, "sve");       //puni se DataSet s podacima tabele t_razred
                conn.Close();                       //zatvara se baza podataka

                //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                dataGridView2.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
                dataGridView2.DataMember = "sve";
                ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");


                goto kraj;
            }

            else
            {
                dataGridView2.ClearSelection();
                string PutOd = System.IO.File.ReadAllText(@"privOd.txt");
                string PutDo = System.IO.File.ReadAllText(@"privDo.txt");
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                //----------SQL instrukcija-----------\\

                string sql = "SELECT * FROM sve WHERE Pocetak LIKE '" + PutOd + "%' AND WHERE Zavrsetak LIKE '" + PutDo + "%'";

                //klase za povezivanje na ACCESS bazu podataka//
                OleDbConnection conn = new OleDbConnection(connString);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

                DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                conn.Open();                        //otvara spoj s bazom podataka

                adapter.Fill(ds, "sve");       //puni se DataSet s podacima tabele t_razred
                conn.Close();                       //zatvara se baza podataka

                //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                dataGridView2.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
                dataGridView2.DataMember = "sve";
                ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");

                goto kraj;



            }

        kraj:
            System.IO.File.WriteAllText(@"a.txt", "1");
            System.IO.File.Delete(@"a.txt");

        }

        private void FormIzmjena_Load(object sender, EventArgs e)
        {
           
            Velicina();
            ucitavanje();
            this.dataGridView2.Sort(firmaDataGridViewTextBoxColumn, ListSortDirection.Ascending);
            
        }

        private void buttonOdaberi_Click(object sender, EventArgs e)
        {          

            
                DataGridViewRow dr = dataGridView2.SelectedRows[0];
                textBoxFirma.Text = dr.Cells[1].Value.ToString();
                textBoxRelacijaOd.Text = dr.Cells[2].Value.ToString();
                textBoxRelacijaDo.Text = dr.Cells[3].Value.ToString();
                textBoxCijenaGoriva.Text = dr.Cells[4].Value.ToString();
                textBoxCestarina.Text = dr.Cells[5].Value.ToString();
                textBoxTrajekt.Text = dr.Cells[6].Value.ToString();
                textBoxVozac.Text = dr.Cells[7].Value.ToString();
                textBoxNama.Text = dr.Cells[8].Value.ToString();
                textBoxUkupnaCijena.Text = dr.Cells[9].Value.ToString();
                textBoxUkupnoKm.Text = dr.Cells[10].Value.ToString();
                textBoxNapomene.Text = dr.Cells[11].Value.ToString();

                dataGridView2.Hide();
                buttonOdaberi.Hide();

                this.Height = 416;
                this.Width = 921;

                this.Height = 409;
                this.Width = 891;

                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
                label9.Show();
                label10.Show();
                label11.Show();
                label12.Show();
                label13.Show();
                label14.Hide();

                if (textBoxEur.Text.Length != 0)
                {
                    labelValuta.Hide();
                    labelKlik.Show();
                }
                if (textBoxEur.Text.Length == 0) labelValuta.Show();

                textBoxCestarina.Show();
                textBoxCijenaGoriva.Show();
                textBoxNama.Show();
                textBoxTrajekt.Show();
                textBoxVozac.Show();
                textBoxUkupnaCijena.Show();
                textBoxUkupnoKm.Show();
                textBoxFirma.Show();
                textBoxRelacijaDo.Show();
                textBoxRelacijaOd.Show();
                textBoxEur.Show();
                textBoxNapomene.Show();

              //  SpremanjeUBazu.Show();
                buttonracunaj.Show();
                Povratak.Show();
                buttonUpute.Show();
                buttonPovratak.Hide();
            
        }

        private void Povratak_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(@"privOd.txt");
            System.IO.File.Delete(@"privDo.txt");
            System.IO.File.Delete(@"privPonuda.txt");

            System.IO.File.WriteAllText(@"privPonuda.txt", textBoxFirma.Text.ToString());
            System.IO.File.WriteAllText(@"privOd.txt", textBoxRelacijaOd.Text.ToString());
            System.IO.File.WriteAllText(@"privDo.txt", textBoxRelacijaDo.Text.ToString());

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    textBox.Clear();

                }
            }
            ponuda = 0;
            textBoxCestarina.Clear();
            textBoxCijenaGoriva.Clear();
            textBoxNama.Clear();
            textBoxTrajekt.Clear();
            textBoxVozac.Clear();
            textBoxUkupnaCijena.Clear();
            textBoxUkupnoKm.Clear();
            textBoxFirma.Clear();
            textBoxRelacijaDo.Clear();
            textBoxRelacijaOd.Clear();
            textBoxNapomene.Clear();
            buttonPovratak.Show();

            ucitavanje();
            Velicina();           

            
        }
        
        private void SpremanjeUBazu_Click(object sender, EventArgs e)
        {
            if (ponuda == 0)
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                //----------SQL instrukcija-----------\\
                string sql = "SELECT * FROM sve";

                //klase za povezivanje na ACCESS bazu podataka//
                OleDbConnection conn = new OleDbConnection(connString);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                conn.Open();                       //otvara spoj s bazom podataka


                string poc = textBoxRelacijaOd.Text;
                string ciljj = textBoxRelacijaDo.Text;
                string firme = textBoxFirma.Text;

                if (textBoxNapomene.Text.Length == 0)
                {
                    textBoxNapomene.Text = "-";
                }

                if (textBoxEur.Text.Length == 0)
                {
                    MessageBox.Show("Niste unijeli valutu eura!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto kraj;
                }

                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox textBox = c as TextBox;
                        if (textBox.Text == string.Empty)
                        {
                            MessageBox.Show("Niste popunili sva polja potrebna za unos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto kraj;
                        }
                    }
                }

                decimal a = Convert.ToDecimal(textBoxCestarina.Text);
                decimal b = Convert.ToDecimal(textBoxCijenaGoriva.Text);
                decimal cc = Convert.ToDecimal(textBoxNama.Text);
                decimal d = Convert.ToDecimal(textBoxTrajekt.Text);
                decimal f = Convert.ToDecimal(textBoxVozac.Text);
                decimal g = Convert.ToDecimal(textBoxUkupnoKm.Text);
                decimal h = Convert.ToDecimal(textBoxUkupnaCijena.Text);


                string cestar = a.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string cijenagoriva = b.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string mi = cc.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string trajek = d.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string voza = f.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string ukupnokilometara = g.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string ukupnacijena = h.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string TrenutniDatum = DateTime.Now.ToShortDateString();

                DataGridViewRow dr = dataGridView2.SelectedRows[0];   //ID selektiranog retka

                string napom = textBoxNapomene.Text;
                string delet = dr.Cells[0].Value.ToString();

                string inDB = "UPDATE sve " +
                              "SET Firma='" + firme + "',Pocetak='" + poc + "',Zavrsetak='" + ciljj + "',Gorivo=" + cijenagoriva + ",Cestarina=" + cestar + ",Trajekt=" + trajek + ",Vozac=" + voza + ",Nama=" + mi + ",Ukupna_Cijena=" + ukupnacijena + ",Ukupno_KM=" + ukupnokilometara + ",Napomene='" + napom + "',Datum_Unosa='"  + TrenutniDatum + "'" +
                              "WHERE ID =" + delet;


                OleDbCommand upis = new OleDbCommand(inDB, conn);
                upis.ExecuteNonQuery();

                ////spremanje ID reda za sinkronizaciju
                //string SpremanjeRedaZaSync = firme + "|" + poc + "|" + ciljj + "|" + ukupnacijena + "|" + napom;

                ////ako ne postoji može spremanje 
                //if (!File.Exists(Application.StartupPath + "\\tmp\\PonudaBrisanje " + firme + "-" + poc + "-" + ciljj + ".txt"))
                //{
                //    File.WriteAllText(Application.StartupPath + "\\tmp\\PonudaBrisanje " + firme + "-" + poc + "-" + ciljj + ".txt", SpremanjeRedaZaSync);
                //}
                //else if (File.Exists(Application.StartupPath + "\\tmp\\PonudaBrisanje " + firme + "-" + poc + "-" + ciljj + ".txt"))
                //{
                //    File.WriteAllText(Application.StartupPath + "\\tmp\\PonudaBrisanje " + firme + "-" + poc + "-" + ciljj + "1" + ".txt", SpremanjeRedaZaSync);
                //}
                //    File.WriteAllText(Application.StartupPath + "\\tmp\\PonudaIzmjena-" + firme + "-" + poc + "-" + ciljj + ".txt", delet);

                MessageBox.Show("Uspješno spremanje u bazu!", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            kraj:
                conn.Close();                       //zatvara se baza podataka
                ponuda++;

            }
            else
            {
                MessageBox.Show("Već ste spremili ovu ponudu!");
            }

        }
      
        private void buttonPovratak_Click(object sender, EventArgs e)
        {
            labelKlik.Hide();
            labelValuta.Hide();
            System.IO.File.Delete(@"privOd.txt");
            System.IO.File.Delete(@"privDo.txt");
            System.IO.File.Delete(@"privPonuda.txt");           
            this.Close();
        }

        private void textBoxUkupnaCijena_TextChanged(object sender, EventArgs e)
        {
            i = 0;
           
        }

        private void textBoxCijenaGoriva_TextChanged(object sender, EventArgs e)
        {
            i = 0;
            string n = textBoxCijenaGoriva.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxCijenaGoriva.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxCijenaGoriva.Clear();
            }
        }
         
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBoxCijenaGoriva.Text.Length == 0)
            {
                textBoxCijenaGoriva.Text = "0";
            }

            if (textBoxCestarina.Text.Length == 0)
            {
                textBoxCestarina.Text = "0";
            }
            if (textBoxNama.Text.Length == 0)
            {
                textBoxNama.Text = "0";
            }
            if (textBoxTrajekt.Text.Length == 0)
            {
                textBoxTrajekt.Text = "0";
            }
            if (textBoxVozac.Text.Length == 0)
            {
                textBoxVozac.Text = "0";
            }
            if (textBoxUkupnoKm.Text.Length == 0)
            {
                textBoxUkupnoKm.Text = "0";
            }

            if (i >= 1)
            {
                MessageBox.Show("Već ste kliknuli jedanput!", "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto kraj;
            }
                if (textBoxEur.Text.Length != 0)
            {
                double u = Convert.ToDouble(textBoxCestarina.Text);
                double u1 = Convert.ToDouble(textBoxCijenaGoriva.Text);
                double u2 = Convert.ToDouble(textBoxNama.Text);
                double u3 = Convert.ToDouble(textBoxTrajekt.Text);
                double u4 = Convert.ToDouble(textBoxVozac.Text);
                double eu = Convert.ToDouble(textBoxEur.Text);
                double u5 = u + u1 + u2 + u3 + u4;
                decimal rez1 = Convert.ToDecimal(u5);
                decimal rez2 = Convert.ToDecimal(eu);
                decimal u6 = rez1 / rez2;
                u6 = Math.Round(u6, 2);

                textBoxUkupnaCijena.Text = u6.ToString();

                i++;

                SpremanjeUBazu.Show();
            }
                   
            else
            {
                MessageBox.Show("Unesi valutu EURA", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            }

            kraj:
                i++;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        

        private void buttonUpute_Click(object sender, EventArgs e)
        {
            FormIzmjenaUpute formIzmjenaUpute = new FormIzmjenaUpute();
            formIzmjenaUpute.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBoxEur_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxEur.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxEur.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxEur.Clear();
                goto kraj;
            }
            labelValuta.Hide();
            labelKlik.Show();
            if (textBoxEur.TextLength == 0)
            {
                labelValuta.Show();
                labelKlik.Hide();
            }
            kraj:
            i = 0;
        }

        private void textBoxNama_TextChanged(object sender, EventArgs e)
        {
            i = 0;
            string n = textBoxNama.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxNama.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxNama.Clear();
            }
        }

        private void textBoxCestarina_TextChanged(object sender, EventArgs e)
        {
            i = 0;
            string n = textBoxCestarina.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxCestarina.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxCestarina.Clear();
            }
        }

        private void textBoxTrajekt_TextChanged(object sender, EventArgs e)
        {
            i = 0;
            string n = textBoxTrajekt.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxTrajekt.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxTrajekt.Clear();
            }
        }
        

        private void textBoxVozac_TextChanged(object sender, EventArgs e)
        {
            i = 0;
            string n = textBoxVozac.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxVozac.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxVozac.Clear();
            }
        
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
        }

        private void textBoxUkupnoKm_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxUkupnoKm.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxUkupnoKm.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxUkupnoKm.Clear();
            }
        }
        
    }
}
