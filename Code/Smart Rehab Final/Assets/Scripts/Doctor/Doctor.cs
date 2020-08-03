using System;

[Serializable]
public class Doctor
{

    public string Firstname;
    public string Lastname;
    public string Gender;
    public string Address;
    public string Contact;
    public string Age;
   

    public Doctor(string fname, string lname, string gender, string address, string nmbr, string age)
    {
        Firstname = fname;
        Lastname = lname;
        Gender = gender;
        Address = address;
        Contact = nmbr;
        Age = age;
    }

}