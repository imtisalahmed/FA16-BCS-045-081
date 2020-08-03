using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Handler_Script : MonoBehaviour
{
    public GameObject Authentication_handler,Addnew_btn, saveschages_btn, delete_btn, addAppointment;
    public List<GameObject> Panels=new List<GameObject>();
    public GameObject
        Login_Panel,
        Register_Panel,
        Doctor_Profile_Panel,
        ForgotPassword_Panel,
        ResetPassword_Panel,
        Home_Panel,
        Dashboard_Panel,
        PatientList_Panel,
        AppointmentList_Panel,
        CRUD_Patient_Proflie_Panel,
        RU_DoctorProfile_Panel,
        C_Appointments_Panel,
        Mini_Appointments_Panel,
        InternetProblem_Panel,
        Task_Management_Panel;
    public GameObject PatientCreatedPopUp,AppointmentCreatedPopUp, PatientUpdatedPopUP, PatientDeletedPopUP,VIEW_APPOINTMENT_POPUP;
    public static Menu_Handler_Script instance;
    private void Awake()
    {
        Authentication_handler.SetActive(true);

        instance = this;
    }
    private void Start()
    {
        Panels.Add(Login_Panel);
        Panels.Add(Register_Panel);
        Panels.Add(Doctor_Profile_Panel);
        Panels.Add(ForgotPassword_Panel);
        Panels.Add(ResetPassword_Panel);
        Panels.Add(Home_Panel);
        Panels.Add(Dashboard_Panel);
        Panels.Add(PatientList_Panel);
        Panels.Add(AppointmentList_Panel);
        Panels.Add(CRUD_Patient_Proflie_Panel);
        Panels.Add(RU_DoctorProfile_Panel);
        Panels.Add(C_Appointments_Panel);
        Panels.Add(Mini_Appointments_Panel);
        Panels.Add(InternetProblem_Panel);
        Panels.Add(Task_Management_Panel);
        Open_Login_Panel_FUN();
       
    }
    public void Open_Login_Panel_FUN()
    {
        Debug.Log("???");
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
            //print(Panels[i].name);
        }
        Login_Panel.SetActive(true);
    }
    public void Open_Register_Panel_FUN()
    {

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Register_Panel.SetActive(true);
    }
    public void Open_Doctor_Profile_Panel_FUN()
    {

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Doctor_Profile_Panel.SetActive(true);
    }
    public void Open_Forgot_Password_Panel_FUN()
    {
        
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        ForgotPassword_Panel.SetActive(true);
    }
    public void Open_Rest_Password_Panel_FUN()
    {
        ResetPassword_Panel.SetActive(true);
    }
    public void Open_Home_Panel_FUN()
    {
        

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Home_Panel.SetActive(true);
        Dashboard_Panel.SetActive(true);
        VIEW_APPOINTMENT_POPUP.SetActive(false);
        Appointment_DB.instance.get_doc_appointments();
        Pdatabase.instance.getPatient();
    }
    public void Open_PatientsList_Panel_FUN()
    {

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Home_Panel.SetActive(true);
        PatientList_Panel.SetActive(true);
        Pdatabase.instance.getPatient();
    }
    public void Open_CRUD_PatientProfile_Panel_FUN()
    {

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Home_Panel.SetActive(true);
        CRUD_Patient_Proflie_Panel.SetActive(true);
        PatientCreatedPopUp.SetActive(false);
        PatientDeletedPopUP.SetActive(false);
        PatientUpdatedPopUP.SetActive(false);
        AppointmentCreatedPopUp.SetActive(false);
        
        //Appointment_DB.instance.get_pat_appointments();
       // Mini_Appointments_Panel.SetActive(false);
    }
    public void Open_Task_Management_Panel_FUN()
    {

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Home_Panel.SetActive(true);
        CRUD_Patient_Proflie_Panel.SetActive(false);
        PatientCreatedPopUp.SetActive(false);
        PatientDeletedPopUP.SetActive(false);
        PatientUpdatedPopUP.SetActive(false);
        AppointmentCreatedPopUp.SetActive(false);
        Task_Management_Panel.SetActive(true);
        //Appointment_DB.instance.get_pat_appointments();
        // Mini_Appointments_Panel.SetActive(false);
    }
    public void Open_for_CreatePatient()
    {
        Open_CRUD_PatientProfile_Panel_FUN();
        Pdatabase.instance.Clear_InputFields();
        Addnew_btn.SetActive(true);
        delete_btn.SetActive(false);
        addAppointment.SetActive(false);
        saveschages_btn.SetActive(false);
        Mini_Appointments_Panel.SetActive(false);
        PatientCreatedPopUp.SetActive(false);
    }
    public void PatientCreated_popUp()
    {
        Addnew_btn.SetActive(false);
        PatientCreatedPopUp.SetActive(true);
    }
    public void PatientUpdated_popUp()
    {
        //Addnew_btn.SetActive(false);
       PatientUpdatedPopUP.SetActive(true);
    }
    public void PatientDeleted_popUp()
    {
        //Addnew_btn.SetActive(false);
        PatientDeletedPopUP.SetActive(true);
    }
    public void Open_for_ViewPatient()
    {
        Open_CRUD_PatientProfile_Panel_FUN();
        Addnew_btn.SetActive(false);
        delete_btn.SetActive(true);
        addAppointment.SetActive(true);
        saveschages_btn.SetActive(true);
        Mini_Appointments_Panel.SetActive(true);
        Appointment_DB.instance.get_pat_appointments();
    }
   
    public void Open_Create_Appointment_Panel_FUN()
    {
       
        C_Appointments_Panel.SetActive(true);
    }
    public void Open_RU_DoctorProfile_Panel_FUN()
    {
        

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Home_Panel.SetActive(true);
        RU_DoctorProfile_Panel.SetActive(true);

    }
    public void Internet_Problem_FUN()
    {
        InternetProblem_Panel.SetActive(true);
    }
    
}
