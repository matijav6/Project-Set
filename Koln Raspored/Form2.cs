using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koln_Raspored
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        
        string[] nacin1 = { "Marko", "Hrvoje", "Aleksandar" };
        string[] nacin2 = { "Nenad", "Kruno", "Darko", "Saša", "Teo", "Dubravko" };

        List<string> rijesen = new List<String>();
        string pocetniOznaceniDatum;

        private void Form2_Load(object sender, EventArgs e)
        {
            buttonSave.Visible = false;
            buttonGenerate.Visible = false;
            buttonGodisnji.Visible = false;
            loadData();
            
        }

        bool delete = false;        

        private void loadData()
        {

            dataGridView1.ClearSelection();
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\vozaci.mdb";

            if(comboBox1.Items.Count ==  0)
                GetTables(connString);
            else
            {
                string table = comboBox1.SelectedItem.ToString();
                
                //----------SQL instrukcija-----------\\

                string sql = "SELECT * FROM " + table;

                //klase za povezivanje na ACCESS bazu podataka//
                OleDbConnection conn = new OleDbConnection(connString);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

                DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                conn.Open();                        //otvara spoj s bazom podataka

                adapter.Fill(ds, table);            //puni se DataSet s podacima tabele
                conn.Close();                       //zatvara se baza podataka

                //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                dataGridView1.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
                dataGridView1.DataMember = table;

                buttonGenerate.Visible = true;
                buttonSave.Visible = true;
                buttonGodisnji.Visible = true;
            }
        }

        public void GetTables(string connectionString)
        {
            
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

            DataTable userTables = null;
            using (DbConnection connection = factory.CreateConnection())
            {                
                connection.ConnectionString = connectionString;
                             
                string[] restrictions = new string[4];
                restrictions[3] = "Table";

                connection.Open();
                
                userTables = connection.GetSchema("Tables", restrictions);
            }


            for (int i = 0; i < userTables.Rows.Count; i++)
                comboBox1.Items.Add((userTables.Rows[i][2].ToString()));
                
        }

        public void save(string connString, bool delete)
        {           
            string sql = null;
            int i = 0;            
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        conn.Open();

                        if(delete)
                            foreach (DataGridViewRow row in dataGridView1.Rows)                        
                                for (i = 0; i < dataGridView1.Columns.Count; i += 3)
                                {
                                    row.HeaderCell.ToString();
                                    sql = "INSERT INTO " + comboBox1.SelectedItem.ToString() + "(datum_ide) VALUES ('" + row.Cells[i + 1].Value.ToString() + "');";
                                    OleDbCommand upis = new OleDbCommand(sql, conn);
                                    upis.ExecuteNonQuery();
                                }
                        else
                        {
                            int rowindex = dataGridView1.CurrentCell.RowIndex;
                            int columnindex = dataGridView1.CurrentCell.ColumnIndex;

                            string ideSpremi;
                            ideSpremi = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();

                            sql = "UPDATE " + comboBox1.SelectedItem.ToString() + " SET datum_ide = '"
                                + ideSpremi +
                                "' WHERE ID = " + ++rowindex + ";";

                            OleDbCommand upis = new OleDbCommand(sql, conn);
                            upis.ExecuteNonQuery();

                        }                                     
                        conn.Close();

                    }
                }
                MessageBox.Show("Uspješno spremljeno");
            }
            catch (Exception e)
            {
                if(!e.ToString().Contains("System.NullReferenceException"))
                MessageBox.Show(e.ToString());
            }

        }
        
        private bool godisnji(string datum, string trazeniVozac)
        {
            int k = 0, id = 0, id2 = 0;            
            DateTime pocetniDatum = DateTime.Parse(datum);
            DateTime pom = pocetniDatum.AddDays(7);
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\vozaci.mdb";
            OleDbConnection conn = new OleDbConnection(connString);

            for(int i = 0; i < nacin1.Count(); i++)
            {
                if (trazeniVozac == nacin1[i])
                {
                    k = i + 1;
                    if (k >= nacin1.Count())
                        k = 0;
                }
                    
            }          
            //označeni vozač i datum
            id = ucitajDatum(trazeniVozac, pocetniDatum, connString);

        opet:
            //sljedeći vozać i datum-----provjeri dal nije bil prošli tjedan
            id2 = ucitajDatum(nacin1[k], pom, connString);
            try
            {
                conn.Close();
                conn.Open();
            }
            catch {
                conn.Open();
            }

            string sql = "SELECT datum_ide FROM " + nacin1[k] + " WHERE datum_ide = '" + pocetniDatum.AddDays(-7).ToShortDateString() + "'";
            
            OleDbDataReader reader = null;
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            reader = cmd.ExecuteReader();

            // tu smo stali, treba provjeriti da li zamjena nije bila tjedan prije i da li ne bude tjedan kasnije
            while (reader.Read())
            {
                DateTime datumBaza = DateTime.ParseExact(reader["datum_ide"] + " 00:00:00", "d.M.yyyy. hh:mm:ss", CultureInfo.InvariantCulture);
                MessageBox.Show(datumBaza + "     " + pocetniDatum.AddDays(7));
                if (datumBaza == pocetniDatum.AddDays(-7))
                {                    
                    k++;
                    if (k >= nacin1.Count())
                        k = 0;

                    if (datumBaza == pocetniDatum.AddDays(7))
                    {
                        MessageBox.Show("ads");
                        pom = pom.AddDays(7);
                    }
                    goto opet;
                }
                
            }

            sql = "UPDATE " + trazeniVozac + " SET datum_ide = '"
                                  + pom.ToShortDateString() +
                                  "' WHERE ID = " + id + ";";

            OleDbCommand upis;
            upis = new OleDbCommand(sql, conn);
            //upis.ExecuteNonQuery();

            sql = "UPDATE " + nacin1[k] + " SET datum_ide = '"
                                  + pocetniDatum.ToShortDateString() +
                                  "' WHERE ID = " + id2 + ";";

            upis = new OleDbCommand(sql, conn);
            //upis.ExecuteNonQuery();


            conn.Close();
            return true;    
        }

        public int ucitajDatum(string driver, DateTime datum, string connString)
        {
            string sql = "SELECT * FROM " + driver;
            
            OleDbConnection conn = new OleDbConnection(connString);            
           
            conn.Open();            

            OleDbDataReader reader = null;
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime datumBaza = DateTime.ParseExact(reader["datum_ide"] + " 00:00:00", "d.M.yyyy. hh:mm:ss", CultureInfo.InvariantCulture);
                if (datumBaza >= datum)
                {
                    int id = Convert.ToInt16(reader["ID"]);
                    conn.Close();                    
                    return id;
                }
            }
            return 0;
        }
        private List<string> generate(string driver, string datum)
        {
            DateTime pocetniDatum = new DateTime(2018, 2, 2);
            List<string> vozac = new List<string>();            
            int k = 0;

            bool glavni = true;

            //dal je neki od ostalih vozaca
            for(int i = 0; i<6; i++)
            {
                if (nacin2[i] == driver)
                    glavni = false;
            }

            //ako nije, ajmo na posao

            if(glavni)
                for(int i = 0; i < 52; i++)
                {
                    
                    if (nacin1[k] == driver)
                        vozac.Add(pocetniDatum.ToShortDateString());
                
                    k++;
                    pocetniDatum = pocetniDatum.AddDays(7);
                    if (k == nacin1.Count())
                        k = 0;
                }
            else
            {
                for (int i = 0; i < 52; i++)
                {
                    if (nacin2[k] == driver)
                        vozac.Add(pocetniDatum.ToShortDateString());
                    k++;
                    pocetniDatum = pocetniDatum.AddDays(7);
                    if (k == nacin2.Count())
                        k = 0;
                }
            }
                        
            return vozac;

        }

        public bool zamjenaGodisnji(string glavni, string zamjena, string glavni_datum, int id)
        {
            //prvi datum nakon glavnog_datuma
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\vozaci.mdb";
            string sql = "SELECT * FROM " + zamjena;
            DateTime glavniDatum = DateTime.ParseExact(glavni_datum + " 00:00:00", "d.M.yyyy. hh:mm:ss", CultureInfo.InvariantCulture);
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand upis;

            conn.Open();

            OleDbDataReader reader = null;
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime datumBaza = DateTime.ParseExact(reader["datum_ide"] + " 00:00:00", "d.M.yyyy. hh:mm:ss", CultureInfo.InvariantCulture);

                if (datumBaza >= glavniDatum && glavniDatum.AddDays(-7) != glavniDatum && zamjena != glavni)
                {
                    //zamjena
                    sql = "UPDATE " + zamjena + " SET datum_ide = '"
                              + glavniDatum.ToShortDateString() +
                              "' WHERE ID = " + reader["ID"] + ";";

                    upis = new OleDbCommand(sql, conn);
                    upis.ExecuteNonQuery();

                    sql = "UPDATE " + glavni + " SET datum_ide = '"
                               + datumBaza.ToShortDateString() +
                               "' WHERE ID = " + id + ";";

                    upis = new OleDbCommand(sql, conn);
                    upis.ExecuteNonQuery();

                    conn.Close();
                    break;
                }
                else
                {
                    MessageBox.Show("Odaberi drugog vozača");
                    conn.Close();
                    return false;
                }
                    
            }
            return true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            loadData();            
        }
       
        private void buttonSave_Click(object sender, EventArgs e)
        {
            save("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\vozaci.mdb",delete);
            
            buttonGenerate.Visible = false;
            buttonSave.Visible = false;
            buttonGodisnji.Visible = false;
        }    

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string sql;
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\vozaci.mdb";

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    conn.Open();
                    sql = "DROP TABLE " + comboBox1.SelectedItem.ToString();
                    OleDbCommand brisi = new OleDbCommand(sql, conn);
                    brisi.ExecuteNonQuery();

                    sql = "CREATE TABLE " + comboBox1.SelectedItem.ToString() + "(ID AUTOINCREMENT PRIMARY KEY , datum_ide varchar(30), datum_nejde varchar(30));";
                    OleDbCommand kreiraj = new OleDbCommand(sql, conn);
                    kreiraj.ExecuteNonQuery();
                    conn.Close();
                }
            }

            List<string> stringy = generate(comboBox1.SelectedItem.ToString(),null);            
            dataGridView1.DataSource = stringy.Select(x => new { datum_ide = x }).ToList();
            delete = true;

            save("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\vozaci.mdb", delete);
        }

        private void buttonGodisnji_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;

            string oznaceniDatum;
            oznaceniDatum = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            string vozac = comboBox1.SelectedItem.ToString();
            pocetniOznaceniDatum = oznaceniDatum;
            buttonGenerate.Visible = false;
            buttonGodisnji.Visible = false;
            buttonSave.Visible = false;
            
         //   try
           // {

                if (nacin1.Contains(vozac))
                {                    
                        if (!godisnji(oznaceniDatum,comboBox1.SelectedItem.ToString()))
                        {
                            MessageBox.Show("Došlo je do greške");                            
                        }                                              
                }
                else
                {
                opet:
                    FormZamjena form3 = new FormZamjena(nacin2);
                    form3.ShowDialog();
                    while (!zamjenaGodisnji(comboBox1.SelectedItem.ToString(), form3.zamjena, oznaceniDatum, rowindex + 1))                                            
                        goto opet;
                }
                MessageBox.Show("Uspješno spremljeno");


          /*  }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
