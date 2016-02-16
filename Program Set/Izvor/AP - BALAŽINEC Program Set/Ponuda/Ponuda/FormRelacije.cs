using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace Ponuda
{
    public partial class FormRelacije : Form
    {
        public FormRelacije()
        {
            InitializeComponent();
            
        }
        string PutBaze;
        private void FormRelacije_Load(object sender, EventArgs e)
        {
             PutBaze = System.IO.File.ReadAllText(Application.StartupPath + "\\Ponuda\\BazaPonuda.txt");

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
                System.IO.File.Delete(@"privOd.txt");
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
                System.IO.File.Delete(@"privDo.txt");

                goto kraj;
            }

            if (File.Exists(@"PrivDo.txt") && File.Exists(@"privOd.txt"))
            {
                dataGridView2.ClearSelection();

                string PutOd = System.IO.File.ReadAllText(@"privOd.txt");
                string PutDo = System.IO.File.ReadAllText(@"PrivDo.txt");

                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                    //----------SQL instrukcija-----------\\

                    string sql = "SELECT * FROM sve WHERE Pocetak LIKE '" + PutOd + "%' AND WHERE Zavrsetak LIKE '"+ PutDo + "%'";

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
                    System.IO.File.Delete(@"PrivDo.txt");
                    System.IO.File.Delete(@"privOd.txt");
                   

                    goto kraj;

                

            }

        kraj:
            System.IO.File.WriteAllText(@"a.txt", "1");
            System.IO.File.Delete(@"a.txt");
            this.dataGridView2.Sort(firmaDataGridViewTextBoxColumn, ListSortDirection.Ascending);
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
        }
    }
}
