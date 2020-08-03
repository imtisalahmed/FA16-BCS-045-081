using System;

[Serializable]
public class Appointment
{

    public string Pat_name;
    public string Pat_id;
    public string Pat_contact;
    public string Doc_id;
    public string Date;
    public string Time;

    public Appointment(string pat_name, string pat_id, string pat_contact, string doc_id, string date,string time)
    {
        Pat_name = pat_name;
        Pat_id = pat_id;
        Pat_contact = pat_contact;
        Doc_id = doc_id;
        Date = date;
        Time = time;

    }

}
