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

        
        string[] glavniVozaci = {  };
        string[] ostaliVozaci = { };
        string[] pomocniVozaci = { };
        DateTime pocetniDatum, pocetniDatumPomocni;
        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\vozaci.mdb", sql = null;
        OleDbConnection conn;
        OleDbCommand cmd;
        bool godisnji = false;
        bool delete = false;

        private void Form2_Load(object sender, EventArgs e)
        {
            buttonSave.Visible = false;
            buttonGenerate.Visible = false;
            buttonGodisnji.Visible = false;

            loadData();

            glavniVozaci = System.IO.File.ReadAllLines(Application.StartupPath + "\\bin\\glavniVozaci.txt");
            ostaliVozaci = System.IO.File.ReadAllLines(Application.StartupPath + "\\bin\\ostaliVozaci.txt");
            pomocniVozaci = System.IO.File.ReadAllLines(Application.StartupPath + "\\bin\\pomocniVozaci.txt");

            string[] pom = System.IO.File.ReadAllLines(Application.StartupPath + "\\bin\\pocetniDatum.txt".ToString());
            pocetniDatum = DateTime.Parse(pom[0]);

            string[] pom1 = System.IO.File.ReadAllLines(Application.StartupPath + "\\bin\\pocetniDatumPomocni.txt".ToString());
            pocetniDatumPomocni = DateTime.Parse(pom1[0]);
        }

        //učitava podatke za odabranog vozača, ili učitava samo imena vozača za comboBox
        private void loadData()
        {

            dataGridView1.ClearSelection();
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\vozaci.mdb";

            if (comboBox1.Items.Count == 0)
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

        //učitava nazice tablica, odnosno imena vozača
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

        //generiraj datume za glavne vozače, svaki tjedan ide jedan
        public void generirajGlavni(bool delete)
        {
            List<string> datum = new List<string>();
            
            //za sve vozače, prvo generiraj datum, onda upiši u bazu
            for(int x = 0; x < glavniVozaci.Count(); x++)
            {
                datum.Clear();
                //generiraj datume u listu "datum"
                for (DateTime i = pocetniDatum; i <= new DateTime(DateTime.Now.Year, 12, 31); i = i.AddDays(glavniVozaci.Count() * 7))
                {
                    datum.Add(i.ToShortDateString());
                }

                //*********upis u bazu*********
                conn = new OleDbConnection(connString);
                conn.Open();

                if(delete)
                {
                    sql = "DROP TABLE " + glavniVozaci[x];
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    sql = "CREATE TABLE " + glavniVozaci[x] + "(ID AUTOINCREMENT PRIMARY KEY , datum_ide varchar(30));";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    delete = true;
                }                

                foreach(string item in datum)
                {
                    sql = "INSERT INTO " + glavniVozaci[x] + "(datum_ide) VALUES ('" + item + "');";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                //*********kraj upisa u bazu*********

                pocetniDatum = pocetniDatum.AddDays(7);
            }            
        }

        //generiraj datume za ostale vozače, svaki tjedan ide jedan
        public void generirajOstali()
        {
            List<string> datum = new List<string>();

            //za sve vozače, prvo generiraj datum, onda upiši u bazu
            for (int x = 0; x < ostaliVozaci.Count(); x++)
            {
                datum.Clear();
                //generiraj datume u listu "datum"
                for (DateTime i = pocetniDatum; i <= new DateTime(DateTime.Now.Year, 12, 31); i = i.AddDays(ostaliVozaci.Count() * 7))
                {
                    datum.Add(i.ToShortDateString());
                }

                //*********upis u bazu*********
                conn = new OleDbConnection(connString);
                conn.Open();

                sql = "DROP TABLE " + ostaliVozaci[x];
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE " + ostaliVozaci[x] + "(ID AUTOINCREMENT PRIMARY KEY , datum_ide varchar(30));";
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                foreach (string item in datum)
                {
                    sql = "INSERT INTO " + ostaliVozaci[x] + "(datum_ide) VALUES ('" + item + "');";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                //*********kraj upisa u bazu*********

                pocetniDatum = pocetniDatum.AddDays(7);
            }
        }

        //generiraj datume za pomoćnog vozača
        public void generirajPomocni(bool delete, string mjenjanVozac)
        {
            int zamjena = 0;

            //traženje koga je mijenjal prvo
            string pocetniMjesec = pocetniDatumPomocni.Month.ToString();
            
            int k = 0;
            conn = new OleDbConnection(connString);
            conn.Open();

            if(delete)
            {
                sql = "DROP TABLE " + pomocniVozaci[0];
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE " + pomocniVozaci[0] + "(ID AUTOINCREMENT PRIMARY KEY , datum_ide varchar(30));";
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }      
                  
            if(mjenjanVozac == null)
            {
                for (int i = 0; i < glavniVozaci.Count(); i++)
                {
                    sql = "SELECT datum_ide FROM " + glavniVozaci[i] + " WHERE datum_ide = '" + pocetniDatumPomocni.AddDays(7).ToShortDateString() + "'";

                    cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        if (reader["datum_ide"].ToString() == null)
                            break;
                        else
                        {
                            i++;
                            if (i >= glavniVozaci.Count())
                                i = 0;
                            mjenjanVozac = glavniVozaci[i];
                            break;
                        }
                    }
                    if (mjenjanVozac != null)
                        break;
                }
            }
           
            //prvo je mijenjal 'mjenjanVozac'
            if (!godisnji)
            {
                try
                {
                    //obriši datum od glavnog, kad je na redu pomocni vozac
                    sql = "DELETE FROM " + mjenjanVozac + " WHERE datum_ide = '" + pocetniDatumPomocni.ToShortDateString() + "';";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    sql = "INSERT INTO  " + pomocniVozaci[0] + "(datum_ide) VALUES('" + pocetniDatumPomocni.ToShortDateString() + "');";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }            

            //najdemo koga je mjenjal u glavniVozaci
            for(int i = 0; i < glavniVozaci.Count(); i++)
            {
                if(glavniVozaci[i] == mjenjanVozac)
                {
                    k = i;
                }
            }

            conn.Close();
            bool gotovo = false;
            for (DateTime i = pocetniDatumPomocni; i <= new DateTime(DateTime.Now.Year, 12, 31); i = i.AddDays(7))
            {                
                //ako je sljedeći mjesec
                if (i.Month.ToString() != pocetniMjesec &&  !gotovo)
                {
                    DateTime datumBaza = new DateTime();     
                    
                    //ponavljaj tak dugo dok ne najdemo vozača kojeg treba mjenjati               
                    while (datumBaza.ToShortDateString() == "1.1.0001.")
                    {
                        k++;
                        if (k >= glavniVozaci.Count())
                            k = 0;
                        string sql = "SELECT datum_ide FROM " + glavniVozaci[k] + " WHERE datum_ide LIKE '%." + i.Month.ToString() + ".%';";

                        conn.Open();
                        cmd = new OleDbCommand(sql, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {                            
                            datumBaza = DateTime.Parse(reader["datum_ide"].ToString());
                            if (zamjena < 2)
                                break;

                        }
                        
                        conn.Close();                       
                    }
                    conn.Open();

                    //obriši datum od glavnog, kad je na redu pomocni vozac
                    sql = "DELETE FROM " + glavniVozaci[k] + " WHERE datum_ide = '" + datumBaza.ToShortDateString() + "';";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    
                    sql = "INSERT INTO  " + pomocniVozaci[0] + "(datum_ide) VALUES('" + datumBaza.ToShortDateString() + "');";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    pocetniMjesec = i.Month.ToString();

                    zamjena++;
                    if (zamjena == 2)
                        zamjena = 0;
                    if (i > new DateTime(DateTime.Now.Year, 12, 1) && i < new DateTime(DateTime.Now.Year, 12, 31))
                    {
                        gotovo = true;                        
                    }
                        
                }
                
            }    
            
        }
        
        public void godisnjiGlavniVozaci(string oznaceniDatum)
        {
            conn = new OleDbConnection(connString);
            conn.Open();
            OleDbCommand cmd;
            OleDbDataReader reader;
            string prosliTjedan = null;

            for(int i = 0; i < glavniVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + glavniVozaci[i] + " WHERE datum_ide = '" + DateTime.Parse(oznaceniDatum).AddDays(-7).ToShortDateString() + "'";

                cmd = new OleDbCommand(sql, conn);
                  reader = cmd.ExecuteReader();

                while (reader.Read())
                    prosliTjedan = glavniVozaci[i];
            }
            conn.Close();

            if (prosliTjedan == null)
                prosliTjedan = pomocniVozaci[0];

            List<string> glavniVozaciList = new List<string>();

            glavniVozaciList.Add(pomocniVozaci[0].ToString());
            foreach (string item in glavniVozaci)                
                glavniVozaciList.Add(item);

            string zamjena = null;
            for (int i = 0; i < glavniVozaciList.Count(); i++)
            {                
                if (glavniVozaciList[i] != comboBox1.SelectedItem.ToString() && glavniVozaciList[i] != prosliTjedan)
                {
                    zamjena = glavniVozaciList[i];
                }              
                    
            }
            //vozač koji mjenja
            string pom = null;
            if(zamjena == glavniVozaci[0])
            {
                pom = glavniVozaci[0];
                glavniVozaci[0] = glavniVozaci[1];
                glavniVozaci[1] = pom;
            }
            
            pocetniDatum = DateTime.Parse(oznaceniDatum).AddDays(7);

            List<string> brisi = new List<string>();

            //brisanje datum od datuma kad je godišnji
            for (int i = 0; i < glavniVozaci.Count(); i++)
            {
                brisi.Clear();
                conn.Open();
                sql = "SELECT datum_ide FROM " + glavniVozaci[i];
                cmd = new OleDbCommand(sql, conn);                
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (DateTime.Parse(reader["datum_ide"].ToString()) >= DateTime.Parse(oznaceniDatum))
                        brisi.Add(reader["datum_ide"].ToString());
                }
                foreach(string item in brisi)
                {
                    sql = "DELETE FROM " + glavniVozaci[i] + " WHERE datum_ide  = '" + item + "';";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

            for (int i = 0; i < pomocniVozaci.Count(); i++)
            {
                brisi.Clear();
                conn.Open();
                sql = "SELECT datum_ide FROM " + pomocniVozaci[i];
                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (DateTime.Parse(reader["datum_ide"].ToString()) >= DateTime.Parse(oznaceniDatum))
                        brisi.Add(reader["datum_ide"].ToString());
                }
                foreach (string item in brisi)
                {
                    sql = "DELETE FROM " + pomocniVozaci[i] + " WHERE datum_ide  = '" + item + "';";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

            string datumBaza = DateTime.Parse(oznaceniDatum).ToShortDateString();            
            sql = "SELECT datum_ide FROM " + pomocniVozaci[0] + "';";

            cmd = new OleDbCommand(sql, conn);
            conn.Open();
             reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (DateTime.Parse(reader["datum_ide"].ToString()) > DateTime.Parse(oznaceniDatum))
                    break;

                datumBaza = reader["datum_ide"].ToString();
            }
            conn.Close();
            
            conn.Open();
            sql = "INSERT INTO " + zamjena + "(datum_ide) VALUES ('" + oznaceniDatum + "');";
            cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();            
            conn.Close();


            conn.Open();

            //ako je mjenjan vozač već bil u označenom mjesecu, onda taj moremo preskočiti
            //ako nije bil, onda treba saznati koga je mjenjal prošli i zamjeniti ovaj
            string zadnjiDatum = null;
            for (int i = 0; i < pomocniVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + pomocniVozaci[i] +  ";";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                    zadnjiDatum = reader["datum_ide"].ToString();
            }
            conn.Close();
            pocetniDatumPomocni = DateTime.Parse(datumBaza).AddMonths(1);
            generirajGlavni(false);

            //generiraj pomocni, nakon označenog datum
            //zadnjiDatum - zadnji datum kad je išel pomoćni, prije označenog            
             if (DateTime.Parse(zadnjiDatum).Month == DateTime.Parse(oznaceniDatum).Month)
             {
                 pocetniDatumPomocni = DateTime.Parse(datumBaza);
                 generirajGlavni(false);
                generirajPomocni(false, null);
             }

             else
             {                
                 generirajGlavni(false);

                 conn.Open();
                 int k = 0;
                 string dat = null;
                 for (int i = 0; i < glavniVozaci.Count(); i++)
                 {
                     sql = "SELECT datum_ide FROM " + glavniVozaci[i] + " WHERE datum_ide  = '" + DateTime.Parse(zadnjiDatum).AddDays(7).ToShortDateString() + "';";

                     cmd = new OleDbCommand(sql, conn);
                     reader = cmd.ExecuteReader();

                     //ako postoji zapis, onda se ovo izvršava
                     while (reader.Read())
                         k = i;                     
                 }
                /* k++;
                 if (k == glavniVozaci.Count())
                     k = 0; */

                 sql = "SELECT datum_ide FROM " + glavniVozaci[k] + ";";

                 cmd = new OleDbCommand(sql, conn);
                 reader = cmd.ExecuteReader();

                 while (reader.Read())
                 {
                     dat = reader["datum_ide"].ToString();
                     if (DateTime.Parse(reader["datum_ide"].ToString()) > DateTime.Parse(oznaceniDatum))
                         break;                        
                 }
                 conn.Close();
                conn.Open();

                sql = "DELETE FROM " + glavniVozaci[k] + " WHERE datum_ide  = '" + dat + "';";
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "INSERT INTO " + pomocniVozaci[0] + " (datum_ide) VALUES('" + dat + "');";                
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "SELECT datum_ide FROM " + pomocniVozaci[0] + ";";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();
                brisi.Clear();
                while (reader.Read())
                {                    
                    if (DateTime.Parse(reader["datum_ide"].ToString()) > DateTime.Parse(oznaceniDatum) && DateTime.Parse(reader["datum_ide"].ToString()).ToShortDateString() != dat)
                        brisi.Add(reader["datum_ide"].ToString());
                }
                foreach(string item in brisi)
                {
                    sql = "DELETE FROM " + pomocniVozaci[0] + " WHERE datum_ide  = '" + item + "';";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                pocetniDatumPomocni = DateTime.Parse(dat);
                
                generirajPomocni(false, glavniVozaci[k]);
                
            }                     
        }

        public void godisnjiOstaliVozaci(string oznaceniDatum)
        {
            opet:
            DateTime oznaceniDatumDT = DateTime.Parse(oznaceniDatum);
            string noviDatum = null;

            FormZamjena form3 = new FormZamjena(ostaliVozaci);
            form3.ShowDialog();
            string vozacZamjena = form3.zamjena;

            if (vozacZamjena == null)
                goto end;
            conn = new OleDbConnection(connString);
            conn.Open();

            //najdi prvi sljedeći datum tražene zamjene u odnosu na odabrani datum
            sql = "SELECT datum_ide FROM " + vozacZamjena;

            cmd= new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                noviDatum = reader["datum_ide"].ToString();
                if (oznaceniDatumDT <= DateTime.Parse(reader["datum_ide"].ToString()))
                    break;
            }

            string tjedanPrije1 = null, tjedanPrije2, tjedanPoslije1 = null, tjedanPoslije2 = null;
            
            for(int i = 0; i < ostaliVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + ostaliVozaci[i] + " WHERE datum_ide = '" + oznaceniDatumDT.AddDays(-7).ToShortDateString() + "';";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    //datumBaza = reader["datum_ide"].ToString();
                    tjedanPrije1 = ostaliVozaci[i];
                    
                }
            }

            for (int i = 0; i < ostaliVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + ostaliVozaci[i] + " WHERE datum_ide = '" + DateTime.Parse(noviDatum).AddDays(-7).ToShortDateString() + "';";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //datumBaza = reader["datum_ide"].ToString();
                    tjedanPrije2 = ostaliVozaci[i];

                }
            }

            for (int i = 0; i < ostaliVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + ostaliVozaci[i] + " WHERE datum_ide = '" + DateTime.Parse(noviDatum).AddDays(7).ToShortDateString() + "';";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //datumBaza = reader["datum_ide"].ToString();
                    tjedanPoslije1 = ostaliVozaci[i];

                }
            }

            for (int i = 0; i < ostaliVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + ostaliVozaci[i] + " WHERE datum_ide = '" + oznaceniDatumDT.AddDays(7).ToShortDateString() + "';";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //datumBaza = reader["datum_ide"].ToString();
                    tjedanPoslije2 = ostaliVozaci[i];

                }
            }

            if (vozacZamjena == comboBox1.SelectedItem.ToString() || vozacZamjena == tjedanPrije1 || vozacZamjena == tjedanPoslije1 || comboBox1.SelectedItem.ToString() == tjedanPoslije1 || comboBox1.SelectedItem.ToString() == tjedanPoslije2)
            {
                MessageBox.Show("Odaberi drugog vozača");
                goto opet;
            }
                
            //kad je pronađen prvi sljedeći datum, obavi zamjenu
            sql = "UPDATE " + vozacZamjena + " SET datum_ide = '" + oznaceniDatum + "' WHERE datum_ide  = '" + noviDatum + "';";
            cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            
            sql = "UPDATE " + comboBox1.SelectedItem.ToString() + " SET datum_ide = '" + noviDatum + "' WHERE datum_ide  = '" + oznaceniDatum + "';";
            cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            
            conn.Close();
        end:
            this.Refresh();
        }

        public void godisnjiOstaliVozaciVer2(string oznaceniDatum)
        {
        opet:
            DateTime oznaceniDatumDT = DateTime.Parse(oznaceniDatum);
            string noviDatum = null;

            FormZamjena form3 = new FormZamjena(ostaliVozaci);
            form3.ShowDialog();
            string vozacZamjena = form3.zamjena;

            if (vozacZamjena == null)
                goto end;
            conn = new OleDbConnection(connString);
            conn.Open();

            //najdi prvi sljedeći datum tražene zamjene u odnosu na odabrani datum
            sql = "SELECT datum_ide FROM " + vozacZamjena;

            cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                noviDatum = reader["datum_ide"].ToString();
                if (oznaceniDatumDT <= DateTime.Parse(reader["datum_ide"].ToString()))
                    break;
            }

            string tjedanPrije1 = null, tjedanPrije2, tjedanPoslije1 = null, tjedanPoslije2 = null;

            for (int i = 0; i < ostaliVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + ostaliVozaci[i] + " WHERE datum_ide = '" + oznaceniDatumDT.AddDays(-7).ToShortDateString() + "';";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //datumBaza = reader["datum_ide"].ToString();
                    tjedanPrije1 = ostaliVozaci[i];

                }
            }

            for (int i = 0; i < ostaliVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + ostaliVozaci[i] + " WHERE datum_ide = '" + DateTime.Parse(noviDatum).AddDays(-7).ToShortDateString() + "';";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //datumBaza = reader["datum_ide"].ToString();
                    tjedanPrije2 = ostaliVozaci[i];

                }
            }

            for (int i = 0; i < ostaliVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + ostaliVozaci[i] + " WHERE datum_ide = '" + DateTime.Parse(noviDatum).AddDays(7).ToShortDateString() + "';";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //datumBaza = reader["datum_ide"].ToString();
                    tjedanPoslije1 = ostaliVozaci[i];

                }
            }

            for (int i = 0; i < ostaliVozaci.Count(); i++)
            {
                sql = "SELECT datum_ide FROM " + ostaliVozaci[i] + " WHERE datum_ide = '" + oznaceniDatumDT.AddDays(7).ToShortDateString() + "';";

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //datumBaza = reader["datum_ide"].ToString();
                    tjedanPoslije2 = ostaliVozaci[i];

                }
            }

            if (vozacZamjena == comboBox1.SelectedItem.ToString() || vozacZamjena == tjedanPrije1 || vozacZamjena == tjedanPoslije1 || comboBox1.SelectedItem.ToString() == tjedanPoslije1 || comboBox1.SelectedItem.ToString() == tjedanPoslije2)
            {
                MessageBox.Show("Odaberi drugog vozača");
                goto opet;
            }

            //kad je pronađen prvi sljedeći datum, obavi zamjenu
            sql = "UPDATE " + vozacZamjena + " SET datum_ide = '" + oznaceniDatum + "' WHERE datum_ide  = '" + noviDatum + "';";
            cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();

            sql = "UPDATE " + comboBox1.SelectedItem.ToString() + " SET datum_ide = '" + noviDatum + "' WHERE datum_ide  = '" + oznaceniDatum + "';";
            cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();


            //obriši sve nakon if(ostaliVozaci[i] == odabran) ostaliVozaci.Count() - i * 7
            //generiraj ostaleVozace
        end:
            this.Refresh();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            loadData();            
        }
       
        private void buttonSave_Click(object sender, EventArgs e)
        {                       
            buttonGenerate.Visible = false;
            buttonSave.Visible = false;
            buttonGodisnji.Visible = false;
        }    

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (glavniVozaci.Contains(comboBox1.SelectedItem.ToString()) || pomocniVozaci.Contains(comboBox1.SelectedItem.ToString()))
            {
                generirajGlavni(true);
                generirajPomocni(true, null);
            }
                

            else
                generirajOstali();

            MessageBox.Show("Uspješno spremljeno!");
            this.Close();
        }

        private void buttonGodisnji_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
                         
            string oznaceniDatum = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            string vozac = comboBox1.SelectedItem.ToString();            

            buttonGenerate.Visible = false;
            buttonGodisnji.Visible = false;
            buttonSave.Visible = false;
            godisnji = true;

            if (glavniVozaci.Contains(vozac) || pomocniVozaci.Contains(vozac))
                godisnjiGlavniVozaci(oznaceniDatum);                

            else if (ostaliVozaci.Contains(vozac))
                godisnjiOstaliVozaci(oznaceniDatum);

            buttonGenerate.Visible = true;
            buttonGodisnji.Visible = true;
            buttonSave.Visible = true;
            MessageBox.Show("Uspješno spremljeno");    
            this.Close();        
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
