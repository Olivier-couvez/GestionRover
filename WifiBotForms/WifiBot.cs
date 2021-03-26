using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Speech.Recognition;

namespace WifiBotForms
{
    public partial class WifiBot : Form
    {
        private SpeechRecognitionEngine moteurReconnaissance;
        private Choices controleChoisie;
        private GrammarBuilder contraintesReconnaissance;
        private Grammar motsAReconnaitre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button quitButton;
        private System.Drawing.Drawing2D.GraphicsPath mousePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private int fontSize = 20;
        int pointOriX = 0;
        int pointOriY = 0;
        int pointDirX = 0;
        int pointDirY = 0;
        private int compt;
        private int Vitesse;
        private Point Point1;
        private Point Point2;
        private Point PointTick;
        private Cursor MyCursor;


        public WifiBot()
        {
            InitializeComponent();

            mousePath = new System.Drawing.Drawing2D.GraphicsPath();
            MyCursor = new Cursor(Cursor.Current.Handle);
            compt = 0;

            richTextBoxMotControle.Text = "";
            richTextBoxMotControle.Text = richTextBoxMotControle.Text + "avancer\n";
            richTextBoxMotControle.Text = richTextBoxMotControle.Text + "reculer\n";
            richTextBoxMotControle.Text = richTextBoxMotControle.Text + "droite\n";
            richTextBoxMotControle.Text = richTextBoxMotControle.Text + "gauche\n";
            richTextBoxMotControle.Text = richTextBoxMotControle.Text + "stop\n";
            // instanciation d'une reconnaissance vocale
            moteurReconnaissance = new SpeechRecognitionEngine();
            // on précise que l'acquisition se fera sur le canal d'entrée audio par défaut.
            moteurReconnaissance.SetInputToDefaultAudioDevice();
            // on construit le dictionnaire des mots a reconnaitre, ceux qui ne figure pas dans cette liste ne seront pas reconnus
            controleChoisie = new Choices(new string[] { "avancer", "reculer", "droite", "gauche", "stop", "quitter" });
            
            // on implante le dictionnaire dans le moteur de reconnaissance en utilisant un grammarbuilder
            contraintesReconnaissance = new GrammarBuilder(controleChoisie);
            
            motsAReconnaitre = new Grammar(contraintesReconnaissance);
            moteurReconnaissance.LoadGrammarAsync(motsAReconnaitre);
            // abonnements aux évènements liés à la reconnaissance vocale
            // Evénement déclencher lorsqu'un mot est reconnu
            moteurReconnaissance.SpeechRecognized += MoteurReconnaissance_SpeechRecognized;
            // Evénement déclencher lorsqu'un mot n'est pas reconnu
            moteurReconnaissance.SpeechRecognitionRejected += MoteurReconnaissance_SpeechRecognitionRejected;
        }
        
        private Robot Robot1;
        private Byte[] CommandeAEnvoyer;

        public string serveurIP ;
        public int serveurPort ;

        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        Timer timerVocal = new Timer();

        byte valeurHexaAvantG;
        byte valeurHexaAvantD;
        int valeurIntAvantG = 96;
        int valeurIntAvantD = 96;

        byte valeurHexaArriereG;
        byte valeurHexaArriereD;
        int valeurIntArriereG = 32;
        int valeurIntArriereD = 32;

        byte valeurHexaGaucheG;
        byte valeurHexaGaucheD;
        int valeurIntGaucheG = 16;
        int valeurIntGaucheD = 0;

        byte valeurHexaDroiteG;
        byte valeurHexaDroiteD;
        int valeurIntDroiteG = 0;
        int valeurIntDroiteD = 16;

        byte valeurHexaStopG;
        byte valeurHexaStopD;
        int valeurIntStopG = 0;
        int valeurIntStopD = 0;

        int controleVitesse = 0;
        int controleav = 64;
        int controlear = 0;

