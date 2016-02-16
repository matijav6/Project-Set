using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Program_Set
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Hide();
        }

        int i = 0;
        private void buttonFakture_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("AP-Balažinec").Length > 0) MessageBox.Show("Već ste kliknuli,pričekajte trenutak ili provjerite da li je već program otvoren!");
            else
            {
                i++;
                WindowsFormApplication1.AP_Balažinec fakture = new WindowsFormApplication1.AP_Balažinec();
                fakture.Show();
            }      
        }

        private void buttonIzlaz_Click(object sender, EventArgs e)
        {
            //Process.Start("SyncToy.bat");   //za sinkronizaciju
            Close();
        }

        private void buttonPonuda_Click(object sender, EventArgs e)
        {
             if (Process.GetProcessesByName("Ponuda").Length > 0) MessageBox.Show("Već ste kliknuli,pričekajte trenutak ili provjerite da li je već program otvoren!");
            else
            {
                i++;
                Ponuda.Form1 pon = new Ponuda.Form1();
                pon.Show();
            }
        }

        private void buttonRaspored_Click(object sender, EventArgs e)
        {
             if (Process.GetProcessesByName("raspored").Length > 0) MessageBox.Show("Već ste kliknuli,pričekajte trenutak ili provjerite da li je već program otvoren!");
            else
            {
                i++;
                raspored.Form1 raspored = new raspored.Form1();
                raspored.Show();
            }
        }

        private void buttonNalozi_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("Nalozi").Length > 0) MessageBox.Show("Već ste kliknuli,pričekajte trenutak ili provjerite da li je već program otvoren!");
            else
            {
                i++;
                WindowsFormApplication1.Nalozi nalozi = new WindowsFormApplication1.Nalozi();
                nalozi.Show();
            }
        }

        private void buttonKombiji_Click(object sender, EventArgs e)
        {
            Kombiji.Form1 formKombiji = new Kombiji.Form1();
            formKombiji.Show();
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            buttonSync.Hide();
            label3.Show();
            //FormSync formSync = new FormSync();
            //formSync.ShowDialog();          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Evidencija_otpremnica.Form1 evidencija = new Evidencija_otpremnica.Form1();
            evidencija.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintCMR_nmspace.FormSpremanje printCMR = new PrintCMR_nmspace.FormSpremanje();
            printCMR.ShowDialog();
        }

        private void button_CijeneUxl_Click(object sender, EventArgs e)
        {
            Cijene.FormHome fromCijene = new Cijene.FormHome();
            fromCijene.ShowDialog();
        }
    }
}
