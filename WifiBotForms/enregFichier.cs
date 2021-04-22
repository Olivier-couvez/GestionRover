using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiBotForms
{
    class EnregFichier
    {

        private string nomFichier;
        private List<ListeRover> lesRovers;

        public EnregFichier()
        {
            string NomUtilisateur = Environment.GetEnvironmentVariable("USERNAME");
            nomFichier = "C:\\Users\\" + NomUtilisateur + "\\Documents\\Wifibot\\listerovers.bin";
        }

        /// <summary>
        /// Cette méthode vérifie si le fichier bin existe déjà 
        /// </summary>
        /// <returns></returns>
        /// 
        public bool TestExistenceFichier()
        {
            return File.Exists(nomFichier);

        }
        /// <summary>
        /// Cette méthode permet de récupérer la liste des roverq qui ont été enregistrées dans le fichier bin
        /// </summary>
        /// <returns> retourne la liste des rovers</returns>
        /// 
        public List<ListeRover> recuperationListe()
        {
            Stream testFileStream = File.OpenRead(nomFichier); // on ouvre le fichier en lecture
            BinaryFormatter deserialiseur = new BinaryFormatter();
            lesRovers = (List<ListeRover>)deserialiseur.Deserialize(testFileStream);
            testFileStream.Close();
            return lesRovers;
        }

        public bool sauveListe(List<ListeRover> listrov)
        {
            bool testCreation = false;
            try
            {
                Stream testFileStream = File.Create(nomFichier);
                BinaryFormatter serialiseur = new BinaryFormatter();
                serialiseur.Serialize(testFileStream, listrov);
                testFileStream.Close();
                testCreation = true;

            }
            catch (FileNotFoundException erreur)
            {
                MessageBox.Show("une erreur est survenue : " + erreur.Message);
                testCreation = false;
            }
            catch (UnauthorizedAccessException erreur)
            {
                MessageBox.Show("problème d'autorisation d'accès au fichier: " + erreur.Message);
                testCreation = false;
            }

            return testCreation;

        }
        internal List<ListeRover> LesRovers { get => lesRovers; set => lesRovers = value; }
    }
}
