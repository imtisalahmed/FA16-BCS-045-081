using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Task_Handler_Script : MonoBehaviour
{
    public GameObject Dummy_Model_player, Realtime_Model_player, Camera1, Camera2, Camera3, Camera4, Count_Down, Realtime_3d_Objects, Realtime_UI_Objects;
    public GameObject Starting_Panel,Task_Completed_Panel;
    public Slider Distance_slider_for_dummy, Distance_slider_for_player;
    public GameObject Destination_object, Destination_object_2;
    int count = 3;
    int Camera_Count = 3;
    public Animator ani; float dist;
    public static Task_Handler_Script instance;
    public bool isPlayingTask = false;
    void Start()
    {
        instance = this;
        ///  Camera1.SetActive(true);
         CameraFollow.instance.Set_Dummy_Target();

        ani = Dummy_Model_player.GetComponent<Animator>();
        // ani.enabled = false;
        Count_Down.SetActive(false);

        Task_Completed_Panel.SetActive(false);
        
         dist = Vector3.Distance(Destination_object.transform.position, Dummy_Model_player.transform.position);
        print("Distance to other: " + dist);
        Distance_slider_for_dummy.maxValue = dist;

        Realtime_UI_Objects.SetActive(false);
        Realtime_3d_Objects.SetActive(false);

    }
    private void Update()
    {
        if (Dummy_Model_player.activeInHierarchy)
        {
            dist = Vector3.Distance(Destination_object.transform.position, Dummy_Model_player.transform.position);
            Distance_slider_for_dummy.value = dist;
        }
        if (Realtime_Model_player.activeInHierarchy)
        {
            dist = Vector3.Distance(Destination_object_2.transform.position, Realtime_Model_player.transform.position);
            Distance_slider_for_player.value = dist;
        }
        //print("Distance to other: " + dist);
    }
    public void Play_tutorial()
    {
        Starting_Panel.SetActive(false);
        Realtime_3d_Objects.SetActive(false);
        Realtime_UI_Objects.SetActive(false);
        Dummy_Model_player.transform.position = new Vector3(0, 0, 0);
        Dummy_Model_player.transform.rotation = new Quaternion();
        InvokeRepeating("Countdown",1f,1f);
    }
    public void Countdown()
    {
        Count_Down.SetActive(true);
        Count_Down.GetComponent<Text>().text = count.ToString();
        
        print(count);



        count--;
        if (count <= 0)
        {
            CancelInvoke();
            Start_Tutorial();
        }
    }

    public void Countdown2()
    {
        Count_Down.SetActive(true);
        Count_Down.GetComponent<Text>().text = count.ToString();

        print(count);



        count--;
        if (count <= 0)
        {
            CancelInvoke();
            Play_Task();
        }
    }  // count down is finished...

    public void Start_Tutorial()
    {
        Count_Down.SetActive(false);
        count=3;
        CameraFollow.instance.Set_Dummy_Target();
        ani.Play("Walking");
       // Camera1.SetActive(true);
       // Invoke("ChangeCamera",5f);
       // Invoke("ChangeCamera1", 10f);
        //Invoke("ChangeCamera2", 15f);
        //Invoke("ChangeCamera3", 20f);


    }


    public void Tutoiral_Completed()
    {
        ani.Play("mixamo_com");

        if (!isPlayingTask)
        {
            Starting_Panel.SetActive(true);
        }
       
        
    }
    public void Task_Completed()
    {
        
        Task_Completed_Panel.SetActive(true);
        Realtime_Model_player.GetComponent<Animator>().Play("mixamo_com");
    }
    public void StartTask()
    {
        Starting_Panel.SetActive(false);
        isPlayingTask = true;
        Realtime_UI_Objects.SetActive(true);
        Realtime_3d_Objects.SetActive(true);
        dist = Vector3.Distance(Destination_object_2.transform.position, Realtime_Model_player.transform.position);
        //print("Distance to other: " + dist);
        Distance_slider_for_player.maxValue = dist;
        CameraFollow.instance.Set_Realtime_Target();
        Dummy_Model_player.transform.position = new Vector3(0, 0, 0);
        Dummy_Model_player.transform.rotation = new Quaternion();
       // Realtime_Model_player.transform.position = new Vector3(0, 0, 0);
        Realtime_Model_player.transform.rotation = new Quaternion();
        InvokeRepeating("Countdown2", 1f, 1f);
        
    }
    public void Play_Task()
    {
        count = 3;
        Count_Down.SetActive(false);
        Realtime_Model_player.GetComponent<Animator>().Play("Walking");
        Dummy_Model_player.GetComponent<Animator>().Play("Walking");
        
    }
    public void ChangeCamera()
    {
            Camera2.SetActive(true);
           
    }
    public void ChangeCamera1()
    {
        Camera3.SetActive(true);

    }
    public void ChangeCamera2()
    {
        Camera4.SetActive(true);

    }
    public void ChangeCamera3()
    {
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);
        Camera1.SetActive(true);

    }
    public void RestartScene()
    {
        SceneManager.LoadScene("TaskScene");
    }
    public void GenerateReport()
    {
        print("Add Function for report generation");
    }
}
