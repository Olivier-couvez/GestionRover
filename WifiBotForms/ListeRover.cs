using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiBotForms
{
    [Serializable]
    class ListeRover
    {
        protected string Nom;
        protected string IP;
        protected int Port;
        

        public ListeRover(string _Nom, string _IP, int _Port)
        {
            Nom = _Nom;
            IP = _IP;
            Port = _Port;
        }

        public string[] Getinfos()
        {
            string[] liste = { Nom, IP, Convert.ToString(Port) };

            return liste;
        }
    }
}
