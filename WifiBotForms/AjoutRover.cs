using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiBotForms
{
    public partial class AjoutRover : Form
    {
        public AjoutRover()
        {
            InitializeComponent();
            for (int i = 15015; i <= 15025; i++)
                comboBoxTCP.Items.Add(i);
            BoxNomRover.Focus();
        }
        public string roverIP
        {
            get
            {
                string ip = BoxIp1.Text + "." + BoxIp2.Text + "." + BoxIp3.Text + "." + BoxIp4.Text;
                string renvoie = "";

                for (int i = 0; i < ip.Length; i++)
                {
                    if (ip[i] == ' ')
                    {
                        renvoie = renvoie + "";
                    }
                    else
                    {
                        renvoie = renvoie + ip[i];
                    }
                }

                if (BoxIp1.Text == "" || BoxIp2.Text == "" || BoxIp3.Text == "" || BoxIp4.Text == "")
                    renvoie = "...";

                return renvoie;
            }

            set
            {
                BoxIp1.Text = value;
            }
        }

        public string roverTCP
        {
            get
            {
                return comboBoxTCP.Text;
            }

            set
            {
                comboBoxTCP.Text = value;
            }
        }
        public string roverNomRover
        {
            get
            {
                return BoxNomRover.Text;
            }

            set
            {
                BoxNomRover.Text = value;
            }
        }

        private void CreerConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
