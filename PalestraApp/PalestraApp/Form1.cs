using System;
using System.Drawing;
using System.Windows.Forms;

namespace PalestraApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count = 1;
             int tempo;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label1.Text = "00:00";
        }
        DateTime dt = new DateTime();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tempo >= count)
                label1.Text = dt.AddSeconds(tempo - count++).ToString("mm:ss");
            else
            {
                this.Text = "Tempo esgotado";
                label1.ForeColor = Color.White;
                label1.BackColor = Color.Red;
                label1.Text = dt.AddSeconds(count++ - tempo).ToString("mm:ss");
            }
        }

        private void iniciarbutton_Click(object sender, EventArgs e)
        {
            this.Text = "VII FOCOTRAN";
            clear();
            tempo = int.Parse( tempoNormaltextBox.Text);
            timer1.Start();
        }

        private void zerabutton_Click(object sender, EventArgs e)
        {
            clear();
            this.Text = "VII FOCOTRAN";
        }
        void clear()
        {
            timer1.Stop();
            count = 0;
            label1.BackColor = Label.DefaultBackColor;
            label1.ForeColor = Label.DefaultForeColor;
            label1.Text = dt.AddSeconds(0).ToString("mm:ss");
        }

        private void respostabutton_Click(object sender, EventArgs e)
        {
            clear();
            this.Text = "Tempo de resposta";
            tempo = int.Parse(tempoRespostatextBox.Text);
            timer1.Start();
        }

        private void replicabutton_Click(object sender, EventArgs e)
        {
            clear();
            this.Text = "Réplica";
            tempo = int.Parse(tempoReplicatextBox.Text);
            timer1.Start();
        }

        private void treplicabutton_Click(object sender, EventArgs e)
        {
            clear();
            this.Text = "Tréplica";
            tempo = int.Parse(tempoTreplicatextBox.Text);
            timer1.Start();
        }

        private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.FormBorderStyle = this.FormBorderStyle == FormBorderStyle.Sizable ? FormBorderStyle.None : FormBorderStyle.Sizable;
        }
    }
}
