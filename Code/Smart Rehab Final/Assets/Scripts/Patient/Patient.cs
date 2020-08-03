using System;

[Serializable]
public class Patient
{

    public string Firstname;
    public string Lastname;
    public string Age;
    public string Address;
    public string Contact;
    public string Pat_history;
    public string Gender;
    public string Stage;
    public bool[] Symptoms_value;

    public Patient(string fname, string lname, string age, string address, string nmbr, bool[] symptoms_value,string history,string gender, string stage)
    {
        Firstname = fname;
        Lastname = lname;
        Age = age;
        Address = address;
        Contact = nmbr;
        Pat_history = history;
        Gender = gender;
        Symptoms_value = symptoms_value;
        Stage = stage;

    }

}
