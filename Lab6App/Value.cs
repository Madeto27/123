using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6App
{
    public class Value
    {
        public int PatientID
        {  get; set; }

        public string FamilyDoctor
        {  get; set; }

        public string Address
        { get; set; }

        public static int counter = 0;

        public Value(string doc, string address)
        {
            this.PatientID = IdGen();
            this.FamilyDoctor = doc;
            this.Address = address;
        }

        private int IdGen()
        {
            counter++;
            return 19900 + counter;
        }
    }
}
