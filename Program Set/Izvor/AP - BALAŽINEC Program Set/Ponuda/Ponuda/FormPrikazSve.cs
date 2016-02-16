using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;

namespace Ponuda
{
    public partial class FormPrikazSve : Form
    {
        public FormPrikazSve()
        {
            InitializeComponent();
        }
        string PutBaze;
        private void FormPrikazSve_Load(object sender, EventArgs e)
        {
             PutBaze = System.IO.File.ReadAllText(Application.StartupPath + "\\Ponuda\\BazaPonuda.txt");
            
                dataGridView2.ClearSelection();
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                //----------SQL instrukcija-----------\\

                string sql = "SELECT * FROM sve ";

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
            }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
        }
    }
}
