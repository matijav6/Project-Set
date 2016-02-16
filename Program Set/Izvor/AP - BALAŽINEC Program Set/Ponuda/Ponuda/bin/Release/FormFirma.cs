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
    public partial class FormFirma : Form
    {
        public FormFirma()
        {
            InitializeComponent();
        }

        DataSet ds;
        string PutBaze;
        private void FormFirma_Load(object sender, EventArgs e)
        {

             PutBaze = System.IO.File.ReadAllText(Application.StartupPath + "\\Ponuda\\BazaPonuda.txt");
            string PutKriterij =System.IO.File.ReadAllText(@"privPonuda.txt");

            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+PutBaze;

            //----------SQL instrukcija-----------\\
            
            string sql = "SELECT * FROM sve WHERE Firma LIKE '" + PutKriterij + "%'";           

            //klase za povezivanje na ACCESS bazu podataka//
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

             ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
            conn.Open();                        //otvara spoj s bazom podataka

            adapter.Fill(ds, "sve");       //puni se DataSet s podacima tabele t_razred
            conn.Close();                       //zatvara se baza podataka

            //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
            dataGridView2.DataSource = ds;      //upisivanje podataka id ds u dataGridView2
            dataGridView2.DataMember = "sve";
            ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");

            this.dataGridView2.Sort(firmaDataGridViewTextBoxColumn, ListSortDirection.Ascending);
            System.IO.File.Delete(@"privPonuda.txt");

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
        }
    }
}
