using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koln_Raspored
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string[] glavni = System.IO.File.ReadAllLines(Application.StartupPath + "\\bin\\glavniVozaci.txt");           
            string[] ostaliVozaci = System.IO.File.ReadAllLines(Application.StartupPath + "\\bin\\ostaliVozaci.txt");
            string[] pomocniVozaci = System.IO.File.ReadAllLines(Application.StartupPath + "\\bin\\pomocniVozaci.txt");

            string pomGlavni = null, pomPomocni = null, pomOstali = null;
            for(int i = 0; i < ostaliVozaci.Count(); i++)
            {
                ListViewItem item1 = null;

                if (i >= glavni.Count())
                    pomGlavni = "";
                else
                    pomGlavni = glavni[i];

                if (i >= pomocniVozaci.Count())
                    pomPomocni = "";
                else
                    pomPomocni = pomocniVozaci[i];

                pomOstali = ostaliVozaci[i];
                item1 = new ListViewItem(new[] { pomGlavni, pomPomocni, pomOstali });

                listView1.Items.Add(item1);
            }                
            
        }
    }
}
