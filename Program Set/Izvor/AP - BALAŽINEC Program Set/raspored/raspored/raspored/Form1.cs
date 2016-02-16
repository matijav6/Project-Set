using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Threading;
using Microsoft.Office.Tools.Excel;



namespace raspored
{
    public partial class Form1 : Form
    {
        string put;
        public Form1()
        {
            InitializeComponent();
            progressBar1.MarqueeAnimationSpeed = 40;
            string put1 = System.IO.File.ReadAllText(Application.StartupPath + "\\Raspored\\PutanjaRaspored.txt");
            put = Convert.ToString(put1);

        }
        Excel.Application excelApp = new Excel.Application();
        OleDbConnection conn = new OleDbConnection();

        private void Izlaz_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();

        }

        private void txtDan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int i = 0;        
        private void NapraviRaspored_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                MessageBox.Show("Prvo resetirajte program da bi napravili drugi raspored!");
                goto kraj;
            }
            i++;
            progressBar1.Style = ProgressBarStyle.Continuous;
            this.progressBar1.Increment(10);

            if (txtDan.Text.Length == 0)
            {
                MessageBox.Show("UNESI DATUM!");
            }
            if (txtDan.Text.Length != 0)
            {
                string path1 = Application.StartupPath + "\\Raspored\\Tjedan1.xlsx";
                string path2 = Application.StartupPath + "\\Raspored\\Tjedan2.xlsx";
                string path3 = Application.StartupPath + "\\Raspored\\Tjedan3.xlsx";
                string path4 = Application.StartupPath + "\\Raspored\\Tjedan4.xlsx";
                string KolnPath = Application.StartupPath + "\\Raspored\\koln.xlsx";

                string zadnji = System.IO.File.ReadAllText(Application.StartupPath + "\\Raspored\\ZadnjiRaspored.txt");
                string za = Convert.ToString(zadnji);
                this.progressBar1.Increment(10);


                //*********************** DATUMI *************************\\

                //********** TJEDAN1 **********\\

                var datum = Convert.ToDateTime(txtDan.Text);
                string datum1Prikaz = datum.ToShortDateString();
                DateTime datum1 = datum.AddDays(6);                 //kraj 1. tjedna
                string datum6Prikaz = datum1.ToShortDateString();

                DateTime datum2 = datum.AddDays(7);
                string datum7Prikaz = datum2.ToShortDateString();
                DateTime datum3 = datum.AddDays(13);                //kraj 2. tjedna
                string datum13Prikaz = datum3.ToShortDateString();

                DateTime datum4 = datum.AddDays(14);
                string datum14Prikaz = datum4.ToShortDateString();
                DateTime datum5 = datum.AddDays(20);                //kraj 3. tjedna
                string datum20Prikaz = datum5.ToShortDateString();

                DateTime datum6 = datum.AddDays(21);
                string datum21Prikaz = datum6.ToShortDateString();
                DateTime datum7 = datum.AddDays(27);                //kraj 4. tjedna      
                string datum27Prikaz = datum7.ToShortDateString();

                //********** TJEDAN2 **********\\

                DateTime datum8 = datum.AddDays(2);
                string datum2Prikaz2 = datum8.ToShortDateString();

                DateTime datum10 = datum.AddDays(9);
                string datum2Prikaz9 = datum10.ToShortDateString();

                DateTime datum12 = datum.AddDays(16);
                string datum2Prikaz16 = datum12.ToShortDateString();

                DateTime datum14 = datum.AddDays(23);
                string datum2Prikaz23 = datum14.ToShortDateString();

                //********** TJEDAN3 **********\\
                this.progressBar1.Increment(10);
                DateTime datum15 = datum.AddDays(1);
                string datum3Prikaz1 = datum15.ToShortDateString();

                DateTime datum16 = datum.AddDays(8);
                string datum3Prikaz8 = datum16.ToShortDateString();

                DateTime datum17 = datum.AddDays(22);
                string datum3Prikaz22 = datum17.ToShortDateString();

                //********** TJEDAN5 **********\\

                DateTime datum19 = datum.AddDays(15);
                string datum4Prikaz1 = datum19.ToShortDateString();

                //********** KOLN **********\\

                DateTime datum18 = datum.AddDays(18);
                string datum4Prikaz18 = datum18.ToShortDateString();

                //*********************** KRAJ DATUMA! *************************\\

                this.progressBar1.Increment(10);
                if (za == "Aleksandar")
                {
                    this.progressBar1.Increment(10);
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                    excelApp.Workbooks.Open(path1);
                    excelApp.Cells[3, 1] = "Željko";
                    excelApp.Cells[5, 4] = datum;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum1Prikaz + " - " + datum6Prikaz + ".xlsx");
                    excelApp.Cells[3, 1] = "Nikola";
                    excelApp.Cells[5, 4] = datum2;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum7Prikaz + " - " + datum13Prikaz + ".xlsx");
                    excelApp.Cells[3, 1] = "Nikola";
                    excelApp.Cells[5, 4] = datum4;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum14Prikaz + " - " + datum20Prikaz + ".xlsx");
                    excelApp.Cells[3, 1] = "Aleksandar";
                    excelApp.Cells[5, 4] = datum6;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum21Prikaz + " - " + datum27Prikaz + ".xlsx");                 
                    conn.Close();
                    this.progressBar1.Increment(10);
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path2 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                    excelApp.Workbooks.Open(path2);
                    excelApp.Cells[3, 1] = "Željko";
                    excelApp.Cells[9, 4] = datum12;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum2Prikaz16 + " - " + datum20Prikaz + ".xlsx");
                    excelApp.Cells[3, 1] = "Željko";
                    excelApp.Cells[9, 4] = datum14;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum2Prikaz23 + " - " + datum27Prikaz + ".xlsx");
                    excelApp.Cells[3, 1] = "Nikola";
                    excelApp.Cells[9, 4] = datum8;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum2Prikaz2 + " - " + datum6Prikaz + ".xlsx");
                    excelApp.Cells[3, 1] = "Aleksandar";
                    excelApp.Cells[9, 4] = datum10;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum2Prikaz9 + " - " + datum13Prikaz + ".xlsx");
                   conn.Close();
                   this.progressBar1.Increment(10);
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path3 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                    excelApp.Workbooks.Open(path3);
                    excelApp.Cells[3, 1] = "Željko";
                    excelApp.Cells[7, 4] = datum16;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum3Prikaz8 + " - " + datum13Prikaz + ".xlsx");
                    excelApp.Cells[3, 1] = "Nikola";
                    excelApp.Cells[7, 4] = datum17;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum3Prikaz22 + " - " + datum27Prikaz + ".xlsx");
                    excelApp.Cells[3, 1] = "Aleksandar";
                    excelApp.Cells[7, 4] = datum15;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum3Prikaz1 + " - " + datum6Prikaz + ".xlsx");  
                    conn.Close();
                    this.progressBar1.Increment(10);
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path4 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                    excelApp.Workbooks.Open(path4);
                    excelApp.Cells[3, 1] = "Aleksandar";
                    excelApp.Cells[7, 4] = datum19;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum4Prikaz1 + " - " + datum20Prikaz + ".xlsx");
                    this.progressBar1.Increment(10);
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + KolnPath + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                    excelApp.Workbooks.Open(KolnPath);
                    excelApp.Cells[3, 1] = "Tihomir,Tomica";
                    excelApp.Cells[15, 4] = datum18;
                    excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\TOMICA,TIHOMIR\\NOVI\\" + datum4Prikaz18 + " - " + datum20Prikaz + ".xlsx");
                    conn.Close();
                    this.progressBar1.Increment(10);
                    File.Delete(Application.StartupPath + "\\Raspored\\ZadnjiRaspored.txt");
                    string text = "Zeljko";
                    System.IO.File.WriteAllText(Application.StartupPath + "\\Raspored\\ZadnjiRaspored.txt", text);
                    this.progressBar1.Increment(10);
                }
                     if (za == "Zeljko")
                  {
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(path1);
                      excelApp.Cells[3, 1] = "Nikola";
                      excelApp.Cells[5, 4] = datum;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum1Prikaz + " - " + datum6Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Aleksandar";
                      excelApp.Cells[5, 4] = datum2;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum7Prikaz + " - " + datum13Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Aleksandar";
                      excelApp.Cells[5, 4] = datum4;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum14Prikaz + " - " + datum20Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Željko";
                      excelApp.Cells[5, 4] = datum6;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum21Prikaz + " - " + datum27Prikaz + ".xlsx");
                      conn.Close();
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path2 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(path2);
                      excelApp.Cells[3, 1] = "Nikola";
                      excelApp.Cells[9, 4] = datum12;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum2Prikaz16 + " - " + datum20Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Nikola";
                      excelApp.Cells[9, 4] = datum14;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum2Prikaz23 + " - " + datum27Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Aleksandar";
                      excelApp.Cells[9, 4] = datum8;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum2Prikaz2 + " - " + datum6Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Željko";
                      excelApp.Cells[9, 4] = datum10;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum2Prikaz9 + " - " + datum13Prikaz + ".xlsx");
                      conn.Close();
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path3 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(path3);
                      excelApp.Cells[3, 1] = "Nikola";
                      excelApp.Cells[7, 4] = datum16;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum3Prikaz8 + " - " + datum13Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Aleksandar";
                      excelApp.Cells[7, 4] = datum17;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum3Prikaz22 + " - " + datum27Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Željko";
                      excelApp.Cells[7, 4] = datum15;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum3Prikaz1 + " - " + datum6Prikaz + ".xlsx");
                      conn.Close();
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path4 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(path4);
                      excelApp.Cells[3, 1] = "Željko";
                      excelApp.Cells[7, 4] = datum19;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum4Prikaz1 + " - " + datum20Prikaz + ".xlsx");
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + KolnPath + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(KolnPath);
                      excelApp.Cells[3, 1] = "Tihomir,Tomica";
                      excelApp.Cells[15, 4] = datum18;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\TOMICA,TIHOMIR\\NOVI\\" + datum4Prikaz18 + " - " + datum20Prikaz + ".xlsx");
                      conn.Close();
                      this.progressBar1.Increment(10);
                      File.Delete(Application.StartupPath + "\\Raspored\\ZadnjiRaspored.txt");
                      string text = "Nikola";
                      System.IO.File.WriteAllText(Application.StartupPath + "\\Raspored\\ZadnjiRaspored.txt", text);
                      this.progressBar1.Increment(10);
                  }

                  if (za == "Nikola")
                  {
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(path1);
                      excelApp.Cells[3, 1] = "Aleksandar";
                      excelApp.Cells[5, 4] = datum;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum1Prikaz + " - " + datum6Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Željko";
                      excelApp.Cells[5, 4] = datum2;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum7Prikaz + " - " + datum13Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Željko";
                      excelApp.Cells[5, 4] = datum4;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum14Prikaz + " - " + datum20Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Nikola";
                      excelApp.Cells[5, 4] = datum6;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum21Prikaz + " - " + datum27Prikaz + ".xlsx");
                      conn.Close();
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path2 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(path2);
                      excelApp.Cells[3, 1] = "Aleksandar";
                      excelApp.Cells[9, 4] = datum12;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum2Prikaz16 + " - " + datum20Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Aleksandar";
                      excelApp.Cells[9, 4] = datum14;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum2Prikaz23 + " - " + datum27Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Željko";
                      excelApp.Cells[9, 4] = datum8;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum2Prikaz2 + " - " + datum6Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Nikola";
                      excelApp.Cells[9, 4] = datum10;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum2Prikaz9 + " - " + datum13Prikaz + ".xlsx");
                      conn.Close();
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path3 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(path3);
                      excelApp.Cells[3, 1] = "Aleksandar";
                      excelApp.Cells[7, 4] = datum16;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ALEKSANDAR POZDER\\NOVI\\" + datum3Prikaz8 + " - " + datum13Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Željko";
                      excelApp.Cells[7, 4] = datum17;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\ŽELJKO BENKOVIĆ\\NOVI\\" + datum3Prikaz22 + " - " + datum27Prikaz + ".xlsx");
                      excelApp.Cells[3, 1] = "Nikola";
                      excelApp.Cells[7, 4] = datum15;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum3Prikaz1 + " - " + datum6Prikaz + ".xlsx");
                      conn.Close();
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path4 + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(path4);
                      excelApp.Cells[3, 1] = "Nikola";
                      excelApp.Cells[7, 4] = datum19;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\NIKOLA HIŽAK\\NOVI\\" + datum4Prikaz1 + " - " + datum20Prikaz + ".xlsx");
                      this.progressBar1.Increment(10);
                      conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + KolnPath + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                      excelApp.Workbooks.Open(KolnPath);
                      excelApp.Cells[3, 1] = "Tihomir,Tomica";
                      excelApp.Cells[15, 4] = datum18;
                      excelApp.ActiveWorkbook.SaveCopyAs(put + "\\TJEDNI RASPORED\\TOMICA,TIHOMIR\\NOVI\\" + datum4Prikaz18 + " - " + datum20Prikaz + ".xlsx");
                      conn.Close();
                      this.progressBar1.Increment(10);
                      File.Delete(Application.StartupPath + "\\Raspored\\ZadnjiRaspored.txt");
                      string text = "Aleksandar";
                      System.IO.File.WriteAllText(Application.StartupPath + "\\Raspored\\ZadnjiRaspored.txt", text);
                      this.progressBar1.Increment(10);
                  }
                
                MessageBox.Show("Raspored uspješno napravljen!");
                SpremanjeZaSync();
            }
                        
            kraj:
            this.progressBar1.Increment(100);
        }

        public void SpremanjeZaSync()
        {
            //    string ime = put + "\\TJEDNI RASPORED";
            //    string puta = Application.StartupPath + "\\tmp\\Raspored.txt";
            //File.WriteAllText(puta, ime);
            //File.WriteAllText(Application.StartupPath + "\\tmp\\ZadnjiRaspored.txt","ZadnjiRaspored.txt");
        }
        private void prviTjedan_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime datum = monthCalendar1.SelectionRange.Start;
            txtDan.Text = datum.ToString("dd.MM.yyyy");




        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(put + "\\TJEDNI RASPORED\\");
            System.Diagnostics.Process.Start(put + "\\TJEDNI RASPORED\\");
        }
    }
}
