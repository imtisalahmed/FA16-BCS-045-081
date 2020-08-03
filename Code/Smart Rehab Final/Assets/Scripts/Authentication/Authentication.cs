using System.Collections;
using System.Collections.Generic;
//using FullSerializer;
using Proyecto26;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Net;
using UnityEngine.Networking;
using UnityEngine.Windows;
public class Authentication : MonoBehaviour
{
    public static string requestType;
    public InputField emailText_For_Login;
    public InputField emailText_For_Register;
    public InputField emailText_ResetPassword;
    public InputField passwordText_For_Login;
    public InputField passwordText_For_Register;
    public InputField passwordText_For_Register_Confirm;
    public GameObject validation_text;
    public GameObject validation_text_Registration, validation_text_forgotpass;
    private string AuthKey = "AIzaSyDNy6CHr47FUXRKrqsPy-BH4Q97H8uVUGo";
    bool showpass = false;
    private string idToken;
    public static string localId;

    public GameObject Login_btn,progressIndicator;

    private void OnEnable()
    {
        progressIndicator.SetActive(false);
        Login_btn.SetActive(true);
        print("enable");
        validation_text.SetActive(false);
    }
    private void Start()
    {
        
        progressIndicator.SetActive(false);
        Login_btn.SetActive(true);
        validation_text.SetActive(false);
        validation_text_Registration.SetActive(false);
        validation_text_forgotpass.SetActive(false);

    }
    public void SignUpUserButton()
    {
        if (emailText_For_Register.text == "")
        {
            validation_text_Registration.SetActive(true);
            validation_text_Registration.GetComponent<Text>().text = "Enter Your Email";
        }
        else if (passwordText_For_Register.text == "")
        {
            validation_text_Registration.SetActive(true);
            validation_text_Registration.GetComponent<Text>().text = "Enter Your Password";
        }
        else if (passwordText_For_Register_Confirm.text == "")
        {
            validation_text_Registration.SetActive(true);
            validation_text_Registration.GetComponent<Text>().text = "Confirm Your Password";
        }
        else if (passwordText_For_Register_Confirm.text.Length < 8 )
        {
            validation_text_Registration.SetActive(true);
            validation_text_Registration.GetComponent<Text>().text = "Password is too short";
        }
        else if (passwordText_For_Register.text == passwordText_For_Register_Confirm.text)
        {
            SignUpUser(emailText_For_Register.text, passwordText_For_Register.text);
        }

        else
        {
            validation_text_Registration.SetActive(true);
            validation_text_Registration.GetComponent<Text>().text = "Password Dont Match";
        }
        
    }
    public void ShowPassword(InputField pass)
    {
        showpass = !showpass;
        if (showpass)
        {
            pass.contentType = InputField.ContentType.Standard;
            pass.Select();

        }
        else
        {
            pass.contentType = InputField.ContentType.Password;
            pass.Select();
        } 
        
    }
    public void SignInUserButton()
    {
        if (emailText_For_Login.text == "")
        {
            validation_text.SetActive(true);
            validation_text.GetComponent<Text>().text = "Enter Your Email";
        }
        else if (passwordText_For_Login.text == "")
        {
            validation_text.SetActive(true);
            validation_text.GetComponent<Text>().text = "Enter Your Password";
        }
        else 
        {
            progressIndicator.SetActive(true);
            Login_btn.SetActive(false);
            SignInUser(emailText_For_Login.text, passwordText_For_Login.text);
        }
        
    }

    private void SignUpUser(string email, string password)
    {

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
            RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=" + AuthKey, userData).Then(
                response =>
                {
                    idToken = response.idToken;
                    localId = response.localId;
                    print("Signed up");
                    PlayerPrefs.SetString("Current_idToken", idToken);
                    PlayerPrefs.SetString("Current_localId", localId);

                    Menu_Handler_Script.instance.Open_Doctor_Profile_Panel_FUN();



                }).Catch(error =>
                {
                    Debug.Log(error.Message);
                    print("User Already Exist");
                    validation_text_Registration.SetActive(true);
                    validation_text_Registration.GetComponent<Text>().text = "User Already Exist / Invalid Email";
                });
        }
        else
        {
            Menu_Handler_Script.instance.Internet_Problem_FUN();
            Debug.Log("Check Your Network Connection");
        }
       
    }

    private void SignInUser(string email, string password)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
            RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=" + AuthKey, userData).Then(
                response =>
                {
                    idToken = response.idToken;
                    localId = response.localId;
                    print("Signed in");
                    PlayerPrefs.SetString("Current_idToken", idToken);
                    PlayerPrefs.SetString("Current_localId", localId);
                    progressIndicator.SetActive(false);
                    Login_btn.SetActive(true);
                    Menu_Handler_Script.instance.Open_Home_Panel_FUN();
                    //GetUsername();
                }).Catch(error =>
                {
                    Debug.Log(error.Message);
                    validation_text.SetActive(true);
                    progressIndicator.SetActive(false);
                    Login_btn.SetActive(true);
                    validation_text.SetActive(true);
                    validation_text.GetComponent<Text>().text = "Wrong Email or Password / Connection Error";
                    print("Wrong Email or Password / Connection Error");
                });
        }
        else
        {
            Menu_Handler_Script.instance.Internet_Problem_FUN();
            Debug.Log("Check Your Network Connection");
        }
           
    }
    private void Update()
    {


       // print(Application.internetReachability);
        }
    public void logout()
    {
        Debug.Log("Logout");
        Menu_Handler_Script.instance.Open_Login_Panel_FUN();
    }

    public void RestPassword()
    {
        Debug.Log("Reseting Password");
    }
    public void reset_Password_btn()
    {
        reset_Password(emailText_ResetPassword.text, requestType = "PASSWORD_RESET");
    }

    public void reset_Password(string email, string requestType)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            string payLoad = "{\"requestType\":\"" + requestType + "\",\"email\":\"" + email + "\"}";
            RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/getOobConfirmationCode?key=" + AuthKey, payLoad).Then(
                response =>
                {
                    idToken = response.idToken;
                    localId = response.localId;
                    print("Reset Email sent");
                    Menu_Handler_Script.instance.Open_Rest_Password_Panel_FUN();
                //GetUsername();
            }).Catch(error =>
            {
                Debug.Log(error.Message);
                print("user not found");
                validation_text_forgotpass.SetActive(true);
                validation_text_forgotpass.GetComponent<Text>().text = "User not found";
            });
        }
        else
        {
            Menu_Handler_Script.instance.Internet_Problem_FUN();
            Debug.Log("Check Your Network Connection");
        }
            
    }

}
