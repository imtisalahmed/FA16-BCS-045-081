using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.UI;

public class Appointment_DB : MonoBehaviour
{
    public string pat_name, pat_id, pat_contact, doc_id, date, time;
    public string idToken;
    public GameObject doc_apoint_list, pat_apoint_list, AddAppointment_btn, loading_indicator, appointmentadded_popUp;
    public Transform doc_apoint_scrol, pat_apoint_scrol;
    public static Appointment_DB instance;
    public List<GameObject> tempAppointments;
    public List<GameObject> temp_pat_Appointments;
    public Text Apointment_count;
    public string current_apoint_key;
    public Text Patient_Name, patient_contact, apoint_time, apoint_date;

    //public Text Selected_time, Selected_Date;
    private void Awake()
    {
        appointmentadded_popUp.SetActive(false);
        loading_indicator.SetActive(false);
        instance = this;
    }
    public void Add_Appointment_Fun()
    {
        idToken = PlayerPrefs.GetString("Current_idToken");

        pat_name = Pdatabase.instance.input_pat_firstname.text +" " + Pdatabase.instance.input_pat_lastname.text;
        pat_id = Pdatabase.instance.current_key;
        pat_contact = Pdatabase.instance.input_pat_contact.text;
        doc_id = PlayerPrefs.GetString("Current_localId");
        date = Example15.instance.date1;
        time = Example15.instance.time1;

       
        Appointment appointment_ = new Appointment(pat_name,pat_id, pat_contact, doc_id, date,time);
        RestClient.Post("https://fyp-2020-smart-rehab.firebaseio.com/Appointments/" + doc_id + "/" + ".json?auth=" + idToken, appointment_).Then(response =>
        {

            print("Patient Added");
            appointmentadded_popUp.SetActive(true);
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Appointment Not Added");

        });
    }





    public void get_doc_appointments()
    {
        appointment_handler.GetUsers(appointment =>
        {
            string apoint_count = appointment.Count.ToString();
            print(apoint_count);
            Apointment_count.GetComponent<Text>().text = apoint_count;

            if (tempAppointments != null)
            {
                for (int i = 0; i < tempAppointments.Count; i++)
                {
                    Destroy(tempAppointments[i]);
                    // tempAppointments.Clear();
                }
            }
            else
            {
                print("List is not created yet");
            }
            Debug.Log("No:" + appointment.Count);
            foreach (var child in appointment)
            {
                string apt_id = child.Key;

                GameObject btn = Instantiate(doc_apoint_list) as GameObject;
                tempAppointments.Add(btn);
                btn.transform.SetParent(doc_apoint_scrol);
                btn.GetComponent<update_apoint_list>().pat_name.text = child.Value.Pat_name;
                btn.GetComponent<update_apoint_list>().date_time.text = child.Value.Date;
                //btn.GetComponent<update_apoint_list>().time.text = child.Value.Time;
                btn.GetComponent<update_apoint_list>().view_btn.onClick.AddListener(() => show_doc_apoint(apt_id));
                btn.GetComponent<update_apoint_list>().delete_btn.onClick.AddListener(() => delete_doc_apoint(apt_id, btn));


            }
        });
       // appointmentadded_popUp.SetActive(true);

    }

    void show_doc_apoint(string apt_id)
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        Menu_Handler_Script.instance.VIEW_APPOINTMENT_POPUP.SetActive(true);

       current_apoint_key = apt_id;

        RestClient.Get($"https://fyp-2020-smart-rehab.firebaseio.com/Appointments/" + doc_id + "/" + current_apoint_key + ".json?auth=" + idToken).Then(response =>
        {
            var res = response.Text;
            Appointment extractedData = JsonUtility.FromJson<Appointment>(res);
            Patient_Name.text = extractedData.Pat_name;
            patient_contact.text = extractedData.Pat_contact;
            apoint_date.text = extractedData.Date;
            apoint_time.text = extractedData.Time;
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("NO Appointments Available");

        });


    }



     void delete_doc_apoint(string apt_id, GameObject Button_)
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        print(apt_id);
        RestClient.Delete($"https://fyp-2020-smart-rehab.firebaseio.com/Appointments/" + doc_id + "/" + apt_id + ".json?auth=" + idToken).Then(response =>
        {
            print("deleted by mazar fakhar : Helped by mazar fakhar");
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Appointment Not Deleted");

        });
        Destroy(Button_);
    }


    //----------------------------------------------------------------------------------------------------
    public void get_pat_appointments()
    {
        appointment_handler.GetUsers(appointment =>
        {
            if (temp_pat_Appointments != null)
            {
                for (int i = 0; i < temp_pat_Appointments.Count; i++)
                {
                    Destroy(temp_pat_Appointments[i]);
                }
            }
            else
            {
                print("List is not created yet");
            }
            Debug.Log("No:" + appointment.Count);
            
        foreach (var child in appointment)
        {
                if (child.Value.Pat_id == Pdatabase.instance.current_key)
            {
                print("huifhcf");
                    string pat_apt_id = child.Key;

                    GameObject btn = Instantiate(pat_apoint_list) as GameObject;
                    temp_pat_Appointments.Add(btn);
                    btn.transform.SetParent(pat_apoint_scrol);
                    btn.GetComponent<update_pat_apoint_list>().date_time.text = child.Value.Date+"/"+ child.Value.Time;
                    btn.GetComponent<update_pat_apoint_list>().delete_btn.onClick.AddListener(() => delete_pat_apoint(pat_apt_id, btn));

                }
            }
        });

    }

    void show_pat_apoint(string pat_apt_id)
    {

    }

    void delete_pat_apoint(string pat_apt_id, GameObject Button_)
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        print(pat_apt_id);
        RestClient.Delete($"https://fyp-2020-smart-rehab.firebaseio.com/Appointments/" + doc_id + "/" + pat_apt_id + ".json?auth=" + idToken).Then(response =>
        {
            print("deleted by mazar fakhar : Helped by mazar fakhar");
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Appointment Not Deleted");

        });
        Destroy(Button_);
    }


}
