using UnityEngine;
using Proyecto26;
using FullSerializer;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Task_DB : MonoBehaviour
{
    private static readonly string databaseURL = $"https://fyp-2020-smart-rehab.firebaseio.com/";
    private static fsSerializer serializer = new fsSerializer();
    public GameObject list;
    public Button Update_btn;
    public Transform scrol;
    public GameObject[] tasks;
    public GameObject[] show_tasks;
    // public GameObject Panel;
    bool[] tasks_bool;
    bool[] show_tasks_bool;
    public static Task_DB instance;
    public Dropdown min_input,show_min;
    public string current_key, idToken, doc_id;
    public List<GameObject> temptaskslist;
    public Text tasks_count;
    string Current_task_key;
    string pat_key;
    int nextSceneIndex;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void Start()
    {
        instance = this;
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void Clear_InputFields()
    {
        min_input.value = 0;
        //meter_input.value = 0;
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i].GetComponent<Toggle>().isOn = false;
        }

    }
    public void Add_Tasks_Fun()
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        int menuIndex = min_input.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions = min_input.GetComponent<Dropdown>().options;
            string min = menuOptions[menuIndex].text;


        /* int menuIndex2 = meter_input.GetComponent<Dropdown>().value;
          List<Dropdown.OptionData> menuOptions2 = meter_input.GetComponent<Dropdown>().options;
             string meter = menuOptions2[menuIndex2].text;
          */

        pat_key = Pdatabase.instance.current_key;

        Tasks tasks_ = new Tasks(min);
        RestClient.Post("https://fyp-2020-smart-rehab.firebaseio.com/Patients/" + doc_id + "/"+ pat_key +"/Task_Plan/" + ".json?auth=" + idToken, tasks_).Then(response =>
        {

            print("Task Plan Added");
            //Menu_Handler_Script.instance.PatientCreated_popUp();
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Task Plan Not Added");

        });
    }



    public void getTaskPlan()
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");


        Task_DBhandler.GetUsers(tasks =>
        {
            string task_count = tasks.Count.ToString();
            print(task_count);

            if (temptaskslist != null)
            {
                for (int i = 0; i < temptaskslist.Count; i++)
                {
                    Destroy(temptaskslist[i]);
                }
                temptaskslist.Clear();
            }
            else
            {
                print("List is not created yet");
            }
            //Debug.Log("No:" + patients.Count);
            foreach (var child in tasks)
            {
                string t = child.Key;
                //print(t);

                GameObject btn = Instantiate(list) as GameObject;
                temptaskslist.Add(btn);
                btn.transform.SetParent(scrol);
                    btn.GetComponent<update_TaskPlan_list>().Tasks.text = child.Value.min;
                
                btn.GetComponent<update_TaskPlan_list>().start_btn.onClick.AddListener(() => startTask());
                //btn.GetComponent<update_TaskPlan_list>().edit_btn.onClick.AddListener(() => show_task(t));
               // btn.GetComponent<update_TaskPlan_list>().edit_btn.onClick.AddListener(() => SetCurrentTaskKey(t));
                btn.GetComponent<update_TaskPlan_list>().delete_btn.onClick.AddListener(() => deleteFun(t, btn));
                



            }
        });
    }
    public void startTask()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void SetCurrentTaskKey(string t)
    {
        Current_task_key = t;
    }
    public void UpdateShowTaskPage()
    {
        show_task(Current_task_key);
    }
    public void show_task(string t)
    { //public var extractedData;
      // Menu_Handler_Script.instance.Mini_Appointments_Panel.SetActive(true);
        print("............" + t);

        current_key = t;
        print("childkey" + current_key);


        //Update_btn.onClick.AddListener(() => UpdateToDatabase(current_key));
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");
        pat_key = Pdatabase.instance.current_key;


        Menu_Handler_Script.instance.Open_for_ViewPatient();
        print(doc_id);
        RestClient.Get($"https://fyp-2020-smart-rehab.firebaseio.com/Patients/" + doc_id + "/" + pat_key +"/Task_Plan/" + current_key + ".json?auth=" + idToken).Then(response =>
        {
            print("gdhvhj");
            var res = response.Text;
            Tasks extractedData = JsonUtility.FromJson<Tasks>(res);
            //input_pat_firstname.text = extractedData.Firstname;
            


            string show_minutes = extractedData.min;
            if (show_minutes == "3 min")
            {
                show_min.value = 0;
            }
            else if (show_minutes == "5 min")
            {
                show_min.value = 1;
            }
            else if (show_minutes == "10 min")
            {
                show_min.value = 2;
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

        int menuIndex1 = show_min.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions1 = show_min.GetComponent<Dropdown>().options;
        string get_walk_min = menuOptions1[menuIndex1].text;

       

       

        Tasks user = new Tasks(get_walk_min);
        RestClient.Put($"https://fyp-2020-smart-rehab.firebaseio.com/Patients/Task_Plan/" + current_t + "/" + ".json?auth=" + idToken, user).Then(response =>
        {
            print("updated");
            //Menu_Handler_Script.instance.PatientUpdated_popUp();
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Task Plan Not Updated");

        });
    }


    void deleteFun(string t, GameObject Button_)
    {
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        print(t);
        RestClient.Delete($"https://fyp-2020-smart-rehab.firebaseio.com/Patients/Task_Plan/" + doc_id + "/" + t + ".json?auth=" + idToken).Then(response =>
        {
            print("deleted by mazar fakhar : Helped by mazar fakhar");
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Task PLan Not Deleted");

        });
        Destroy(Button_);
    }

    public void delete_func(string current_t)
    {
        current_t = current_key;
        idToken = PlayerPrefs.GetString("Current_idToken");
        doc_id = PlayerPrefs.GetString("Current_localId");

        // print(t);
        RestClient.Delete($"https://fyp-2020-smart-rehab.firebaseio.com/Patients/Task_Plan/" + current_t + "/" + ".json?auth=" + idToken).Then(response =>
        {
            print("deleted ");
            Menu_Handler_Script.instance.PatientDeleted_popUp();


        }).Catch(error =>
        {
            Debug.Log(error.Message);
            print("Task Plan Not Deleted");

        });

    }

    


}


