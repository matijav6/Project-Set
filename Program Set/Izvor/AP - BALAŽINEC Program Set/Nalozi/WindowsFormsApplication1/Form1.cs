using System;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;



namespace WindowsFormApplication1
{
    public partial class Nalozi : Form
    {
            OpenFileDialog ofImport = new OpenFileDialog();
            Excel.Application excelApp = new Excel.Application();

            

        public Nalozi()
        {
             InitializeComponent();
            
        }

            
        private void otvori_Click(object sender, EventArgs e)
        {
            poc:
            ofImport.Title = "Odaberi nalog";
            ofImport.InitialDirectory = @"H:\SVI NALOZI";
            ofImport.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            ofImport.FilterIndex = 1;
            ofImport.RestoreDirectory = true;            
           
            if (ofImport.ShowDialog() == DialogResult.OK)
            {

                string path = System.IO.Path.GetFullPath(ofImport.FileName);              
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofImport.FileName + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                
                
                
               
                
            }
            else
            {
                goto poc;
            }
            

            // umetanje vrijednosti

            Microsoft.Office.Interop.Excel.Application ExcelObj = null;
            ExcelObj = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(ofImport.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
            Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
                        
            //nalog za utovar broj

            var a = (worksheet.Cells[15, 4] as Microsoft.Office.Interop.Excel.Range).Value;
            string slovo = Convert.ToString(a);
            nalog_br.Text = slovo;


            //datum utovara
           var utovar = (worksheet.Cells[38, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string utovar_string = Convert.ToString(utovar);
            if (utovar_string == "DATUM UTOVARA:")
            {
                 datum_ut.Text = Convert.ToString((worksheet.Cells[38, 4] as Microsoft.Office.Interop.Excel.Range).Value);

            }
            else  datum_ut.Text = Convert.ToString((worksheet.Cells[39, 4] as Microsoft.Office.Interop.Excel.Range).Value);


            ///izvozno carinjenje   
            var izvozno = (worksheet.Cells[40, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string izvozno_string = Convert.ToString(izvozno);
            if (izvozno_string == "IZVOZNO CARINJENJE:")
            {
                 izvozno_car.Text =  Convert.ToString((worksheet.Cells[40, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                textBox1.Text = Convert.ToString((worksheet.Cells[41, 4] as Microsoft.Office.Interop.Excel.Range).Value);
            }
            else
            {
                 izvozno_car.Text = Convert.ToString((worksheet.Cells[41, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                 textBox1.Text = Convert.ToString((worksheet.Cells[42, 4] as Microsoft.Office.Interop.Excel.Range).Value);

            }

            //vrsta robe
            var roba = (worksheet.Cells[43, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string roba_string = Convert.ToString(roba);
            if (roba_string == "VRSTA ROBE:")
            {
                  vrstarobe.Text = Convert.ToString((worksheet.Cells[43, 4] as Microsoft.Office.Interop.Excel.Range).Value);
            }
            else  vrstarobe.Text = Convert.ToString((worksheet.Cells[44, 4] as Microsoft.Office.Interop.Excel.Range).Value);


            //količina

            var količina1 = (worksheet.Cells[45, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string količina1_string = Convert.ToString(količina1);
            if (količina1_string == "KOLIČINA:")
            {
                if (količina_2.Text == "" && količina_3.Text == "")

                {
                      količina_1.Text = Convert.ToString((worksheet.Cells[45, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                      količina_2.Text = Convert.ToString((worksheet.Cells[46, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                      količina_3.Text = Convert.ToString((worksheet.Cells[47, 4] as Microsoft.Office.Interop.Excel.Range).Value);


            }
                else
                {

                    količina_1.Text = Convert.ToString((worksheet.Cells[45, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                    količina_2.Text = Convert.ToString((worksheet.Cells[46, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                    količina_3.Text = Convert.ToString((worksheet.Cells[47, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                }

            }


            var količina2 = (worksheet.Cells[46, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string količina2_string = Convert.ToString(količina2);
            if (količina2_string == "KOLIČINA:")
            {
                if (količina_2.Text == "" && količina_3.Text == "")
                {

                    količina_1.Text = Convert.ToString((worksheet.Cells[46, 4] as Microsoft.Office.Interop.Excel.Range).Value);

                }
                else
                {
                    količina_1.Text = Convert.ToString((worksheet.Cells[46, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                    količina_2.Text = Convert.ToString((worksheet.Cells[47, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                    količina_3.Text = Convert.ToString((worksheet.Cells[48, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                }

            }



            //uvozno carinjenje

            var carinjenje1 = (worksheet.Cells[67, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string carinjenje1_string = Convert.ToString(carinjenje1);
            if (carinjenje1_string == "UVOZNO CARINJENJE:")
            {
                uvozno_car1.Text = Convert.ToString((worksheet.Cells[68, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                uvozno_car2.Text = Convert.ToString((worksheet.Cells[69, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                datum_isto.Text =  Convert.ToString((worksheet.Cells[70, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                cijena_prijev.Text = Convert.ToString((worksheet.Cells[76, 4] as Microsoft.Office.Interop.Excel.Range).Value);
            }

            var carinjenje = (worksheet.Cells[64, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string carinjenje_string = Convert.ToString(carinjenje);
            if (carinjenje_string == "UVOZNO CARINJENJE:")
            {
                uvozno_car1.Text = Convert.ToString((worksheet.Cells[64, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                uvozno_car2.Text = Convert.ToString((worksheet.Cells[65, 4] as Microsoft.Office.Interop.Excel.Range).Value);
            }
            else
            {
                uvozno_car1.Text = Convert.ToString((worksheet.Cells[66, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                uvozno_car2.Text = Convert.ToString((worksheet.Cells[67, 4] as Microsoft.Office.Interop.Excel.Range).Value);
            }


            //datum istovara
            var datumistovara = (worksheet.Cells[67, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string datumistovara_string = Convert.ToString(datumistovara);
            if (datumistovara_string == "DATUM ISTOVARA:")
            {
                 datum_isto.Text = Convert.ToString((worksheet.Cells[67, 4] as Microsoft.Office.Interop.Excel.Range).Value);
            }
            else
                datum_isto.Text = Convert.ToString((worksheet.Cells[69, 4] as Microsoft.Office.Interop.Excel.Range).Value);


            //cijena prijevoza
            var cijenaprijevoza = (worksheet.Cells[71, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string cijenaprijevoza_string = Convert.ToString(cijenaprijevoza);
            if (cijenaprijevoza_string == "CIJENA PRIJEVOZA:")
            {
                 cijena_prijev.Text = Convert.ToString((worksheet.Cells[71, 4] as Microsoft.Office.Interop.Excel.Range).Value);
            }
            var cijenaprijevoza1 = (worksheet.Cells[69, 1] as Microsoft.Office.Interop.Excel.Range).Value;
            string cijenaprijevoza1_string = Convert.ToString(cijenaprijevoza1);
            if (cijenaprijevoza1_string == "CIJENA PRIJEVOZA:")
            {
                 cijena_prijev.Text = Convert.ToString((worksheet.Cells[69, 4] as Microsoft.Office.Interop.Excel.Range).Value);
            }
            else cijena_prijev.Text = Convert.ToString((worksheet.Cells[75, 4] as Microsoft.Office.Interop.Excel.Range).Value);
                      
                        
            MessageBox.Show("Nalog uspješno učitan!");
            
            
             
        }

        private void izlaz_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Želite li stvarno zatvoriti program?", "IZLAZ",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
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
            }
   

           
            
           
        private void umetni_Click(object sender, EventArgs e)
        {
           
               Microsoft.Office.Interop.Excel.Application ExcelObj = null;
                ExcelObj = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(ofImport.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
                excelApp.Workbooks.Open(ofImport.FileName);


                //nalog za utovar broj



                excelApp.Cells[15, 4] = nalog_br.Text;




                // adresa utovara   
                var adresautovara = (worksheet.Cells[24, 3] as Microsoft.Office.Interop.Excel.Range).Value;
                string adresautovara_string = Convert.ToString(adresautovara);
                if (adresautovara_string == "1.")
                {
                    excelApp.Cells[27, 4] = adresa_1.Text;
                    

                    excelApp.Cells[28, 4] = adresa_2.Text;

                    excelApp.Cells[29, 4] = adresa_3.Text;

                    excelApp.Cells[30, 4] = adresa_4.Text;

                }
                else
                {
                    excelApp.Cells[26, 4] = adresa_1.Text;

                    excelApp.Cells[27, 4] = adresa_2.Text;

                    excelApp.Cells[28, 4] = adresa_3.Text;

                    excelApp.Cells[29, 4] = adresa_4.Text;

                }
                //datum utovara
                var utovar = (worksheet.Cells[38, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string utovar_string = Convert.ToString(utovar);
                if (utovar_string == "DATUM UTOVARA:")
                {
                    excelApp.Cells[38, 4] = datum_ut.Text;

                }
                else excelApp.Cells[39, 4] = datum_ut.Text;


                ///izvozno carinjenje   
                var izvozno = (worksheet.Cells[40, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string izvozno_string = Convert.ToString(izvozno);
                if (izvozno_string == "IZVOZNO CARINJENJE:")
                {
                    excelApp.Cells[40, 4] = izvozno_car.Text;
                    excelApp.Cells[41, 4] = textBox1.Text;
                }
                else
                {
                    excelApp.Cells[41, 4] = izvozno_car.Text;
                    excelApp.Cells[42, 4] = textBox1.Text;

                }

                //vrsta robe
                var roba = (worksheet.Cells[43, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string roba_string = Convert.ToString(roba);
                if (roba_string == "VRSTA ROBE:")
                {
                    excelApp.Cells[43, 4] = vrstarobe.Text;
                }
                else excelApp.Cells[44, 4] = vrstarobe.Text;


                //količina

                var količina1 = (worksheet.Cells[45, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string količina1_string = Convert.ToString(količina1);
                if (količina1_string == "KOLIČINA:")
                {
                    if (količina_2.Text == "" && količina_3.Text == "")


                        excelApp.Cells[45, 4] = količina_1.Text;



                    else
                    {

                        excelApp.Cells[45, 4] = količina_1.Text;
                        excelApp.Cells[46, 4] = količina_2.Text;
                        excelApp.Cells[47, 4] = količina_3.Text;
                    }

                }


                var količina2 = (worksheet.Cells[46, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string količina2_string = Convert.ToString(količina2);
                if (količina2_string == "KOLIČINA:")
                {
                    if (količina_2.Text == "" && količina_3.Text == "")
                    {

                        excelApp.Cells[46, 4] = količina_1.Text;

                    }
                    else
                    {
                        excelApp.Cells[46, 4] = količina_1.Text;
                        excelApp.Cells[47, 4] = količina_2.Text;
                        excelApp.Cells[48, 4] = količina_3.Text;
                    }

                }



                //uvozno carinjenje

                var carinjenje1 = (worksheet.Cells[67, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string carinjenje1_string = Convert.ToString(carinjenje1);
                if (carinjenje1_string == "UVOZNO CARINJENJE:")
                {
                    excelApp.Cells[67, 4] = uvozno_car1.Text;
                    excelApp.Cells[68, 4] = uvozno_car2.Text;
                    excelApp.Cells[70, 4] = datum_isto.Text;
                    excelApp.Cells[76, 4] = cijena_prijev.Text;
                }

                var carinjenje = (worksheet.Cells[64, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string carinjenje_string = Convert.ToString(carinjenje);
                if (carinjenje_string == "UVOZNO CARINJENJE:")
                {
                    excelApp.Cells[64, 4] = uvozno_car1.Text;
                    excelApp.Cells[65, 4] = uvozno_car2.Text;
                }
                else
                {
                    excelApp.Cells[66, 4] = uvozno_car1.Text;
                    excelApp.Cells[67, 4] = uvozno_car2.Text;
                }


                //datum istovara
                var datumistovara = (worksheet.Cells[67, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string datumistovara_string = Convert.ToString(datumistovara);
                if (datumistovara_string == "DATUM ISTOVARA:")
                {
                    excelApp.Cells[67, 4] = datum_isto.Text;
                }
                else
                    excelApp.Cells[69, 4] = datum_isto.Text;


                //cijena prijevoza
                var cijenaprijevoza = (worksheet.Cells[71, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string cijenaprijevoza_string = Convert.ToString(cijenaprijevoza);
                if (cijenaprijevoza_string == "CIJENA PRIJEVOZA:")
                {
                    excelApp.Cells[71, 4] = cijena_prijev.Text;
                }
                var cijenaprijevoza1 = (worksheet.Cells[69, 1] as Microsoft.Office.Interop.Excel.Range).Value;
                string cijenaprijevoza1_string = Convert.ToString(cijenaprijevoza1);
                if (cijenaprijevoza1_string == "CIJENA PRIJEVOZA:")
                {
                    excelApp.Cells[69, 4] = cijena_prijev.Text;
                }
                else excelApp.Cells[75, 4] = cijena_prijev.Text;

          

                this.WindowState = FormWindowState.Minimized;

                excelApp.Visible = true;
            
                
            
}
         
          
        private void AP_Balažinec_Load(object sender, EventArgs e)
        {

        }

        private void nalog_br_TextChanged(object sender, EventArgs e)
        {

        }

        private void adresa_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void adresa_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void adresa_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void adresa_4_TextChanged(object sender, EventArgs e)
        {

        }

        private void datum_ut_TextChanged(object sender, EventArgs e)
        {

        }

        private void izvozno_car_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void vrstarobe_TextChanged(object sender, EventArgs e)
        {

        }

        private void količina_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void količina_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void količina_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void uvozno_car1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uvozno_car2_TextChanged(object sender, EventArgs e)
        {

        }

        private void datum_isto_TextChanged(object sender, EventArgs e)
        {

        }

        private void cijena_prijev_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

                                               
    }
}


            