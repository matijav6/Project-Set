using System;
using System.Windows.Forms;

namespace Kombiji
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonUnos_Click(object sender, EventArgs e)
        {
            FormUnos formUnos = new FormUnos();
            formUnos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPretrazi formPretrazi = new FormPretrazi();
            formPretrazi.Show();
        }

        private void buttonIzmjena_Click(object sender, EventArgs e)
        {
            FormIzmjena formIzmjena = new FormIzmjena();
            formIzmjena.Show();
        }        
    }
}
