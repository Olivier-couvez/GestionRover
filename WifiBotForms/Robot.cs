using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace WifiBotForms
{
    class Robot
    {
        private int Port;
        private string AdrTCP;

        TcpClient SocketClient;
        NetworkStream NetStream;

        public Robot(string AdrTCP, int Port)
        {
            try
            {
                SocketClient = new TcpClient();
                SocketClient.Connect(AdrTCP, Port);
                NetStream = SocketClient.GetStream();
                Console.WriteLine("connexion OK");
            }

            catch (ArgumentOutOfRangeException err)
            {
                MessageBox.Show("Une erreur est survenue : " + err.Message +
                "\nImpossible de se connecter à l'hote, vérifiez l'adresse IP ? ");
            }

            catch (SocketException err)
            {
                MessageBox.Show("Une erreur est survenue : " + err.Message + 
                "\nImpossible de se connecter à l'hote, vérifiez l'adresse IP ? ");   
            }        
        }

        public int Port1 { get => Port; set => Port = value; }
        public string AdrTCP1 { get => AdrTCP; set => AdrTCP = value; }

        public void Commander(Byte[] CommandeRobot)
        {
            NetStream.Write(CommandeRobot, 0, 2);
            // Thread.Sleep(2000);
        }
    }
}
