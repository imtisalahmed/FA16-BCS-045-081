using System.Collections.Generic;
using FullSerializer;
using UnityEngine;
using Proyecto26;

public static class DatabaseHandler
{
    private const string projectId = "fyp-2020-smart-rehab"; // You can find this in your Firebase project settings
    private static readonly string databaseURL = $"https://fyp-2020-smart-rehab.firebaseio.com/";
    
    private static fsSerializer serializer = new fsSerializer();

    public delegate void PostUserCallback();
    public delegate void GetUserCallback(Patient user);
    public delegate void GetUsersCallback(Dictionary<string, Patient> users);
    
    
    /// <summary>
    /// Adds a user to the Firebase Database
    /// </summary>
    /// <param name="user"> User object that will be uploaded </param>
    /// <param name="userId"> Id of the user that will be uploaded </param>
    /// <param name="callback"> What to do after the user is uploaded successfully </param>
    public static void PostUser(Patient user, string userId, PostUserCallback callback)
    {
        RestClient.Put<Patient>($"{databaseURL}users/{userId}.json", user).Then(response => { callback(); });
    }

    /// <summary>
    /// Retrieves a user from the Firebase Database, given their id
    /// </summary>
    /// <param name="userId"> Id of the user that we are looking for </param>
    /// <param name="callback"> What to do after the user is downloaded successfully </param>
    public static void GetUser(string userId, GetUserCallback callback)
    {
        RestClient.Get<Patient>($"{databaseURL}users/{userId}.json").Then(user => { callback(user); });
    }

    /// <summary>
    /// Gets all users from the Firebase Database
    /// </summary>
    /// <param name="callback"> What to do after all users are downloaded successfully </param>
    public static void GetUsers(GetUsersCallback callback)
    {
        string idToken = PlayerPrefs.GetString("Current_idToken");
        string doc_id = PlayerPrefs.GetString("Current_localId");
        RestClient.Get($"{databaseURL}Patients/" + doc_id + ".json?auth=" + idToken).Then(response =>
        {
            var responseJson = response.Text;

            // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
            // to serialize more complex types (a Dictionary, in this case)
            var data = fsJsonParser.Parse(responseJson);
            object deserialized = null;
            serializer.TryDeserialize(data, typeof(Dictionary<string, Patient>), ref deserialized);

            var users = deserialized as Dictionary<string, Patient>;
            callback(users);
        });
    }
}
