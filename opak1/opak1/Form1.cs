using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opak1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> cisla = new List<int>();
        public void vypisCisel(List<int> listicek, ListBox listbox)
        {
            foreach (int a in listicek)
            {
                listbox.Items.Add(a);
            }
        }
        public int druheMax (List<int> listicek)
        {
            int max=0;
            listicek.Sort();
            int[] pole= new int[listicek.Count];
            listicek.CopyTo(pole);
            max= Convert.ToInt32(pole.GetValue(pole.Length-2));
            return max;
        }
        public bool dokonale(int cislo)
        {
            int soucet=1;
            if(cislo%2==0)
            {
                soucet = soucet + 2;
                for (int i = 3; i <= cislo; i++)
                {
                    if(cislo%i==0)
                    {
                        soucet = soucet + i;
                    }
                }
            }
            else
            {
                for (int i = 3; i <= cislo; i=i+2)
                {
                    if (cislo % i == 0)
                    {
                        soucet = soucet + i;
                    }
                }
            }

            if (soucet == cislo)
            {
                return true;
            }
            else
            {
                return false;
            }    

        }
        public void vymaz(List<int> listicek)
            {
            foreach(int a in listicek)
            {
                if (dokonale(a) == true)
                {
                    listicek.Remove(a);

                }
                
            }
                
            }
        public int cifSoucet(List<int> listicek)
        {
            int cifSouc=0;
            listicek.Sort();
            int max = listicek.Last();
            
            while (max > 0)
            {
                
                cifSouc =cifSouc + (max % 10);
                max = max / 10;

            }
            return cifSouc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cisla.Clear();
            listBox1.Items.Clear();
            Random rng = new Random();
            int pocet = (int)numericUpDown1.Value;
            while (pocet > 0)
            {
                cisla.Add(rng.Next(-4, 100));
                pocet--;
            }
            vypisCisel(cisla, listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox2.Items.Clear();
            
                vymaz(cisla);

            
            foreach (int a in cisla)
            {
                listBox2.Items.Add(a);

            }

        }   

        private void button3_Click(object sender, EventArgs e)
        {
            cisla.Sort();
            vypisCisel(cisla, listBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double arprumer = 0;
            int soucet=0;
            double index=0;
            foreach (int a in cisla)
            {
                soucet = soucet + a;
                index++;


            }
            arprumer = soucet / index;
            textBox1.Text = "AR prumer je:" + arprumer;
        }
    }
}
