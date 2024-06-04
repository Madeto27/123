using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6App
{
    public class Entry
    {
        public Key key;
        public Value value;

        public Entry(string firstName, string lastName, string doc, string address)
        {
            this.key = new Key(firstName, lastName);
            this.value = new Value(doc, address);
        }
    }
}
