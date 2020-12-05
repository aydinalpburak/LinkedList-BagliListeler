using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Odev2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Liste liste = new Liste();
        public void ekrantemizle()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
        public void textboxtemizle()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        
        }        
        private void Button1_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {                
                liste.add_bas(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToDouble(textBox3.Text), textBox4.Text);
            }
            else if (radioButton2.Checked == true)
            {
                liste.add_sira(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToDouble(textBox3.Text), textBox4.Text);
            }
            else
            {
                liste.add_son(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToDouble(textBox3.Text), textBox4.Text);
            }
            ekrantemizle();
            liste.list(listBox1);
            //textboxtemizle();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ekrantemizle();
            if (radioButton9.Checked==true)
            {
                liste.listNO(listBox2);
            }
            else if (radioButton10.Checked == true)
            {
                liste.listISIM(listBox2);
            }
            else
            {
                liste.listORT(listBox2);
            }
            liste.list(listBox1);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = liste.capacity().ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
            }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked==true)
            {
                liste.deleteBAS();
            }
            else if (radioButton5.Checked == true)
            {
                liste.deleteSON();
            }
            else if (radioButton6.Checked == true)
            {
                liste.deleteTUM();
            }
            else if (radioButton7.Checked==true)
            {
                liste.deteteGIRILEN(Convert.ToInt32(maskedTextBox1.Text));
            }
            ekrantemizle();
            liste.list(listBox1);
        }
    }
}
