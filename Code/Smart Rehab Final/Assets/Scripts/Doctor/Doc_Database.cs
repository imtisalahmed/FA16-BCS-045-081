using UnityEngine;
using Proyecto26;
using FullSerializer;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Doc_Database : MonoBehaviour
{
    private static readonly string databaseURL = $"https://fyp-2020-smart-rehab.firebaseio.com/";
    private static fsSerializer serializer = new fsSerializer();
    public InputField get_fName, get_lName, get_Address, get_Contact, get_age;
    public InputField input_firstname, input_lastname, input_contact, input_Address, input_age;
    public GameObject Gender_input ;
    public Dropdown show_gender;

    public string id,idToken;

    public void Add_Doctor_Fun()
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        id = PlayerPrefs.GetString("Current_localId");

        int menuIndex = Gender_input.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions = Gender_input.GetComponent<Dropdown>().options;
        string gender = menuOptions[menuIndex].text;

        Doctor doctor_ = new Doctor(input_firstname.text, input_lastname.text, gender, input_Address.text, input_contact.text, input_age.text);
        RestClient.Put("https://fyp-2020-smart-rehab.firebaseio.com/Doctors/" + id + ".json?auth=" + idToken, doctor_).Then(response =>
        {

            print("Doctor Added");
            Menu_Handler_Script.instance.PatientCreated_popUp();
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Doctor Not Added");

        });
    }

    public void show_doc_profile()
    {
        show_doc();
    }

    void show_doc()
    {

        
        idToken = PlayerPrefs.GetString("Current_idToken");
        id = PlayerPrefs.GetString("Current_localId");
        
        RestClient.Get("https://fyp-2020-smart-rehab.firebaseio.com/Doctors/" + id + ".json?auth=" + idToken).Then(response =>
        {
            var res = response.Text;
            Doctor extractedData = JsonUtility.FromJson<Doctor>(res);
          //  print("  ??"+extractedData.Firstname);
            get_fName.text = extractedData.Firstname;
            get_lName.text = extractedData.Lastname;
            get_Address.text = extractedData.Address;
            get_Contact.text = extractedData.Contact;
            get_age.text = extractedData.Age;

            string show_gen = extractedData.Gender;
            if(show_gen == "Male")
            {
                show_gender.value = 0;
            }
            else if(show_gen == "Female")
            {
                show_gender.value = 1;
            }
            else if (show_gen == "Other")
            {
                show_gender.value = 2;
            }
            //show_gender.GetComponent<Dropdown>().v

        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("No Doctor Found");
        });

    }
    public void update_doc()

    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        id = PlayerPrefs.GetString("Current_localId");

        int menuIndex1 = show_gender.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions1 = show_gender.GetComponent<Dropdown>().options;
        string get_gender = menuOptions1[menuIndex1].text;

        id = PlayerPrefs.GetString("Current_localId");
        Doctor Doctor_ = new Doctor(get_fName.text, get_lName.text, get_gender, get_Address.text, get_Contact.text, get_age.text);
        RestClient.Put($"https://fyp-2020-smart-rehab.firebaseio.com/Doctors/" + id + ".json?auth=" + idToken, Doctor_).Then(response =>
        {
            print("updated");
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Doctor Not Updated");
        });
    }
    }


