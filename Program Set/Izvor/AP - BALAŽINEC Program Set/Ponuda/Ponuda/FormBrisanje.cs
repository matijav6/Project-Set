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
    public partial class FormBrisanje : Form
    {
        public FormBrisanje()
        {
            InitializeComponent();
        }

        public void PonovnoUcitavanje()
        {
            string PutBaze = System.IO.File.ReadAllText(Application.StartupPath + "\\Ponuda\\BazaPonuda.txt");

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
        private void FormBrisanje_Load(object sender, EventArgs e)
        {
            string PutBaze = System.IO.File.ReadAllText(Application.StartupPath + "\\Ponuda\\BazaPonuda.txt");

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
            this.dataGridView2.Sort(firmaDataGridViewTextBoxColumn, ListSortDirection.Ascending);
            System.IO.File.WriteAllText(@"a.txt", "1");
            System.IO.File.Delete(@"a.txt");

        }
        string PutBaze;
        private void buttonOdaberi_Click(object sender, EventArgs e)
        {
            PutBaze = System.IO.File.ReadAllText(Application.StartupPath + "\\Ponuda\\BazaPonuda.txt");
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

            //----------SQL instrukcija-----------\\
            string sql = "SELECT * FROM sve";

            //klase za povezivanje na ACCESS bazu podataka//
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

            conn.Open();


            //za brisanje ne može biti ID reda jer je možda u drugoj bazi pod drugim ID-om
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            string firma = dr.Cells[1].Value.ToString();
            string relacijaOd = dr.Cells[2].Value.ToString();
            string relacijaDo = dr.Cells[3].Value.ToString();
            string cijena = dr.Cells[9].Value.ToString();
            string napomena = dr.Cells[11].Value.ToString();
            //string SpremanjeRedaZaSync = firma + "|" + relacijaOd + "|" + relacijaDo + "|" + cijena + "|" + napomena;

            ////ako ne postoji može spremanje 
            //if (!File.Exists(Application.StartupPath + "\\tmp\\PonudaBrisanje " + firma + "-" + relacijaOd + "-" + relacijaDo + ".txt"))
            //{
            //    File.WriteAllText(Application.StartupPath + "\\tmp\\PonudaBrisanje " + firma + "-" + relacijaOd + "-" + relacijaDo + ".txt", SpremanjeRedaZaSync);
            //}
            //else if (File.Exists(Application.StartupPath + "\\tmp\\PonudaBrisanje " + firma + "-" + relacijaOd + "-" + relacijaDo + ".txt"))
            //{
            //    File.WriteAllText(Application.StartupPath + "\\tmp\\PonudaBrisanje " + firma + "-" + relacijaOd + "-" + relacijaDo + "1" + ".txt", SpremanjeRedaZaSync);
            //}
            OleDbCommand brisanje = new OleDbCommand("DELETE * FROM sve WHERE ID = " + dr.Cells[0].Value.ToString(), conn);
            brisanje.ExecuteNonQuery();
            
            MessageBox.Show("Uspješno obrisano", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //ponovno učitavanje
            PonovnoUcitavanje();
        }
      
        private void buttonPovratak_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(@"privOd.txt");
            System.IO.File.Delete(@"privDo.txt");
            System.IO.File.Delete(@"privPonuda.txt");
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
        }
    }
}