        #region methodes param
        public String svNom
        {
            get
            {
                return textBoxNom.Text;
            }
            set
            {
                textBoxNom.Text = value;
            }
        }
        public String svIP
        {
            get
            {
                return textBoxServeur.Text;
            }
            set
            {
                textBoxServeur.Text = value;
            }
        }
        public String svPort
        {
            get
            {
                return textBoxPort.Text;
            }
            set
            {
                textBoxPort.Text = value;
            }
        }
        #endregion


        private void Connexion()
        {
            Robot1 = new Robot(serveurIP , serveurPort);
            try
            {
                CommandeAEnvoyer = new Byte[2] { valeurHexaStopG, valeurHexaStopD };
                Robot1.Commander(CommandeAEnvoyer);

                timer1.Enabled = true;

                timer1.Tick += timer_Tick;

                timer1.Interval = 350;
                timer1.Start();
                labelConnexionOk.Text = "Connexion Ok !";

            }
            catch
            {
                buttonQuitter.Focus();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            EnvoyerCommande(CommandeAEnvoyer);
        }

        private void EnvoyerCommande(byte[] commande)
        {
            try { 
            Robot1.Commander(commande);
            }
            catch
            {
                timer1.Stop();
                DialogResult resultat;
                labelConnexionOk.Text = "Connexion perdu !";
                resultat = MessageBox.Show("Il semblerai que nous ayons perdu la connexion", "Erreur connexion", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (resultat == DialogResult.Retry)
                {
                    Connexion();
                }else
                {
                    buttonQuitter.Focus();
                }
            }
        }

        private int conversionInt(int aContVit, int aConvDirect, int aConvVit)
        {
            int nbConv;
                             
            nbConv = (aContVit + aConvDirect + aConvVit);
            
            return nbConv;
        }

#region Bouton
        private void boutonEnAvant_Click(object sender, EventArgs e)
        {
            valeurHexaAvantG = Convert.ToByte(valeurIntAvantG);
            valeurHexaAvantD = Convert.ToByte(valeurIntAvantD);
            CommandeAEnvoyer = new Byte[2] { valeurHexaAvantG, valeurHexaAvantD };
          
            //Robot1.Commander(CommandeAEnvoyer);
        }

        private void boutonEnArriere_Click(object sender, EventArgs e)
        {
            valeurHexaArriereG = Convert.ToByte(valeurIntArriereG);
            valeurHexaArriereD = Convert.ToByte(valeurIntArriereD);
            CommandeAEnvoyer = new Byte[2] { valeurHexaArriereG, valeurHexaArriereD };
           
            //Robot1.Commander(CommandeAEnvoyer);
        }

        private void boutonAGauche_Click(object sender, EventArgs e)
        {
            valeurHexaGaucheG = Convert.ToByte(valeurIntGaucheG);
            valeurHexaGaucheD = Convert.ToByte(valeurIntGaucheD);
            CommandeAEnvoyer = new Byte[2] { valeurHexaGaucheG, valeurHexaGaucheD };
           
            //Robot1.Commander(CommandeAEnvoyer);
        }

        private void boutonADroite_Click(object sender, EventArgs e)
        {
            valeurHexaDroiteG = Convert.ToByte(valeurIntDroiteG);
            valeurHexaDroiteD = Convert.ToByte(valeurIntDroiteD);
            CommandeAEnvoyer = new Byte[2] { valeurHexaDroiteG, valeurHexaDroiteD };
            
            //Robot1.Commander(CommandeAEnvoyer);
        }

        private void boutonStop_Click(object sender, EventArgs e)
        {
            valeurHexaStopG = Convert.ToByte(valeurIntStopG);
            valeurHexaStopD = Convert.ToByte(valeurIntStopD);
            CommandeAEnvoyer = new Byte[2] { valeurHexaStopG, valeurHexaStopD };
          
            //Robot1.Commander(CommandeAEnvoyer);
        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            Connexion();
            if (valeurIntAvantD > 128)
            {
                textBoxAvant.Text = Convert.ToString(valeurIntAvantD - controleav - controleVitesse);
            }
            else
            {
                textBoxAvant.Text = Convert.ToString(valeurIntAvantD - controleav );
            }
           
            textBoxArriere.Text = Convert.ToString(valeurIntArriereD);
            textBoxRotG.Text = Convert.ToString(valeurIntGaucheG);
            textBoxRotD.Text = Convert.ToString(valeurIntDroiteD);

            if (valeurIntAvantD > 128)
            {
                trackBarAvant.Value = valeurIntAvantD - controleav - controleVitesse;
            }
            else
            {
                trackBarAvant.Value = valeurIntAvantD - controleav;
            }
            
            trackBarArriere.Value = valeurIntArriereD;
            if (valeurIntGaucheG > controleav)
            {
                trackBarRotG.Value = valeurIntGaucheG - controleav;
            }
            else
            {
                trackBarRotD.Value = valeurIntGaucheG;
            }

            if (valeurIntDroiteD > controleav)
            {
                trackBarRotD.Value = valeurIntDroiteD - controleav;
            }
            else
            {
                trackBarRotG.Value = valeurIntDroiteD;
            }
            checkBoxcontroleVitesse.Checked = false;
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            boutonStop_Click(sender, e);
            moteurReconnaissance.RecognizeAsyncCancel();
            timer2.Stop();
            this.Close();
        }
        #endregion


        private void checkBoxcontroleVitesse_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxcontroleVitesse.Checked)
            {
                controleVitesse = 128;
                trackBarAvant.Maximum = 40;
                trackBarArriere.Maximum = 40;
                trackBarRotD.Maximum = 40;
                trackBarRotG.Maximum = 40;
                
            }
            else
            {
                controleVitesse = 0;
                trackBarAvant.Maximum = 60;
                trackBarArriere.Maximum = 60;
                trackBarRotD.Maximum = 60;
                trackBarRotG.Maximum = 60;
            }

            valeurIntAvantG = conversionInt(controleVitesse, controleav, trackBarAvant.Value);
            valeurIntAvantD = conversionInt(controleVitesse, controleav, trackBarAvant.Value);
            textBoxCalcAv.Text = Convert.ToString(valeurIntAvantG);
            textBoxAvant.Text = "" + Convert.ToString(trackBarAvant.Value);

            valeurIntArriereG = conversionInt(controleVitesse, controlear, trackBarArriere.Value);
            valeurIntArriereD = conversionInt(controleVitesse, controlear, trackBarArriere.Value);
            textBoxCalcAr.Text = Convert.ToString(valeurIntArriereG);
            textBoxArriere.Text = "" + Convert.ToString(trackBarArriere.Value);

            valeurIntGaucheG = conversionInt(controleVitesse, controlear, trackBarRotG.Value);
            valeurIntGaucheD = 0;
            textBoxCalcRotG.Text = Convert.ToString(valeurIntGaucheG);
            textBoxRotG.Text = "" + Convert.ToString(trackBarRotG.Value);

            valeurIntDroiteG = 0;
            valeurIntDroiteD = conversionInt(controleVitesse, controlear, trackBarRotD.Value);
            textBoxCalcRotD.Text = Convert.ToString(valeurIntDroiteD);
            textBoxRotD.Text = "" + Convert.ToString(trackBarRotD.Value);
        }
       

#region LesBarres
        private void trackBarAvant_Scroll(object sender, EventArgs e)
        {
            
            valeurIntAvantG = conversionInt(controleVitesse, controleav, trackBarAvant.Value);
            valeurIntAvantD = conversionInt(controleVitesse, controleav, trackBarAvant.Value);
            textBoxCalcAv.Text = Convert.ToString(valeurIntAvantG);
            textBoxAvant.Text = "" + Convert.ToString(trackBarAvant.Value);

            
        }

