using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace AppMY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // добавляем набор элементов
            //comboBox1.Items.AddRange(new string[] { "Уругвай", "Эквадор" });
            // добавляем один элемент на определенную позицию
            //comboBox1.Items.Insert(1, "Боливия");
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            richTextBox1.Click += richTextBox1_Click;

        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox2.SelectedItem.ToString();
            MessageBox.Show(selectedState);
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            // Задаем расширения файлов 
            OpenDlg.Filter = "Text files(*.TXT)|*.txt";
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }

            OpenDlg.Dispose();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            MessageBox.Show("Информация о приложении и разработчике");
        }

        private void button14_Click(object sender, EventArgs e)//knopka na4at
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.BeginUpdate();
            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in Strings)
            {
                string Str = s.Trim();
                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                }

            }
            listBox1.EndUpdate();

        }

        private void button13_Click(object sender, EventArgs e)//knopka vihod
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)//knopka sbros
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            richTextBox1.Clear();//????
            textBox1.Clear();//????
            //установить изначальное состояние свойства Checked у RadioButton и CheckBox
            radioButton1.Checked = true;
            checkBox1.Checked = true;

        }

        private void button11_Click(object sender, EventArgs e)//knopka poisk
        {
            listBox3.Items.Clear();
            string Find = textBox1.Text;
            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }


        }

        private void button6_Click(object sender, EventArgs e)//knopka dobavit
        {
            Form2 AddRec = new Form2(); //создали объект AddRec, т.е. создали форму ,svazivaem s form2
            AddRec.Owner = this; //родителем» этой новой формы является наша главная форма (свойство Owner)
            AddRec.ShowDialog();//открываем созданную форму, используя метод ShowDialog, который собственно и делает эту форму модульной.
        }

        private void button9_Click(object sender, EventArgs e)//knopka udalit
        {
            DeleteSelectedStrings();//listbox1 udalaet slova
            DeleteSelectedStrings2();//listbox2 udalaet slova
        }
        private void DeleteSelectedStrings()
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }
            
        }
        private void DeleteSelectedStrings2()
        {
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }

        }

        private void button1_Click(object sender, EventArgs e)//perenos iz listbox1 v listbox2
        {
            listBox2.BeginUpdate();
            foreach (object Item in listBox1.SelectedItems) 
            {
                listBox2.Items.Add(Item);
            }
            listBox2.EndUpdate();
        }

        private void button2_Click(object sender, EventArgs e)//perenos iz listbox2 v listbox1
        {
            listBox1.BeginUpdate();
            foreach (object Item in listBox2.SelectedItems)
            {
                listBox1.Items.Add(Item);
            }
            listBox1.EndUpdate();
        }

        private void button4_Click(object sender, EventArgs e)//perenos vsego iz listbox1 v listbox2
        {
            listBox2.Items.AddRange(listBox1.Items); 
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)//perenos vsego iz listbox2 v listbox1
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            MessageBox.Show(selectedState);
            
            if (comboBox1.SelectedIndex == 0)//в алфавитном порядке
            {
                listBox1.Sorted = true;
            }
            else if (comboBox1.SelectedIndex == 1)//по убыванию
            {
                ArrayList list = new ArrayList();
                foreach (object o in listBox1.Items)
                {
                    list.Add(o);
                }
                list.Sort();
                list.Reverse();
                listBox1.Items.Clear();
                foreach (object o in list)
                {
                    listBox1.Items.Add(o);
                }
            }
            else if (comboBox1.SelectedIndex == 2)//Длине слова -по возрастанию
            {
                List<String> list = new List<string>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                listBox1.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox1.Items.Add(item);
            }
            else if(comboBox1.SelectedIndex == 3)
            {
                List<String> list = new List<string>();//Длине слова - по убыванию
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                listBox1.Items.Clear();
                var sortResult = list.OrderByDescending(x => x.Length);
                foreach (var item in sortResult)
                    listBox1.Items.Add(item);
            }


        }
    }
}
