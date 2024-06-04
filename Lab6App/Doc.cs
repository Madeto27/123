using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6App
{
    class Doc
    {
        public List<Entry> patients = new List<Entry>();
        public string name;
        public Key key;

        public Doc(string docName)
        {
            string[] nameParts = docName.Split(' ');
            this.key = new Key(nameParts[0], nameParts[1]);
            this.name = docName;
        }
    }
}