        private void trackBarArriere_Scroll(object sender, EventArgs e)
        {
            valeurIntArriereG = conversionInt(controleVitesse, controlear, trackBarArriere.Value);
            valeurIntArriereD = conversionInt(controleVitesse, controlear, trackBarArriere.Value);

            textBoxCalcAr.Text = Convert.ToString(valeurIntArriereG);
            textBoxArriere.Text = "" + Convert.ToString(trackBarArriere.Value);
        }

        private void trackBarRotG_Scroll(object sender, EventArgs e)
        {
            valeurIntGaucheG = conversionInt(controleVitesse, controlear, trackBarRotG.Value);
            valeurIntGaucheD = 0;

            textBoxCalcRotG.Text = Convert.ToString(valeurIntGaucheG);
            textBoxRotG.Text = "" + Convert.ToString(trackBarRotG.Value);
        }

        private void trackBarRotD_Scroll(object sender, EventArgs e)
        {
            valeurIntDroiteG = 0;
            valeurIntDroiteD = conversionInt(controleVitesse, controlear, trackBarRotD.Value);

            textBoxCalcRotD.Text = Convert.ToString(valeurIntDroiteD);
            textBoxRotD.Text = "" + Convert.ToString(trackBarRotD.Value);
        }
        #endregion


#region Le vocal

