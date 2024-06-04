using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6App
{
    public class Key
    {
        public string FirstName
        {  get; set; }

        public string LastName
        { get; set; }

        public Key(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
