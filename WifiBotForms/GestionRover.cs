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
    public partial class GestionRover : Form
    {

        List<ListeRover> listeRovers;
        enregFichier sauvegarde;
        ListeRover nouveauRover;
        private string IP;
        private string TCP;
        private string NomRover;

        public GestionRover()
        {
            InitializeComponent();

            // lecture fichier pour récup des informations enregistrer sur les rovers

            listeRovers = new List<ListeRover>();// instanciation d'une liste rover

            sauvegarde = new enregFichier();
            //On vérifie l'existence d'une sauvegarde
            if (sauvegarde.TestExistenceFichier() == true)
            {
                listeRovers = sauvegarde.recuperationListe(); // si une sauvegarde existe on la récupère
                for (int i=0; i< listeRovers.Count; i++)
                {
                    string[] infoLigne = listeRovers.ElementAt(i).Getinfos();
                    listBoxRovers.Items.Add(infoLigne[0] + " / " + infoLigne[1] + " / " + infoLigne[2]);
                }
            }

        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ControlerRover_Click(object sender, EventArgs e)
        {
            WifiBot ControlRover = new WifiBot();
            ControlRover.svNom = NomRover;
            ControlRover.svIP = IP;
            ControlRover.svPort = TCP;

            ControlRover.serveurIP = IP;
            ControlRover.serveurPort = Convert.ToInt16(TCP);
            ControlRover.ShowDialog();
        }

        private void SupprimerRover_Click(object sender, EventArgs e)
        {
            if (listBoxRovers.SelectedIndex != -1)
            {
                var result = MessageBox.Show("Voulez-vous vraiment supprimer ce rover ?", "Suppression Rover", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Mise à jour liste et sauvegarde !

                    nouveauRover = new ListeRover(NomRover, IP, Convert.ToInt16(TCP));
                    listeRovers.RemoveAt(listBoxRovers.SelectedIndex);// suppression du rover dans la liste

                    //enregistrement nouvelle liste

                    if (sauvegarde.sauveListe(listeRovers) == true)
                        MessageBox.Show("Les données ont été enregistrées");
                    else
                        MessageBox.Show("Une erreur est survenue, les données n'ont pas été enregistrées");

                    listBoxRovers.Items.Remove(NomRover + " / " + IP + " / " + TCP);
                    MessageBox.Show("Vous avez supprimez le rover");
                }
                else
                {
                    MessageBox.Show("Suppression annuler");
                }
            }else
            {
                MessageBox.Show("Vous n'avez pas sélectionné de rover !!", "ERREUR !", MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
            }
        }

        private void AjoutRover_Click(object sender, EventArgs e)
        {
            // Création de la fenêtre de dialogue
            AjoutRover NouveauRover;
            NouveauRover = new AjoutRover();

            NouveauRover.roverIP = IP;
            NouveauRover.roverTCP = TCP;
            NouveauRover.roverNomRover = NomRover;

            bool ExisteDeja = false;
            //Utilisation de la fenêtre1
            DialogResult Fermeture = NouveauRover.ShowDialog();

            for (int i = 0; i <= listBoxRovers.ItemHeight; i++)
            {
                if ((listBoxRovers.GetItemText(NomRover) == NouveauRover.roverNomRover) && (Fermeture == DialogResult.OK) && (NouveauRover.roverNomRover != ""))
                {
                    MessageBox.Show("Le rover existe dejà.");
                    i = listBoxRovers.ItemHeight;
                    ExisteDeja = true;
                }

            }

            if ((NouveauRover.roverNomRover == "" || NouveauRover.roverTCP == "" || NouveauRover.roverIP == "...") && (Fermeture == DialogResult.OK))
            {
                MessageBox.Show("Erreur de saisie, veuillez recommencer.");
            }

            else if ((Fermeture == DialogResult.OK) && (ExisteDeja != true))
            {
                IP = NouveauRover.roverIP;
                TCP = NouveauRover.roverTCP;
                NomRover = NouveauRover.roverNomRover;
                listBoxRovers.Items.Add(NomRover + " / " + IP + " / " + TCP);

                // mise à jour des données

                nouveauRover = new ListeRover(NouveauRover.roverNomRover, NouveauRover.roverIP, Convert.ToInt16(NouveauRover.roverTCP) );
                listeRovers.Add(nouveauRover);// enregistrement du rover dans la liste
                
                //enregistrement nouvelle liste

                if (sauvegarde.sauveListe(listeRovers) == true)
                    MessageBox.Show("Les données ont été enregistrées");
                else
                    MessageBox.Show("Une erreur est survenue, les données n'ont pas été enregistrées");


            }

            string verifNom = "";
            verifNom = NouveauRover.roverNomRover.ToString();

        }

        private void listBoxRovers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
            BoxRoverSelect.Text = listBoxRovers.SelectedItem.ToString();
                int i;
                i = listBoxRovers.SelectedIndex;
                string[] infoLigne = listeRovers.ElementAt(i).Getinfos();
                IP = infoLigne[1];
                TCP = infoLigne[2];
                NomRover = infoLigne[0];
            }
            catch
            {
                listBoxRovers.SelectedIndex = -1;
                IP = "";
                TCP = "";
                NomRover = "";
            }
            
         

        }
    }
}
