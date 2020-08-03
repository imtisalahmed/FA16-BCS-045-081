using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;
using Proyecto26;

public static class appointment_handler
{
    private const string projectId = "fyp-2020-smart-rehab"; // You can find this in your Firebase project settings
    private static readonly string databaseURL = $"https://fyp-2020-smart-rehab.firebaseio.com/";

    private static fsSerializer serializer = new fsSerializer();

    public delegate void PostUserCallback();
    public delegate void GetUserCallback(Appointment user);
    public delegate void GetUsersCallback(Dictionary<string, Appointment> users);




    /// <summary>
    /// Gets all users from the Firebase Database
    /// </summary>
    /// <param name="callback"> What to do after all users are downloaded successfully </param>
    public static void GetUsers(GetUsersCallback callback)
    {
        string idToken = PlayerPrefs.GetString("Current_idToken");
        string doc_id = PlayerPrefs.GetString("Current_localId");
        RestClient.Get($"https://fyp-2020-smart-rehab.firebaseio.com/Appointments/" + doc_id + ".json?auth=" + idToken).Then(response =>
        {
            var responseJson = response.Text;

            // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
            // to serialize more complex types (a Dictionary, in this case)
            var data = fsJsonParser.Parse(responseJson);
            object deserialized = null;
            serializer.TryDeserialize(data, typeof(Dictionary<string, Appointment>), ref deserialized);

            var users = deserialized as Dictionary<string, Appointment>;
            callback(users);
        }).Catch(error =>
        {
            Debug.Log(error.Message);
            Debug.Log("Appointment Not Found");

        });
    }
}
