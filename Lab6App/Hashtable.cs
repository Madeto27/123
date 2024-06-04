using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Lab6App
{
    class Hashtable //<Key, Value>
    {
        public Entry[] table;
        public int loadness;
        public int size;

        public Doc[] doctors;


        static private int initSize = 17;
        static private float loadFactor = 0.5f;

        public static Hashtable initHashtable()
        {
            Hashtable ht = new Hashtable();
            ht.table = new Entry[initSize];
            ht.loadness = 0;
            ht.size = 0;

            ht.doctors = new Doc[initSize];
            return ht;
        }

        private Entry insertDoc(Value value, Entry entry)
        {
            Doc brief = new Doc(value.FamilyDoctor);
            bool patientAdded = false;
            bool full = false;
            int DocIndex = getHash(brief.key);
            
            foreach (Doc doc in doctors)
            {
                if (doc != null)
                {
                    if (doc.name == entry.value.FamilyDoctor)
                    {
                        if (doc.patients.Count < 5)
                        {
                            doc.patients.Add(entry);
                            patientAdded = true;
                            return entry;
                        }
                        else if (doc.patients.Count >= 5)
                        {
                            full = true;
                            break;
                        }
                    }
                }
            }

            if (full == true)
            {
                foreach (Doc doc in doctors)
                {
                    if (doc != null)
                    {
                        if (doc.name != entry.value.FamilyDoctor)
                        {
                            if (doc.patients.Count < 5)
                            {
                                entry.value.FamilyDoctor = doc.name;
                                doc.patients.Add(entry);
                                patientAdded = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (patientAdded == false && full == false)
            {
                brief.patients.Add(entry);
                doctors[DocIndex] = brief;
            }

            return entry;
        }

        public void insertEntry(Key key, Value value)
        {   
            Entry temp = new Entry(key.FirstName, key.LastName, value.FamilyDoctor, value.Address);
            int index = getHash(key);

            foreach (Entry entry in table)
            {
                if (entry != null && AreSame(entry.key, key))
                    throw new ArgumentException("This key is already in HashTable");
            }

            if (table[index] != null) 
            {
                for (int i = 0; i < table.Length; i++)
                {

                    index += i * i;
                    index = index % table.Length;

                    if (table[index] == null)
                        break;
                }
            }

            insertDoc(value, temp);
            table[index] = temp;
            size++;
            loadness++;

            if ((double)loadness / table.Length >= loadFactor)
                rehashing();
        }

        public int hashCode(Key key)
        {
            string fullName = key.FirstName + " " + key.LastName;

            int result = 0;

            for (int i = 0; i < fullName.Length; i++)
            {
                int symbol = fullName[i] - 'a' + 1;
                result += symbol * (53 ^ fullName.Length-1);
            }

            return result;
        }

        public int getHash(Key key)
        {
            return Math.Abs(hashCode(key) % table.Length); //знаходимо індекс 
        }


        public void removeEntry(Key key)
        {
            int index = getHash(key);
            bool found = true;


            if (!AreSame(table[index].key, key)) 
            {

                for (int i = 0; i < table.Length; i++)
                {
                    index = (index + (i * i))% table.Length;

                    if (AreSame(table[index].key, key))
                    {
                        found = true;
                        break;
                    }

                    found = false;
                }
            }

            if (found == false) 
            {
                return;
            }

            table[index].key.FirstName = "DELETED";
            table[index].key.LastName = "DELETED";
            table[index].value.Address = "DELETED";
            table[index].value.PatientID = 0;
            table[index].value.FamilyDoctor = "DELETED";
            size--;
            loadness--;

        }

        private bool AreSame(Key first, Key second)
        {
            if (first == null)
                return false;

            if (first.FirstName == second.FirstName && first.LastName == second.LastName)
                return true;

            return false;
        }

        //повертає value, працює
        public Value findEntry(Key key) 
        {
            int index = getHash(key);
            Entry entry = table[index];
            return entry.value;
        }

        
        private void rehashing()
        {
            Entry[] oldTable = table;
            Doc[] oldDoctors = doctors;

            int newSize = table.Length * 2;
            table = new Entry[newSize];

            Entry[] newTable = new Entry[newSize];
            Doc[] newDoctors = new Doc[newSize];

            foreach (Entry entry in oldTable) 
            {
                if (entry != null)
                {
                    int tempIndex = getHash(entry.key);
                    newTable[tempIndex] = entry;
                }
            }

            foreach (Doc doc in oldDoctors)
            {
                if (doc != null)
                {
                    int tempIndex = getHash(doc.key);
                    newDoctors[tempIndex] = doc;
                }
            }

            table = newTable;
            doctors = newDoctors;   
        }

        public List<Entry> findFamilyDoctorPatients(string familyDoctor)
        {
            foreach(Doc doc in doctors)
            {
                if (doc != null)
                {
                    if (doc.name == familyDoctor)
                    {
                        return doc.patients;
                    }
                }
            }

            throw new ArgumentException("Theres no doctor with such name");
        }
    }
}
