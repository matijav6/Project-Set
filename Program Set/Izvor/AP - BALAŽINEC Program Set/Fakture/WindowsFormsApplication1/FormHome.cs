using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace WindowsFormApplication1
{
    public partial class AP_Balažinec : Form
    {      
        
        FormSpremanje formSpremanje = new FormSpremanje(); 
        public AP_Balažinec()
        {
             InitializeComponent();
                      
        }
        public int pom { get; set; }
        public string UcitavanjeCijena { get; set; }
        public string UcitavanjeRelacija { get; set; }

        public string relac;
        string Browse;
        string[] vozaci;
        string FaktureNepodobneZaUcitavanje;
        string put;
        string Otvorenafaktura;
        int ProvjeraFakture = 0;
        int Ucitavanje = 0, Schenker = 0;
        string[] data;
        string PutDoOtvoreneFakture;
        bool NovaRuta;
        public void SigurnosnoSpremanje()
        {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Fakture\\SafeBase.mdb";

            //----------SQL instrukcija-----------\\
            string sql = "SELECT * FROM TableSafeBase";

            //klase za povezivanje na ACCESS bazu podataka//
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

            conn.Open();  //otvara spoj s bazom podataka

            //\\//\\//\\ **podaci** //\\//\\//\\
            string DVO = textBoxDVO.Text;
            string DatumValute = textBoxDatumValute.Text;
            string BrFakture = textBoxBrojFakture.Text;
            string Kolicina = textBoxKolicina.Text;
            string Cijena = textBoxCijenaTure.Text;
            string Relacija = textBoxRelacija.Text;
            string Pozicija = textBoxPozicija.Text;
            string Kombi = comboBoxKombi.Text;
            string Vozac = comboBoxVozač.Text;
            string Napomena = textBoxNapomena.Text;
            
            string KilometriTxtBox = textBoxKilometri.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB")); 
            string CestarinaTxtBox = textBoxCestarina.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string UdioVozacuTxtBox = textBoxVozacu.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string UdioNamaTxtBox = textBoxNama.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string GorivoTxtBox = textBoxGorivo.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string Potrosnja = textBoxPotrosnja.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

            //spremanje
            string inDB = "INSERT INTO TableSafeBase (DVO,DatumValute,BrFakture,Kolicina,Cijena,Relacija,Pozicija,Kombi,Vozac,Kilometri,Cestarina,UdioVozacu,UdioNama,Gorivo,Napomena,Faktura) " +
                              "VALUES ('" + DVO + "','" + DatumValute + "','" + BrFakture + "','" + Kolicina + "','" + Cijena + "','" + Relacija + "','" + Pozicija + "','" + Kombi + "','" + Vozac + "','" + KilometriTxtBox + "','" + CestarinaTxtBox + "','" + UdioVozacuTxtBox + "','" + UdioNamaTxtBox + "','" + GorivoTxtBox + "','" + Napomena + "','" + PutDoOtvoreneFakture + "')";

            OleDbCommand upis = new OleDbCommand(inDB, conn);
            upis.ExecuteNonQuery();
            conn.Close();

        }
        public void OdabirFaktureZaOtvaranje(string dir, string file)
        {

            ////odabir nasumične (prve) fakture za otvaranje, u koju se upisuje
            //foreach (string dir in dirs)
            //{
            //     MessageBox.Show(Otvorenafaktura);
            //    if (!FaktureNepodobneZaUcitavanje.Contains(dir.Replace("\\\\", "\\")))
            //    {
            //        Otvorenafaktura = dir.Replace("\\\\", "\\");
            //        break;
            //    }

            //}
            string[] dirs = Directory.GetFiles(dir, file, SearchOption.AllDirectories);
            foreach(string files in dirs)
            {                                         
                Otvorenafaktura = files;
            }           

            FormUcitavanje formUcitavanje = new FormUcitavanje();

            button_Zatvori.Hide();
            button_reset.Show();

            PutDoOtvoreneFakture = Otvorenafaktura;
            formSpremanje.OtvorenaFaktura = Otvorenafaktura;
            formUcitavanje.OtvorenaFaktura = Otvorenafaktura;
            formUcitavanje.ShowDialog();

            try
            {
                textBoxCijena.Text = File.ReadAllText(Application.StartupPath + "\\Cijena");
                textBoxRelacija.Text = File.ReadAllText(Application.StartupPath + "\\Relacija");
                textBoxPozicija.Text = File.ReadAllText(Application.StartupPath + "\\Pozicija");
                if(File.Exists(Application.StartupPath + "\\rabat"))
                {
                    textBoxRabat.Enabled = true;
                    string rabat = File.ReadAllText(Application.StartupPath + "\\rabat");
                    double dblRabat = Convert.ToDouble(rabat) * 100;
                    textBoxRabat.Text = Convert.ToString(dblRabat) + "%";
                }
                string PDV = File.ReadAllText(Application.StartupPath + "\\PDV");
                double dblPDV = Convert.ToDouble(PDV) * 100;
                textBoxPDV.Text = Convert.ToString(dblPDV) + "%";

                File.Delete(Application.StartupPath + "\\Cijena");
                File.Delete(Application.StartupPath + "\\Relacija");
                File.Delete(Application.StartupPath + "\\rabat");
                File.Delete(Application.StartupPath + "\\PDV");

            }
            catch { }
        }
        public void Povratak()
        {
            tableLayoutPanel1.Hide();
            tableLayoutPanelPocetno.Show();
            checkBoxSamoFaktura.Show();
            checkBoxSamoPredlosci.Show();
            buttonPopuniPremaPredlosku.Show();
        }
        public void browsanjee()
        {
            //ako je krivo kliknuto, na prazno
            if (listBox_spremljeneFakture.SelectedItem == null)
            {
                goto kraj;
            }

            //za dobivanje putanje
            string Klik = listBox_spremljeneFakture.SelectedItem.ToString() + "\\";
            Browse = Browse + Klik;            
            Ucitavanje++;
            listBox_spremljeneFakture.Items.Clear();

            //Odabir firme
            if (Ucitavanje == 2)
            {

                //////////////////////////////////////
                var dirInfo = new DirectoryInfo(Browse);
                FileInfo[] files = dirInfo.GetFiles("*.xlsx", SearchOption.AllDirectories);
                DateTime lastWrite = DateTime.MinValue;
                FileInfo lastWritenFile = null;

                foreach (FileInfo file in files)
                {
                    if(!FaktureNepodobneZaUcitavanje.Contains(file.ToString()))
                        if (file.LastWriteTime > lastWrite)
                        {
                            lastWrite = file.LastWriteTime;
                            lastWritenFile = file;
                        }
                }                              
                //////////////////////////////////////

                string[] dirs = Directory.GetFiles(Browse, "*.xlsx", SearchOption.AllDirectories);
                //FormUcitavanje formUcitavanje = new FormUcitavanje();
               // formUcitavanje.dirs = dirs;

                if (dirs.Length == 0)
                {
                    MessageBox.Show("Nema faktura u toj mapi!");
                    listBox_spremljeneFakture.Items.Clear();
                    listBox_spremljeneFakture.Hide();
                }

                //za schenker, redovne ture-> nalaze se unutar mape schenker
                //znači putanja je: Fakture\Schenker\Redovne\rute..
                else if (Browse.Contains("REDOVNE") || Browse.Contains("Redovne"))
                {
                    Schenker++;
                    Ucitavanje--;

                    //odabir rute i učitavanje faktura
                    if (Schenker == 2)
                    {
                        listBox_spremljeneFakture.Hide();
                        listBox_spremljeneFakture.Items.Clear();                        
                        button_Zatvori.Hide();
                        button_reset.Show();
                        File.WriteAllText(Application.StartupPath + "\\RelacijaIme", Klik.Replace("\\", ""));

                        checkBoxSamoFaktura.Show();
                        checkBoxSamoPredlosci.Show();
                        buttonPopuniPremaPredlosku.Show();

                        //Učitavanje faktura
                        formSpremanje.PutanjaOtvoreneFakture = Browse;

                        OdabirFaktureZaOtvaranje(Browse, lastWritenFile.ToString());
                        
                    }

                    //tek otvorene redovne ture, ponovno učitavanje ruta
                    else
                    {
                        //////////////////////////////////////
                         dirInfo = new DirectoryInfo(Browse);
                         files = dirInfo.GetFiles("*.xlsx", SearchOption.AllDirectories);
                         lastWrite = DateTime.MinValue;
                         lastWritenFile = null;

                        foreach (FileInfo file in files)
                        {
                            if (!FaktureNepodobneZaUcitavanje.Contains(file.ToString()))
                                if (file.LastWriteTime > lastWrite)
                                {
                                    lastWrite = file.LastWriteTime;
                                    lastWritenFile = file;
                                }
                        }
                        //////////////////////////////////////

                        string[] PonovnoUcitavanje = System.IO.Directory.GetDirectories(Browse, "*", SearchOption.TopDirectoryOnly);
                        foreach (string dir in PonovnoUcitavanje)
                        {
                            string entry2 = Path.GetFileName(dir);
                            listBox_spremljeneFakture.Items.Add(entry2);
                        }
                    }
                }//još sve od schenkera^^^^^^

                //učitavanje normalnih (ne shenker) faktura
                else
                {
                    listBox_spremljeneFakture.Hide();
                    groupBox3.Hide();
                    listBox_spremljeneFakture.Items.Clear();
                    button_Zatvori.Hide();
                    button_reset.Show();
                    File.WriteAllText(Application.StartupPath + "\\RelacijaIme", Klik.Replace("\\", ""));

                    checkBoxSamoFaktura.Show();
                    checkBoxSamoPredlosci.Show();
                    buttonPopuniPremaPredlosku.Show();
                    
                    formSpremanje.PutanjaOtvoreneFakture = Browse;

                    OdabirFaktureZaOtvaranje(Browse, lastWritenFile.ToString());

                }
            }

            //učitavanje firma
            else
            {
                //////////////////////////////////////
                var dirInfo = new DirectoryInfo(Browse);
                FileInfo[] files = dirInfo.GetFiles("*.xlsx", SearchOption.AllDirectories);
                DateTime lastWrite = DateTime.MinValue;
                FileInfo lastWritenFile = null;

                foreach (FileInfo file in files)
                {
                    if (!FaktureNepodobneZaUcitavanje.Contains(file.ToString()))
                        if (file.LastWriteTime > lastWrite)
                        {
                            lastWrite = file.LastWriteTime;
                            lastWritenFile = file;
                        }
                }
                //////////////////////////////////////
                string[] PonovnoUcitavanje = System.IO.Directory.GetDirectories(Browse, "*", SearchOption.TopDirectoryOnly);
                foreach (string dir in PonovnoUcitavanje)
                {
                    string entry2 = Path.GetFileName(dir);
                    listBox_spremljeneFakture.Items.Add(entry2);
                }
            }
        kraj:
            listBox_spremljeneFakture.Refresh();
        }
        public void ProvjeraBrojaFakture()
        {
            //provjera dak fakture s tim imenom već postoji
            foreach (string name in data)
            {
                if (name.Contains(textBrFakture.Text))
                {
                    MessageBox.Show("Faktura s tim brojem već postoji!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ProvjeraFakture = 1;
                    break;
                }
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //dobivanje direktorija (frima) iz faktura
            //////////////////////////////////////
            var dirInfo = new DirectoryInfo(put + listBox_novaRuta.SelectedItem.ToString());
            FileInfo[] files = dirInfo.GetFiles("*.xlsx", SearchOption.AllDirectories);
            DateTime lastWrite = DateTime.MinValue;
            FileInfo lastWritenFile = null;

            foreach (FileInfo file in files)
            {
                if (!FaktureNepodobneZaUcitavanje.Contains(file.ToString()))
                    if (file.LastWriteTime > lastWrite)
                    {
                        lastWrite = file.LastWriteTime;
                        lastWritenFile = file;
                    }
            }
            //////////////////////////////////////

            string[] dirs = System.IO.Directory.GetFiles(put + listBox_novaRuta.SelectedItem.ToString(), "*.xlsx", SearchOption.AllDirectories);
            FormUcitavanje form = new FormUcitavanje();
            form.dirs = dirs;

            if (dirs.Length == 0)
            {
                MessageBox.Show("Nema faktura u toj mapi!");
            }
            else 
            {
                checkBoxSamoFaktura.Show();
                checkBoxSamoPredlosci.Show();
                buttonPopuniPremaPredlosku.Show();

                //ako je nova ruta,učitaj fakturu s root direktorija i spremi u firmu na koju je kliknuti na listbox1
                if (NovaRuta == true)
                {                   
                    listBox_novaRuta.Hide();
                    groupBox3.Hide();
                    //dodavanje putanje, to je dovoljno-> Fakture\Firma\
                    formSpremanje.PutanjaOtvoreneFakture = put + listBox_novaRuta.SelectedItem.ToString();

                    // u "OdabirFaktureZaOtvaranje" se rješava sve
                    OdabirFaktureZaOtvaranje(put + listBox_novaRuta.SelectedItem.ToString(), lastWritenFile.ToString());
                    //sitnice..
                    listBox_novaRuta.Items.Clear();
                    button_Zatvori.Hide();
                    textBoxCijena.Clear();
                    textBoxRelacija.Clear();
                    textBoxPozicija.Clear();
                    MessageBox.Show("Učitano","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    //Učitavanje faktura                  
                    listBox_novaRuta.Hide();
                    listBox_novaRuta.Items.Clear();
                    button_Zatvori.Hide();
                    formSpremanje.PutanjaOtvoreneFakture = put + listBox_novaRuta.SelectedItem.ToString();
                    OdabirFaktureZaOtvaranje(put + listBox_novaRuta.SelectedItem.ToString(), lastWritenFile.ToString());
                }
            }
            

        }       
        private void spremi_Click(object sender, EventArgs e)
        {
           
            if (pom >= 1)
            {
                MessageBox.Show("Već ste jedanput kliknuli! Klikni na RESET!");
            }

            if ( (textBrFakture.Text.Length != 0 && textDatum.Text.Length != 0) && comboBoxKombi.Text.Length != 0)
            {
                try
                {
                    textBoxRabat.Text = textBoxRabat.Text.Replace("%", "");
                    textBoxPDV.Text=  textBoxPDV.Text.Replace("%", "");

                    ProvjeraBrojaFakture();

                    //dodavanje novog vozaca za combobox
                    bool vozacBool = false;
                    foreach (string vozac in vozaci)
                    {
                        if (vozac == comboBoxVozač.Text.ToString())
                            vozacBool = true;
                    }
                    if (!vozacBool)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Fakture\\vozaci", Environment.NewLine);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Fakture\\vozaci", comboBoxVozač.Text.ToString());
                        
                    }

                    if (ProvjeraFakture <= 0)
                {
                    // If database doesn't exists, then copy original with name in comboBox1 
                    if (!comboBoxKombi.Items.Contains(comboBoxKombi.Text))
                    {
                        string start = Application.StartupPath + "\\Fakture\\BazaKombi.mdb";
                        System.IO.File.Copy(start, Application.StartupPath + "\\Vozila\\" + comboBoxKombi.Text + ".mdb");
                    }
                    if (comboBoxVozač.Text.Length == 0) comboBoxVozač.Text = "-";
                    if (textBoxCijenaTure.Text.Length == 0) textBoxCijenaTure.Text = "0";
                    if (textBoxCestarina.Text.Length == 0) textBoxCestarina.Text = "0";
                    if (textBoxKilometri.Text.Length == 0) textBoxKilometri.Text = "0";
                    if (textBoxGorivo.Text.Length == 0) textBoxGorivo.Text = "0";
                    if (textBoxVozacu.Text.Length == 0) textBoxVozacu.Text = "0";
                    if (textBoxNama.Text.Length == 0) textBoxNama.Text = "0";
                    if (textBoxNapomena.Text.Length == 0) textBoxNapomena.Text = "-";
                    if (textBoxRabat.Text.Length == 0) textBoxRabat.Text = "0";
                        if (textBoxPotrosnja.Text.Length == 0) textBoxPotrosnja.Text = "0";

                        SigurnosnoSpremanje();

                        formSpremanje.DatumOd = dateTimePickerOd.Value.ToShortDateString();
                        formSpremanje.DatumDo = dateTimePickerDo.Value.ToShortDateString();
                        formSpremanje.Kolicina = textBoxKolicina.Text;
                        formSpremanje.BrojFakture = textBrFakture.Text;

                       
                        double rab = Convert.ToDouble(textBoxRabat.Text);
                        rab /= 100;
                        formSpremanje.rabat = rab;

                        double pdv = Convert.ToDouble(textBoxPDV.Text);
                        pdv /= 100;
                        formSpremanje.PDV = pdv.ToString();
                      // textBoxCijenaTure.Text = (Convert.ToDouble(textBoxCestarina) + Convert.ToDouble(textBoxNama) + Convert.ToDouble(textBoxVozacu) + Convert.ToDouble(textBoxGorivo)).ToString();
                        formSpremanje.ShowDialog();
                    }
                ProvjeraFakture = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                { }
            }
            else MessageBox.Show("NISTE UNIJELI DATUM I/ILI BROJ FAKTURE I/ILI REGISTRACIJU VOZILA!");
        }       
        private void textBoxCestarina_TextChanged(object sender, EventArgs e)
        {
            //check if there are numbers in text and delete content if not
            string n = textBoxCestarina.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxCestarina.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxCestarina.Clear();
            }
            
            formSpremanje.Cestarina = textBoxCestarina.Text;
        }

        private void textBoxCijenaTure_TextChanged(object sender, EventArgs e)
        {
            //check if there are numbers in text and delete content if not
            string n = textBoxCijenaTure.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxCijenaTure.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxCijenaTure.Clear();
            }
            formSpremanje.CijenaTure = textBoxCijenaTure.Text;
        }

        private void textBoxNama_TextChanged(object sender, EventArgs e)
        {
            //check if there are numbers in text and delete content if not
            string n = textBoxNama.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxNama.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxNama.Clear();
            }
            formSpremanje.Nama = textBoxNama.Text;
        }

        private void textBoxGorivo_TextChanged(object sender, EventArgs e)
        {
            //check if there are numbers in text and delete content if not
            string n = textBoxGorivo.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxGorivo.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxGorivo.Clear();
            }
            formSpremanje.Gorivo = textBoxGorivo.Text;
        }       
        
        private void izlaz_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Želite li stvarno zatvoriti program?", "IZLAZ",MessageBoxButtons.YesNo, MessageBoxIcon.Question)  ==  DialogResult.Yes)
            {
                File.Delete(Application.StartupPath + "\\Cijena");
                File.Delete(Application.StartupPath + "\\Relacija");
                File.Delete(Application.StartupPath + "\\StupacRelacija");
                File.Delete(Application.StartupPath + "\\RedRelacija");
                File.Delete(Application.StartupPath + "\\RelacijaIme");
                File.Delete(Application.StartupPath + "\\Pozicija");

                Process.Start(Application.StartupPath + "\\Fakture\\SyncToy.bat");
                      foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                      {
                          proc.Kill();
                      }
                      this.Close();
              }
        }    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            formSpremanje.DatumDvo = textBoxDVO.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textDatum.Text = textBoxDatumValute.Text;
            formSpremanje.DatumValuta = textBoxDatumValute.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBrFakture.Text = textBoxBrojFakture.Text;            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            formSpremanje.Kolicina = textBoxKolicina.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            formSpremanje.CijenaFakture = textBoxCijena.Text;
        }

        private void AP_Balažinec_Load(object sender, EventArgs e)
        {
            groupBox3.Hide();
            textBoxRabat.Enabled = false;
            tableLayoutPanel1.Hide();

            radioNePlaceno.Checked = true;
            formSpremanje.DatumOd = dateTimePickerOd.Value.ToShortDateString();
            formSpremanje.DatumDo = dateTimePickerDo.Value.ToShortDateString();

            listBox_novaRuta.Hide();
            listBox_spremljeneFakture.Hide();
            button_Zatvori.Hide();
            try
            {
                //učitavanje vozača u combobox za odabir
                vozaci = System.IO.File.ReadAllLines(Application.StartupPath + "\\Fakture\\vozaci");
                foreach( string vozac in vozaci)
                {
                    comboBoxVozač.Items.Add(vozac);
                }
                //čitaj imena fakture da ne bi došlo do redundancije
                data = System.IO.File.ReadAllLines(Application.StartupPath + "\\Fakture\\data");

                //Učitavanje...
                put = System.IO.File.ReadAllText(Application.StartupPath + "\\Fakture\\PutFakture.txt");
                FaktureNepodobneZaUcitavanje = File.ReadAllText(Application.StartupPath + "\\Fakture\\FaktureNepodobneZaUcitavanje");

                //Adding vehicles registrations to comboBox1 for easier use
                string[] files = Directory.GetFiles(Application.StartupPath + "\\Vozila", "*.mdb", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    string ime = Path.GetFileNameWithoutExtension(file);
                    comboBoxKombi.Items.Add(ime);
                }
                Browse = put;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Nedostaje neka datoteka u programu!");
                this.Close();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            formSpremanje.Relacija = textBoxRelacija.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string pozicija = textBoxPozicija.Text;
            pozicija = pozicija.Replace("Pozicija:", "");
            pozicija = pozicija.Replace("POZICIJA:", "");
            textBoxPozicija.Text = pozicija;
            formSpremanje.Pozicija = textBoxPozicija.Text;
        }      

        private void pregledPlačenihNePlačenihFakturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sveukupnoPlačeneINePlačeneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSveukupno formSveukupno = new FormSveukupno();
            formSveukupno.Show();
        }

        private void pojedinačnoPlačeneINePlačeneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPojedinacno formpojedincano = new FormPojedinacno();
            formpojedincano.Show();
        }

        private void izmjenaPlačenihnePlačenihFakturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIzmjena formIzmjena = new FormIzmjena();
            formIzmjena.Show();
        }
       
        private void traženjePoBrojuFaktureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPretrazivanje formPoBrojuFakture = new FormPretrazivanje();
            formPoBrojuFakture.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormUpute formUpute = new FormUpute();
            formUpute.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanelPocetno.Hide();
            tableLayoutPanel1.Show();
        }

        private void buttonNovaRuta_Click(object sender, EventArgs e)
        {
            //checkBoxSamoFaktura.Hide();
            //checkBoxSamoPredlosci.Hide();
            //buttonPopuniPremaPredlosku.Hide();
            groupBox3.Show();
            button_Zatvori.Show();
            button_reset.Hide();

            textBoxRelacija.Enabled = true;
            formSpremanje.NovaRuta = true;
            NovaRuta = true;

            string[] dirs = System.IO.Directory.GetDirectories(put, "*", SearchOption.TopDirectoryOnly);

            foreach (string dir in dirs)
            {
                string entry1 = Path.GetFileName(dir);
                listBox_novaRuta.Items.Add(entry1);
                

            }
            listBox_novaRuta.Show();
        }                  

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            textBoxRelacija.Enabled = false;
            checkBoxSamoFaktura.Hide();
            checkBoxSamoPredlosci.Hide();
            buttonPopuniPremaPredlosku.Hide();
            button_Zatvori.Show();
            button_reset.Hide();
            listBox_spremljeneFakture.Items.Clear();
            Browse = put;
            Ucitavanje = 0;

            string[] dirs = Directory.GetDirectories(put, "*", SearchOption.TopDirectoryOnly);
            foreach (string dir in dirs)
                {
                    string entry2 = Path.GetFileName(dir);
                    listBox_spremljeneFakture.Items.Add(entry2);
                }
                listBox_spremljeneFakture.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Hide();
            listBox_novaRuta.Hide();
            listBox_spremljeneFakture.Hide();
            button_reset.Show();
            Browse = put;
            button_Zatvori.Hide();
            checkBoxSamoFaktura.Show();
            checkBoxSamoPredlosci.Show();
            buttonPopuniPremaPredlosku.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\Fakture\\SyncToy.bat");
                foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Application.Restart();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void dateTimePickerOd_ValueChanged(object sender, EventArgs e)
        {
            formSpremanje.DatumOd= dateTimePickerOd.Value.ToShortDateString();
        }

        private void dateTimePickerDo_ValueChanged(object sender, EventArgs e)
        {
            formSpremanje.DatumDo = dateTimePickerDo.Value.ToShortDateString();
        }

        private void textBoxVozacu_TextChanged(object sender, EventArgs e)
        {
            //check if there are numbers in text and delete content if not
            string n = textBoxVozacu.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxVozacu.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxVozacu.Clear();
            }
            formSpremanje.Vozacu = textBoxVozacu.Text;
        }

        private void textBoxKilometri_TextChanged(object sender, EventArgs e)
        {
            //check if there are numbers in text and delete content if not
            string n = textBoxKilometri.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxKilometri.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxKilometri.Clear();
            }
            formSpremanje.Kilometri = textBoxKilometri.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonNovaFirma_Click(object sender, EventArgs e)
        {

            Povratak();

            FormNovaFirma formNovaFirma = new FormNovaFirma();
            formNovaFirma.Show();

           
        }

        private void buttonNovaFirmaSlo_Click(object sender, EventArgs e)
        {
            Povratak();

            FormNovaFirmaSlo formNovaFirmaSlo = new FormNovaFirmaSlo();
            formNovaFirmaSlo.Show();
        }

        private void buttonNovaFirmaNjem_Click(object sender, EventArgs e)
        {
            Povratak();

            FormNovaFirmaNjem formNovaFirmaNjem = new FormNovaFirmaNjem();
            formNovaFirmaNjem.Show();
        }        

        private void buttonNovaFirmaEng_Click(object sender, EventArgs e)
        {
            Povratak();

            FormNovaFirmaEng formNovaFirmaEng = new FormNovaFirmaEng();
            formNovaFirmaEng.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formSpremanje.Registracija = comboBoxKombi.Text;
        }

        private void comboBoxVozač_SelectedIndexChanged(object sender, EventArgs e)
        {
            formSpremanje.comboBoxVozač = comboBoxVozač.Text;
        }

        private void textBoxNapomena_TextChanged(object sender, EventArgs e)
        {
            formSpremanje.Napomena = textBoxNapomena.Text;
        }

        private void radioPlaceno_CheckedChanged(object sender, EventArgs e)
        {
            formSpremanje.Placeno = true;
        }

        private void buttonPopuniPremaPredlosku_Click(object sender, EventArgs e)
        {
            
            //vraćanje vrijednosti
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Fakture\\SafeBase.mdb";

            //----------SQL instrukcija-----------\\
            string sql = "SELECT * FROM TableSafeBase";

            //klase za povezivanje na ACCESS bazu podataka//
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            OleDbCommand cmnd = new OleDbCommand(sql, conn);
            conn.Open();  //otvara spoj s bazom podataka
      
            try
            {
                using (OleDbDataReader Read = cmnd.ExecuteReader())
                {
                    while(Read.Read())
                    {
                        if (checkBoxSamoPredlosci.Checked)
                        {
                            textBoxDVO.Text = (Read["DVO"].ToString());
                            textBoxDatumValute.Text = (Read["DatumValute"].ToString());
                            textBoxBrojFakture.Text = (Read["BrFakture"].ToString());
                            textBoxKolicina.Text = (Read["Kolicina"].ToString());
                            textBoxCijena.Text = (Read["Cijena"].ToString());
                            textBoxRelacija.Text = (Read["Relacija"].ToString());
                            textBoxPozicija.Text = (Read["Pozicija"].ToString());
                            comboBoxKombi.Text = (Read["Kombi"].ToString());
                            comboBoxVozač.Text = (Read["Vozac"].ToString());
                            textBoxKilometri.Text = (Read["Kilometri"].ToString());
                            textBoxCestarina.Text = (Read["Cestarina"].ToString());
                            textBoxVozacu.Text = (Read["UdioVozacu"].ToString());
                            textBoxNama.Text = (Read["UdioNama"].ToString());
                            textBoxGorivo.Text = (Read["Gorivo"].ToString());
                            textBoxNapomena.Text = (Read["Napomena"].ToString());                           
                        }
                        if (checkBoxSamoFaktura.Checked)
                        {
                            PutDoOtvoreneFakture = (Read["Faktura"].ToString());
                           
                        }
                    }
                }

                if (checkBoxSamoFaktura.Checked && PutDoOtvoreneFakture != null)
                {
                    //otvaranje fakture
                    FormUcitavanje formUcitavanje = new FormUcitavanje();

                    button_Zatvori.Hide();
                    button_reset.Show();

                    formSpremanje.OtvorenaFaktura = PutDoOtvoreneFakture;
                    formUcitavanje.OtvorenaFaktura = PutDoOtvoreneFakture;
                    AP_Balažinec formHome = new AP_Balažinec();
                    formHome.Enabled = false;
                    formUcitavanje.ShowDialog();
                    formHome.Enabled = true;
                  
                }
                if (checkBoxSamoFaktura.Checked && PutDoOtvoreneFakture == null)
                {
                    MessageBox.Show("Nije moguće popuniti prema zadnjem predlošku.Pokušajte prvo ispisati neku fakturu.");
                }
                try
                {                   
                    File.Delete(Application.StartupPath + "\\Cijena");
                    File.Delete(Application.StartupPath + "\\Relacija");
                    File.Delete(Application.StartupPath + "\\Pozicija");
                }
                catch { }


                //brisanje nepotrebnog
                OleDbCommand brisanje = new OleDbCommand("DELETE * FROM TableSafeBase", conn);
                brisanje.ExecuteNonQuery();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Došlo je do greške.");
            }
        }

        private void listBox_spremljeneFakture_DoubleClick(object sender, EventArgs e)
        {
            browsanjee();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPotrosnja_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxPotrosnja.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxPotrosnja.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxPotrosnja.Clear();
            }
            formSpremanje.Potrosnja = textBoxPotrosnja.Text;
        }

        private void radioNePlaceno_CheckedChanged(object sender, EventArgs e)
        {
            formSpremanje.Placeno = false;
        }
    }
}


            