        private void MoteurReconnaissance_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            // le mot n'est pas reconnu on informe l'utilisateur on stop le rover
            boutonStop_Click(sender, e);
            MessageBox.Show("Attention : Mot non reconnu !", "ERREUR !",MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void MoteurReconnaissance_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // si le mot est reconnu on affiche l'image correspondante à la forme
            // et on ajoute le texte dans le richtext box prévu a cet effet.
            textBoxMotReconnu.Text=e.Result.Text;
            
            switch (e.Result.Text)
            {
                case "avancer":
                    boutonEnAvant_Click(sender, e);
                    break;
                case "reculer":
                    boutonEnArriere_Click(sender, e);
                    break;
                case "droite":
                    boutonADroite_Click(sender, e);
                    break;
                case "gauche":
                    boutonAGauche_Click(sender, e);
                    break;
                case "stop":
                    boutonStop_Click(sender, e);
                    break;
                
            }

        }

        private void buttonParler_Click(object sender, EventArgs e)
        {
            // On ne reconnait qu'un mot a la fois
            try
            {
                timerVocal_Tick(sender, e);
                timerVocal.Enabled = true;

                timerVocal.Tick += timerVocal_Tick;

                timerVocal.Interval = 350;
                timerVocal.Start();
            }
            catch
            {

            }
        }

        private void buttonArreter_Click(object sender, EventArgs e)
        {
            boutonStop_Click(sender, e);
            moteurReconnaissance.RecognizeAsyncCancel();
            timerVocal.Stop();
        }

