using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Hashtable table = new Hashtable();
        Hashtable table = Hashtable.initHashtable();

        private void Add_Patient(object sender, RoutedEventArgs e)
        {
            //hide rest
            TFirstname.Visibility = Visibility.Hidden;
            TLastname.Visibility = Visibility.Hidden;
            TAddress.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TPatientID.Visibility = Visibility.Hidden;

            DocFirstnameBox.Visibility = Visibility.Hidden;
            DocLastnameBox.Visibility = Visibility.Hidden;
            Commit3.Visibility = Visibility.Hidden;

            labFN.Visibility = Visibility.Hidden;
            labLN.Visibility = Visibility.Hidden;
            labDN.Visibility = Visibility.Hidden;
            labAN.Visibility = Visibility.Hidden;
            labPID.Visibility = Visibility.Hidden;

            PatientsGridKey.Visibility = Visibility.Hidden;
            PatientsGridValue.Visibility = Visibility.Hidden;
            DELETE.Visibility = Visibility.Hidden;
            Commit2.Visibility = Visibility.Hidden;

            Firstname.Visibility = Visibility.Visible;
            Lastname.Visibility = Visibility.Visible;
            DoctorFirstname.Visibility = Visibility.Visible;
            DoctorLastname.Visibility = Visibility.Visible;
            Address.Visibility = Visibility.Visible;
            Commit1.Visibility = Visibility.Visible;
            Commit4.Visibility = Visibility.Hidden;

            Firstname.Text = "Firstname";
            Lastname.Text = "Lastname";
            DoctorFirstname.Text = "Doctor's Firstname";
            DoctorLastname.Text = "Doctor's Lastname";
            Address.Text = "Address";

        }

        List<string> names = new List<string>();

        private void Commit_Patient(object sender, RoutedEventArgs e)
        {
            Entry temp = new Entry(Firstname.Text, Lastname.Text, $"{DoctorFirstname.Text} {DoctorLastname.Text}", Address.Text);

            if (Firstname.Text == "Firstname" || Lastname.Text == "Lastname" || DoctorFirstname.Text == "Doctor's Firstname" || DoctorLastname.Text == "Doctor's Lastname" || Address.Text == "Address")
            {
                MessageBox.Show("Input your details.");
            }
            else if (names.Contains($"{DoctorFirstname.Text} {DoctorLastname.Text}"))
            {
                MessageBox.Show("This doctor is full");
            }
            else if (Acceptable(temp.value, temp) == true)
            {
                table.insertEntry(temp.key, temp.value);

                MessageBox.Show("Patient has been added.");
            }
            else if (!Acceptable(temp.value, temp))
            {
                MessageBox.Show("Enter another doctor");
            }
        }

        private void Remove_Patient(object sender, RoutedEventArgs e)
        {
            //hide rest
            DocFirstnameBox.Visibility = Visibility.Hidden;
            DocLastnameBox.Visibility = Visibility.Hidden;
            Commit3.Visibility = Visibility.Hidden;

            TFirstname.Visibility = Visibility.Hidden;
            TLastname.Visibility = Visibility.Hidden;
            TAddress.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TPatientID.Visibility = Visibility.Hidden;

            labFN.Visibility = Visibility.Hidden;
            labLN.Visibility = Visibility.Hidden;
            labDN.Visibility = Visibility.Hidden;
            labAN.Visibility = Visibility.Hidden;
            labPID.Visibility = Visibility.Hidden;

            PatientsGridKey.Visibility = Visibility.Hidden;
            PatientsGridValue.Visibility = Visibility.Hidden;
            DoctorFirstname.Visibility = Visibility.Hidden;
            DoctorLastname.Visibility = Visibility.Hidden;
            Address.Visibility = Visibility.Hidden;
            Commit1.Visibility = Visibility.Hidden;


            Firstname.Visibility = Visibility.Visible;
            Lastname.Visibility = Visibility.Visible;
            DELETE.Visibility = Visibility.Visible;
            Commit2.Visibility = Visibility.Visible;
            Commit4.Visibility = Visibility.Hidden;

            Firstname.Text = "Firstname";
            Lastname.Text = "Lastname";
        }

        private void Commit_Delete(object sender, RoutedEventArgs e)
        {
            if (DELETE.Text != "DELETE")
            {
                MessageBox.Show("If you are sure type *DELETE*");
            }
            else if (Lastname.Text == "Lastname" || Firstname.Text == "Firstname")
            {
                MessageBox.Show("Input your details");
            }
            else
            {
                string FName = Firstname.Text;
                string LName = Lastname.Text;
                Key key = new Key(FName, LName);

                table.removeEntry(key);
                MessageBox.Show($"Patient {Firstname.Text} {Lastname.Text} was removed");
            }
        }

        private void Find_Patient(object sender, RoutedEventArgs e)
        {
            DocFirstnameBox.Visibility = Visibility.Hidden;
            DocLastnameBox.Visibility = Visibility.Hidden;
            Commit3.Visibility = Visibility.Hidden;
            TFirstname.Visibility = Visibility.Hidden;
            TLastname.Visibility = Visibility.Hidden;
            TAddress.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TPatientID.Visibility = Visibility.Hidden;

            labFN.Visibility = Visibility.Hidden;
            labLN.Visibility = Visibility.Hidden;
            labDN.Visibility = Visibility.Hidden;
            labAN.Visibility = Visibility.Hidden;
            labPID.Visibility = Visibility.Hidden;

            PatientsGridKey.Visibility = Visibility.Hidden;
            PatientsGridValue.Visibility = Visibility.Hidden;
            DELETE.Visibility = Visibility.Hidden;
            Commit2.Visibility = Visibility.Hidden;

            Firstname.Visibility = Visibility.Visible;
            Lastname.Visibility = Visibility.Visible;
            DoctorFirstname.Visibility = Visibility.Hidden;
            DoctorLastname.Visibility = Visibility.Hidden;
            Address.Visibility = Visibility.Hidden;
            Commit1.Visibility = Visibility.Hidden;

            Commit4.Visibility = Visibility.Visible;

            Firstname.Text = "Firstname";
            Lastname.Text = "Lastname";
        }

        private void Commit_Find(object sender, RoutedEventArgs e)
        {

            Key key = new Key(Firstname.Text, Lastname.Text);
            int index = table.getHash(key);
            Entry entry = table.table[index];
            if (entry == null || entry.key.FirstName == "DELETED")
            {
                MessageBox.Show("This patient is not real");
            }
            else
            {
                Value value = table.findEntry(key);
                TFirstname.Text = Firstname.Text;
                TLastname.Text = Lastname.Text;
                TAddress.Text = value.Address;
                TPatientID.Text = Convert.ToString(value.PatientID);
                TDoctor.Text = value.FamilyDoctor;
            }

            TFirstname.Visibility = Visibility.Visible;
            TLastname.Visibility = Visibility.Visible;
            TAddress.Visibility = Visibility.Visible;
            TPatientID.Visibility = Visibility.Visible;
            TDoctor.Visibility = Visibility.Visible;

            labFN.Visibility = Visibility.Visible;
            labLN.Visibility = Visibility.Visible;
            labDN.Visibility = Visibility.Visible;
            labAN.Visibility = Visibility.Visible;
            labPID.Visibility = Visibility.Visible;
        }

        private void Show_Patients(object sender, RoutedEventArgs e)
        {
            DocFirstnameBox.Visibility = Visibility.Hidden;
            DocLastnameBox.Visibility = Visibility.Hidden;
            Commit3.Visibility = Visibility.Hidden;

            Firstname.Visibility = Visibility.Hidden;
            Lastname.Visibility = Visibility.Hidden;
            PatientsGridKey.Visibility = Visibility.Visible;
            PatientsGridValue.Visibility = Visibility.Visible;
            DoctorFirstname.Visibility = Visibility.Hidden;
            DoctorLastname.Visibility = Visibility.Hidden;
            Address.Visibility = Visibility.Hidden;

            labFN.Visibility = Visibility.Hidden;
            labLN.Visibility = Visibility.Hidden;
            labDN.Visibility = Visibility.Hidden;
            labAN.Visibility = Visibility.Hidden;
            labPID.Visibility = Visibility.Hidden;

            Commit1.Visibility = Visibility.Hidden;
            DELETE.Visibility = Visibility.Hidden;
            Commit2.Visibility = Visibility.Hidden;
            Commit4.Visibility = Visibility.Hidden;

            // Convert hashtable to a list of key-value pairs
            List<Key> keys = new List<Key>();
            List<Value> values = new List<Value>();

            for (int i = 0; i < table.table.Length; i++)
            {
                if (table.table[i] != null)
                {
                    keys.Add(table.table[i].key);
                    //names.Add(table.table[i].key.FirstName + " " + table.table[i].key.LastName);
                    values.Add(table.table[i].value);
                }
            }


            // Bind the data to the DataGrid
            PatientsGridKey.ItemsSource = keys;
            PatientsGridValue.ItemsSource = values;
        }

        private void Show_Doctors(object sender, RoutedEventArgs e)
        {
            DocFirstnameBox.Visibility = Visibility.Visible;
            DocLastnameBox.Visibility = Visibility.Visible;
            Commit3.Visibility = Visibility.Visible;
            Commit4.Visibility = Visibility.Hidden;

            Firstname.Visibility = Visibility.Hidden;
            Lastname.Visibility = Visibility.Hidden;
            PatientsGridKey.Visibility = Visibility.Hidden;
            PatientsGridValue.Visibility = Visibility.Hidden;
            DoctorFirstname.Visibility = Visibility.Hidden;
            DoctorLastname.Visibility = Visibility.Hidden;
            Address.Visibility = Visibility.Hidden;

            Commit1.Visibility = Visibility.Hidden;
            DELETE.Visibility = Visibility.Hidden;
            Commit2.Visibility = Visibility.Hidden;

            TFirstname.Visibility = Visibility.Hidden;
            TLastname.Visibility = Visibility.Hidden;
            TAddress.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TPatientID.Visibility = Visibility.Hidden;

            labFN.Visibility = Visibility.Hidden;
            labLN.Visibility = Visibility.Hidden;
            labDN.Visibility = Visibility.Hidden;
            labAN.Visibility = Visibility.Hidden;
            labPID.Visibility = Visibility.Hidden;

            DocFirstnameBox.Text = "Doctor's Firstname";
            DocLastnameBox.Text = "Doctor's Lastname";
        }
        private void Commit_Doctors(object sender, RoutedEventArgs e)
        {
            //List<string> names = new();
            List<Key> keys = new List<Key>();
            List<Value> values = new List<Value>();

            if (DocFirstnameBox.Text != null || DocFirstnameBox.Text != "Doctor's Firstname" || DocLastnameBox.Text != null || DocLastnameBox.Text != "Doctor's Lastname")
            {
                List<Entry> temp = table.findFamilyDoctorPatients($"{DocFirstnameBox.Text} {DocLastnameBox.Text}");
                for (int i = 0; i < temp.Count; i++)
                {
                    keys.Add(temp[i].key);
                    values.Add(temp[i].value);
                }

                PatientsGridKey.ItemsSource = keys;
                PatientsGridValue.ItemsSource = values;

                PatientsGridKey.Visibility = Visibility.Visible;
                PatientsGridValue.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Input Doctor's name");
            }
        }

        private void Preset(object sender, RoutedEventArgs e)
        {
            DocFirstnameBox.Visibility = Visibility.Hidden;
            DocLastnameBox.Visibility = Visibility.Hidden;
            Commit3.Visibility = Visibility.Hidden;
            Firstname.Visibility = Visibility.Hidden;
            Lastname.Visibility = Visibility.Hidden;
            DoctorFirstname.Visibility = Visibility.Hidden;
            DoctorLastname.Visibility = Visibility.Hidden;
            Address.Visibility = Visibility.Hidden;
            Commit1.Visibility = Visibility.Hidden;
            DELETE.Visibility = Visibility.Hidden;
            Commit2.Visibility = Visibility.Hidden;
            PatientsGridKey.Visibility = Visibility.Hidden;
            PatientsGridValue.Visibility = Visibility.Hidden;

            TFirstname.Visibility = Visibility.Hidden;
            TLastname.Visibility = Visibility.Hidden;
            TAddress.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TDoctor.Visibility = Visibility.Hidden;
            TPatientID.Visibility = Visibility.Hidden;
            Commit4.Visibility = Visibility.Hidden;

            labFN.Visibility = Visibility.Hidden;
            labLN.Visibility = Visibility.Hidden;
            labDN.Visibility = Visibility.Hidden;
            labAN.Visibility = Visibility.Hidden;
            labPID.Visibility = Visibility.Hidden;


            Entry ent1 = new Entry("Henry", "Ford", "Laura Glenis", "Detroit");
            Entry ent2 = new Entry("Patrick", "Star", "Nora Belis", "Bikkiny Bottom");
            Entry ent3 = new Entry("Howard", "Stark", "George Barm", "Los Angeles");
            Entry ent4 = new Entry("Snake", "Solid", "Kazuhira Miller", "FOX HOUND");
            Entry ent5 = new Entry("Naruto", "Uzumaki", "Sakura Haruno", "Konoha");
            Entry ent6 = new Entry("Jotaro", "Kujo", "Noriaki Kakyoin", "Tokyo");
            Entry ent7 = new Entry("Ryan", "Gosling", "Kazuhira Miller", "Kyiv");
            Entry ent8 = new Entry("Daniel", "Gaylord", "Laura Glenis", "Kyiv");
            Entry ent9 = new Entry("Sam", "Fisher", "Laura Glenis", "Los Angeles");
            Entry ent10 = new Entry("Bart", "Simpson", "Kazuhira Miller", "Springfield");
            Entry ent11 = new Entry("Anakin", "Skywalker", "Noriaki Kakyoin", "Tatooine");
            Entry ent12 = new Entry("Bertold", "Traitar", "Laura Glenis", "Maria");
            Entry ent13 = new Entry("Volodymyr", "Zelensky", "Laura Glenis", "Kyiv");
            Entry ent14 = new Entry("Marshal", "Mathers", "Sakura Haruno", "Los Angeles");
            Entry ent15 = new Entry("Kendrick", "Lamar", "George Barm", "Los Angeles");

            //Value.counter = 0;

            table.insertEntry(ent1.key, ent1.value);
            table.insertEntry(ent2.key, ent2.value);
            table.insertEntry(ent3.key, ent3.value);
            table.insertEntry(ent4.key, ent4.value);
            table.insertEntry(ent5.key, ent5.value);
            table.insertEntry(ent6.key, ent6.value);
            table.insertEntry(ent7.key, ent7.value);
            table.insertEntry(ent8.key, ent8.value);
            table.insertEntry(ent9.key, ent9.value);
            table.insertEntry(ent10.key, ent10.value);
            table.insertEntry(ent11.key, ent11.value);
            table.insertEntry(ent12.key, ent12.value);
            table.insertEntry(ent13.key, ent13.value);
            table.insertEntry(ent14.key, ent14.value);
            table.insertEntry(ent15.key, ent15.value);


            List<Key> keys = new List<Key>();
            List<Value> values = new List<Value>();

            for (int i = 0; i < table.table.Length; i++)
            {
                if (table.table[i] != null)
                {
                    keys.Add(table.table[i].key);
                    values.Add(table.table[i].value);
                }
            }

            PatientsGridKey.ItemsSource = keys;
            PatientsGridValue.ItemsSource = values;

            PatientsGridKey.Visibility = Visibility.Visible;
            PatientsGridValue.Visibility = Visibility.Visible;
        }

        public bool Acceptable(Value value, Entry entry)
        {
            Doc brief = new Doc(value.FamilyDoctor);
            bool patientAdded = false;
            bool full = false;

            foreach (Doc doc in table.doctors)
            {
                if (doc != null)
                {
                    if (doc.name == entry.value.FamilyDoctor)
                    {
                        if (doc.patients.Count < 5)
                        {
                            patientAdded = true;
                            return true;
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
                foreach (Doc doc in table.doctors)
                {
                    if (doc != null)
                    {
                        if (doc.name != entry.value.FamilyDoctor)
                        {
                            if (doc.patients.Count < 5)
                            {
                                patientAdded = true;
                                MessageBox.Show($"Patient was reassigned to {doc.name}");
                                return true;
                            }
                        }
                    }
                }
            }

            if (patientAdded == false && full == true)
                return false;

            return true;
        }
    }
}