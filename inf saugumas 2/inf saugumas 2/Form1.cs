using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inf_saugumas_2
{
    public partial class Form1 : Form
    {
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public Form1()
        {
            InitializeComponent();
            abc=abc.ToLower();
        }
        private void cipher()
        {
            string original = textBox1.Text;
            original=original.ToLower();
            string keyphrase = textBox2.Text;
            keyphrase= keyphrase.ToLower();
            int originallength = original.Length;
            int keyphraselength = keyphrase.Length;

            for (int i = 0, passcounter=0; i < originallength; i++,passcounter++)
            {
                char keyletter = keyphrase[passcounter % keyphraselength];
                char oriletter = original[i];
                int oriindex = -1;
                bool run = true;

                if (oriletter == ' ')
                {
                    addleter(' ');
                    passcounter--;
                }
                else
                {
                    do
                    {
                        oriindex++;
                        char abcletter = abc[oriindex];
                        if (oriletter == abcletter)
                        {
                            run = false;
                        }
                    } while (run);

                    int keyindex = -1;
                    run = true;
                    do
                    {
                        keyindex++;
                        char abcletter = abc[keyindex];
                        if (keyletter == abcletter)
                        {
                            run = false;
                        }
                    } while (run);
                    int encrindex = oriindex + keyindex;
                    if (encrindex > 25)
                        encrindex -= 26;

                    char addltr = abc[encrindex];
                    addleter(addltr);


                }


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cipher();
        }
        void addleter(char text)
        {
            richTextBox1.Text += text;
        }
        void cleartxtbox()
        {
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cleartxtbox();
        }
    }
}