        void timerVocal_Tick(object sender, EventArgs e)
        {
            try
            {
                moteurReconnaissance.RecognizeAsync(RecognizeMode.Single);
            }
            catch
            {

            }
            
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            // construction paneau de pilotage à la souris

            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            groupBoxControl.Visible = false;

            // Mouse Events Label
            this.label1.Location = new System.Drawing.Point(24, 504);
            this.label1.Size = new System.Drawing.Size(392, 23);
            // DoubleClickSize Label
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Size = new System.Drawing.Size(35, 13);
            // DoubleClickTime Label
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 72);
            this.label3.Size = new System.Drawing.Size(35, 13);
            // MousePresent Label
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 96);
            this.label4.Size = new System.Drawing.Size(35, 13);
            // MouseButtons Label
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 120);
            this.label5.Size = new System.Drawing.Size(35, 13);
            // MouseButtonsSwapped Label
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 48);
            this.label6.Size = new System.Drawing.Size(35, 13);
            // MouseWheelPresent Label
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 72);
            this.label7.Size = new System.Drawing.Size(35, 13);
            // MouseWheelScrollLines Label
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 96);
            this.label8.Size = new System.Drawing.Size(35, 13);
            // NativeMouseWheelSupport Label
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 120);
            this.label9.Size = new System.Drawing.Size(35, 13);
            // point origine X Label
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(700, 300);
            this.label10.Size = new System.Drawing.Size(35, 13);
            // Point origine Y Label
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(700, 340);
            this.label11.Size = new System.Drawing.Size(35, 13);
            // point direction X Label
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(700, 380);
            this.label12.Size = new System.Drawing.Size(35, 13);
            // Point direction Y Label
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(700, 420);
            this.label13.Size = new System.Drawing.Size(35, 13);

            // Mouse Panel
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(16, 160);
            this.panel1.Size = new System.Drawing.Size(664, 320);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
            this.panel1.BringToFront();

            // Clear Button
            this.clearButton.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.clearButton.Location = new System.Drawing.Point(592, 504);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Effacer";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            this.clearButton.BringToFront();
            
            // quit Button
            this.quitButton.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.quitButton.Location = new System.Drawing.Point(700, 504);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quitter";
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            this.quitButton.BringToFront();

            // GroupBox
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.groupBox1.Location = new System.Drawing.Point(16, 24);
            this.groupBox1.Size = new System.Drawing.Size(664, 128);
            this.groupBox1.Text = "Pilotage à la souris";
            this.groupBox1.BringToFront();

            // Set up how the form should be displayed and add the controls to the form.
            this.ClientSize = new System.Drawing.Size(840, 543);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                        this.label12,this.label13,this.label11,this.label10,this.label9,this.label8,this.label7,this.label6,
                                        this.label5,this.label4,this.label3,this.label2,
                                        this.clearButton, this.quitButton,this.panel1,this.label1,this.groupBox1});
            this.Text = "Pilotage Souris";

            // Displays information about the system mouse.
            label2.Text = "Double click taille : " + SystemInformation.DoubleClickSize.ToString();
            label3.Text = "Double click temps : " + SystemInformation.DoubleClickTime.ToString();
            label4.Text = "Souris présente : " + SystemInformation.MousePresent.ToString();
            label5.Text = "Souris boutons : " + SystemInformation.MouseButtons.ToString();
            label6.Text = "Souris boutons echange : " + SystemInformation.MouseButtonsSwapped.ToString();
            label7.Text = "Souris roulette présente: " + SystemInformation.MouseWheelPresent.ToString();
            label8.Text = "Souris roulette lignes : " + SystemInformation.MouseWheelScrollLines.ToString();
            label9.Text = "Support natif de la roulette : " + SystemInformation.NativeMouseWheelSupport.ToString();
            label10.Text = "Point origine X : " + pointOriX;
            label11.Text = "Point origine Y : " + pointOriY;
            label12.Text = "Point direction X : " + pointDirX;
            label13.Text = "Point direction Y : " + pointDirY;
        }


        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the mouse path with the mouse information
            Point mouseDownLocation = new Point(e.X, e.Y);

            string eventString = null;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    eventString = "G";
                    pointDirX = e.X;
                    pointDirY = e.Y;
                    label12.Text = "Point direction X : " + pointDirX;
                    label13.Text = "Point direction Y : " + pointDirY;
                    break;
                case MouseButtons.Right:
                    eventString = "D";
                    pointDirX = e.X;
                    pointDirY = e.Y;
                    label12.Text = "Point direction X : " + pointDirX;
                    label13.Text = "Point direction Y : " + pointDirY;
                    break;
                case MouseButtons.Middle:
                    eventString = "M";
                    pointOriX = e.X;
                    pointOriY = e.Y;
                    label10.Text = "Point origine X : " + pointOriX;
                    label11.Text = "Point origine Y : " + pointOriY;
                    timer2.Enabled = true;

                    timer2.Tick += timer_Tick2;

                    timer2.Interval = 200;
                    timer2.Start();

                    break;
                case MouseButtons.XButton1:
                    eventString = "B1";
                    boutonStop_Click(sender, e);
                    timer2.Stop();
                    break;
                case MouseButtons.XButton2:
                    eventString = "B2";
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            if (eventString != null)
            {
                mousePath.AddString(eventString, FontFamily.GenericSerif, (int)FontStyle.Bold, fontSize, mouseDownLocation, StringFormat.GenericDefault);
            }
            else
            {
                mousePath.AddLine(mouseDownLocation, mouseDownLocation);
            }
            panel1.Focus();
            panel1.Invalidate();
        }

        private void panel1_MouseEnter(object sender, System.EventArgs e)
        {
            // Update the mouse event label to indicate the MouseEnter event occurred.
            label1.Text = sender.GetType().ToString() + ": Souris entrée";
        }

        private void panel1_MouseHover(object sender, System.EventArgs e)
        {
            // Update the mouse event label to indicate the MouseHover event occurred.
            label1.Text = sender.GetType().ToString() + ": Souris au dessus";
        }

        private void panel1_MouseLeave(object sender, System.EventArgs e)
        {
            // Update the mouse event label to indicate the MouseLeave event occurred.
            label1.Text = sender.GetType().ToString() + ": Souris sortie";
        }

        private void panel1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the mouse path that is drawn onto the Panel.
            int mouseX = e.X;
            int mouseY = e.Y;

            mousePath.AddLine(mouseX, mouseY, mouseX, mouseY);
        }

        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the drawing based upon the mouse wheel scrolling.

            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int numberOfPixelsToMove = numberOfTextLinesToMove * fontSize;

            if (numberOfPixelsToMove != 0)
            {
                System.Drawing.Drawing2D.Matrix translateMatrix = new System.Drawing.Drawing2D.Matrix();
                translateMatrix.Translate(0, numberOfPixelsToMove);
                mousePath.Transform(translateMatrix);
            }
            panel1.Invalidate();
        }
        private void panel1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point mouseUpLocation = new System.Drawing.Point(e.X, e.Y);

            // Show the number of clicks in the path graphic.
            int numberOfClicks = e.Clicks;
            mousePath.AddString("    " + numberOfClicks.ToString(),
                        FontFamily.GenericSerif, (int)FontStyle.Bold,
                        fontSize, mouseUpLocation, StringFormat.GenericDefault);

            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Perform the painting of the Panel.
            e.Graphics.DrawPath(System.Drawing.Pens.DarkRed, mousePath);
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            // Clear the Panel display.
            mousePath.Dispose();
            mousePath = new System.Drawing.Drawing2D.GraphicsPath();
            panel1.Invalidate();
        }
        private void quitButton_Click(object sender, System.EventArgs e)
        {
            // quit !
            groupBoxControl.Visible = true;
            boutonStop_Click(sender, e);
            this.Close();
        }

        private void timer_Tick2(object sender, EventArgs e)
        {
            PointTick = System.Windows.Forms.Control.MousePosition;
            compt++;
            
            if (compt % 2 == 1)
            {
                Point1 = PointTick;

            }

            if (compt % 2 == 0)
            {
                Point2 = PointTick;
                EvalueSens(sender, e);
            }


        }
        private void EvalueSens(object sender, EventArgs e)
        {
            if (Point1.Y - Point2.Y < 0)
            {
                // "Marche Arriere";
                boutonEnArriere_Click(sender, e);

            }

            if (Point1.Y - Point2.Y > 0)
            {
                // "Marche Avant";
                boutonEnAvant_Click(sender, e);

            }
            if (Point1.X - Point2.X < 0)
            {
                // "Marche Droite";
                boutonADroite_Click(sender, e);

            }

            if (Point1.X - Point2.X > 0)
            {
                // "Marche Gauche";
                boutonAGauche_Click(sender, e);

            }

            compt = 0;
        }
    }
}
