using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMY
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//knopka dobavit
        {
            Form1 Main = this.Owner as Form1;//создаём объект Mainкласса Form1(наша основная форма) и указываем, что Main, и есть «родитель» формы 2
            //подобная связка позволит им взаимодействовать только при условии, что мы «откроем» необходимые поля.
            if (textBox1.Text != "")
            {
                if (this.radioButton1.Checked == true)
                Main.listBox1.Items.Add(this.textBox1.Text);
                else Main.listBox2.Items.Add(this.textBox1.Text);

                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)//knopka otmena
        {
            Application.Exit();
        }
    }
}
