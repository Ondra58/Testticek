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

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                StreamReader ctenar = new StreamReader("matematika.txt");
                while (!ctenar.EndOfStream)
                {
                    listBox1.Items.Add(ctenar.ReadLine());
                }
                int[] vysledek = new int[5];
                int i = 0;
                /*ctenar.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!ctenar.EndOfStream)
                {
                    string priklad = ctenar.ReadLine();
                    int cislo1 = priklad[0] - 48;
                    char operand = priklad[1]; 
                    int cislo2 = priklad[2] - 48;
                    MessageBox.Show(operand.ToString());
                }*/
                string[] priklady = new string[5];
                foreach (string priklad in listBox1.Items)
                {
                    priklady[i] = priklad;
                    priklad.Split(' ');
                    int cislo1 = priklad[0] - 48;
                    char operand = priklad[2];
                    int cislo2 = priklad[4] - 48;
                    switch (operand)
                    {
                        case '+':
                            {
                                vysledek[i] = cislo1 + cislo2;
                                break;
                            }
                        case '-':
                            {
                                vysledek[i] = cislo1 - cislo2;
                                break;
                            }
                        case '*':
                            {
                                vysledek[i] = cislo1 * cislo2;
                                break;
                            }
                        case '/':
                            {
                                vysledek[i] = cislo1 / cislo2;
                                break;
                            }
                        case '%':
                            {
                                vysledek[i] = cislo1 % cislo2;
                                break;
                            }
                    }
                    i++;
                }
                ctenar.Close();
                i = 0;
                int soucet = 0;
                StreamWriter zapisovak = new StreamWriter("matematika.txt", false);
                foreach (int cislo in vysledek)
                {
                    zapisovak.WriteLine(priklady[i] + " " + cislo);
                    listBox2.Items.Add(priklady[i] + " " + cislo);
                    soucet += cislo;
                    i++;
                }
                zapisovak.Close();
                double prumer = (double)soucet / i;
                FileStream datovytok = new FileStream("prumer.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter zapisovak2 = new BinaryWriter(datovytok);
                zapisovak2.Write(prumer);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (StackOverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
