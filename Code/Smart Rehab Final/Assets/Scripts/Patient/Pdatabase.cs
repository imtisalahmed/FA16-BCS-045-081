using UnityEngine;
using Proyecto26;
using FullSerializer;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Pdatabase : MonoBehaviour
{
    private static readonly string databaseURL = $"https://fyp-2020-smart-rehab.firebaseio.com/";
    private static fsSerializer serializer = new fsSerializer();
    public GameObject list ;
    public Button Update_btn;
    public Transform scrol;
    //public InputField get_pat_fName, get_pat_lName, get_pat_Age, get_pat_Address, get_pat_Contact, get_pat_history;
    public InputField input_pat_firstname, input_pat_lastname, input_pat_age, input_pat_contact, input_pat_Address, input_pat_history;
    public GameObject[] symptoms;
    public GameObject[] show_symptoms;
   // public GameObject Panel;
    bool[] symptoms_bool;
    bool[] show_symptoms_bool;
    public static Pdatabase instance;
    public Dropdown Gender_input, Stage_input,show_gender, show_stage;
    public string current_key, idToken, doc_id;
    //public static extractedDta;
    public List<GameObject> temppatientslist;
    public Text patient_count;
    string Current_Child_key;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void Start()
    {
        instance = this;
    }

    public void Clear_InputFields()
    {
        input_pat_firstname.text = ""; input_pat_lastname.text = ""; input_pat_age.text = ""; input_pat_contact.text = ""; input_pat_Address.text = ""; input_pat_history.text = "";
        Gender_input.value = 0;
        Stage_input.value = 0;
         for (int i = 0; i < symptoms.Length; i++)
         {
             symptoms[i].GetComponent<Toggle>().isOn = false ;
         }

    }
    public void Add_Patient_Fun()
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        int menuIndex = Gender_input.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions = Gender_input.GetComponent<Dropdown>().options;
        string gender = menuOptions[menuIndex].text;

        int menuIndex2 = Stage_input.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions2 = Stage_input.GetComponent<Dropdown>().options;
        string stage = menuOptions2[menuIndex2].text;

        symptoms_bool = new bool[symptoms.Length];
        for (int i = 0; i < symptoms.Length; i++)
        {

            symptoms_bool[i] = symptoms[i].GetComponent<Toggle>().isOn;
        }

        Patient patients_ = new Patient(input_pat_firstname.text, input_pat_lastname.text, input_pat_age.text, input_pat_Address.text, input_pat_contact.text, symptoms_bool, input_pat_history.text, gender, stage);
        RestClient.Post("https://fyp-2020-smart-rehab.firebaseio.com/Patients/" + doc_id + "/" + ".json?auth=" + idToken, patients_).Then(response =>
        {

            print("Patient Added");
            Menu_Handler_Script.instance.PatientCreated_popUp();
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Patient Not Added");

        });
    }



    public void getPatient()
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        DatabaseHandler.GetUsers(patients =>
        {
            string p_count = patients.Count.ToString();
            print(p_count);
            patient_count.GetComponent<Text>().text = p_count;

            if (temppatientslist != null)
            {
                for (int i = 0; i < temppatientslist.Count; i++)
                {
                    Destroy(temppatientslist[i]);
                }
                temppatientslist.Clear();
            }
            else
            {
                print("List is not created yet");
            }
            Debug.Log("No:" + patients.Count);
            foreach (var child in patients)
            {
                 string t = child.Key;
                //print(t);

                GameObject btn = Instantiate(list) as GameObject;
                temppatientslist.Add(btn);
                btn.transform.SetParent(scrol);
                btn.GetComponent<UpdateList>().name.text = child.Value.Firstname + " " +child.Value.Lastname;
                btn.GetComponent<UpdateList>().age.text = child.Value.Age;
                btn.GetComponent<UpdateList>().gender.text = child.Value.Gender;
                btn.GetComponent<UpdateList>().conact.text = child.Value.Contact;
                btn.GetComponent<UpdateList>().type.text = child.Value.Stage;
                btn.GetComponent<UpdateList>().view_btn.onClick.AddListener(() => show_pat(t));
                btn.GetComponent<UpdateList>().view_btn.onClick.AddListener(() => SetCurrentPatientKey(t));
                btn.GetComponent<UpdateList>().edit_btn.onClick.AddListener(() => show_pat(t));
                btn.GetComponent<UpdateList>().edit_btn.onClick.AddListener(() => SetCurrentPatientKey(t));
                btn.GetComponent<UpdateList>().delete_btn.onClick.AddListener(() => deleteFun(t, btn));
               
                

            }
        });
    }
    public void SetCurrentPatientKey(string t)
    {
        Current_Child_key = t;
    }
    public void UpdateShowPatientPage()
    {
        show_pat(Current_Child_key);
    }
   public void show_pat(string t)
    { //public var extractedData;
      // Menu_Handler_Script.instance.Mini_Appointments_Panel.SetActive(true);
        print("............" + t);
        
            current_key = t;
            print("childkey" + current_key);
       
      
        //Update_btn.onClick.AddListener(() => UpdateToDatabase(current_key));
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        Menu_Handler_Script.instance.Open_for_ViewPatient();
        print(doc_id);
        RestClient.Get($"https://fyp-2020-smart-rehab.firebaseio.com/Patients/" + doc_id +"/" + current_key + ".json?auth=" + idToken).Then(response =>
        {
            print("gdhvhj");
            var res = response.Text;
            Patient extractedData = JsonUtility.FromJson<Patient>(res);
            input_pat_firstname.text = extractedData.Firstname;
            input_pat_lastname.text = extractedData.Lastname;
            input_pat_age.text = extractedData.Age;
            input_pat_Address.text = extractedData.Address;
            input_pat_contact.text = extractedData.Contact;
            input_pat_history.text = extractedData.Pat_history;
            

            string show_gen = extractedData.Gender;
            if (show_gen == "Male")
            {
                show_gender.value = 0;
            }
            else if (show_gen == "Female")
            {
                show_gender.value = 1;
            }
            else if (show_gen == "Other")
            {
                show_gender.value = 2;
            }

            string show__stage = extractedData.Stage;
            if (show__stage == "Stage 1")
            {
                show_stage.value = 0;
            }
            else if (show__stage == "Stage 2")
            {
                show_stage.value = 1;
            }
            else if (show__stage == "Stage 3")
            {
                show_stage.value = 2;
            }
            else if (show__stage == "Stage 4")
            {
                show_stage.value = 3;
            }
            else if (show__stage == "Stage 5")
            {
                show_stage.value = 4;
            }
            

            for (int i = 0; i < extractedData.Symptoms_value.Length; i++)
            {
                if (extractedData.Symptoms_value[i])
                {
                    show_symptoms[i].GetComponent<Toggle>().isOn = true;
                }
                else if(!extractedData.Symptoms_value[i])
                {
                    show_symptoms[i].GetComponent<Toggle>().isOn = false;
                }
                
             
            }
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Data Not Found");
            
        });



    }

   
    public void UpdateToDatabase(string current_t)
    {
        current_t = current_key;
        //print(current_key);
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        int menuIndex1 = show_gender.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions1 = show_gender.GetComponent<Dropdown>().options;
        string get_pat_gender = menuOptions1[menuIndex1].text;

        int menuIndex3 = show_stage.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions3 = show_stage.GetComponent<Dropdown>().options;
        string get_stage = menuOptions3[menuIndex3].text;

        show_symptoms_bool = new bool[show_symptoms.Length];
        for (int i = 0; i < show_symptoms.Length; i++)
        {

            show_symptoms_bool[i] = show_symptoms[i].GetComponent<Toggle>().isOn;
        }

        Patient user = new Patient(input_pat_firstname.text, input_pat_lastname.text, input_pat_age.text, input_pat_Address.text, input_pat_contact.text, show_symptoms_bool, input_pat_history.text, get_pat_gender, get_stage);
        RestClient.Put($"https://fyp-2020-smart-rehab.firebaseio.com/Patients/" + doc_id + "/" + current_t + "/" + ".json?auth=" + idToken, user).Then(response =>
        {
            print("updated");
            Menu_Handler_Script.instance.PatientUpdated_popUp();
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Patient Not Updated");

        });
    }


    void deleteFun(string t ,GameObject Button_)
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        print(t);   
        RestClient.Delete($"https://fyp-2020-smart-rehab.firebaseio.com/Patients/" + doc_id + "/" + t + ".json?auth=" + idToken).Then(response =>
        {
            print("deleted by mazar fakhar : Helped by mazar fakhar");
            del_apoint_with_pat();
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Patient Not Deleted");

        });
        Destroy(Button_);
    }

    public void delete_func(string current_t)
    {
        current_t = current_key;
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

       // print(t);
        RestClient.Delete($"https://fyp-2020-smart-rehab.firebaseio.com/Patients/" + doc_id + "/" + current_t +"/"+ ".json?auth=" + idToken).Then(response =>
        {
            print("deleted ");
            Menu_Handler_Script.instance.PatientDeleted_popUp();
            del_apoint_with_pat();


        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Patient Not Deleted");

        });

    }

    void del_apoint_with_pat()
    {
        appointment_handler.GetUsers(appointment =>
        {

            foreach (var child in appointment)
            {
                if (child.Value.Pat_id == current_key)
                {
                    string pat_apt_id = child.Key;
                    RestClient.Delete($"https://fyp-2020-smart-rehab.firebaseio.com/Appointments/" + doc_id + "/" + child.Key + ".json?auth=" + idToken).Then(response =>
                    {
                        print("deleted by mazar fakhar : Helped by mazar fakhar");
                    });
                }
            }
        });

    }
    
    
    }


