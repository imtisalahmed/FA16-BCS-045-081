//  Copyright 2016 MaterialUI for Unity http://materialunity.com
//  Please see license file for terms and conditions of use, and more information.

using System;
using UnityEngine;
using MaterialUI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Example15 : MonoBehaviour { 

    string mytime, mydate;
    public static Example15 instance;
    public string time1 = "ddd", date1="fcnjn";
   public Text Selected_time, Selected_Date;

    private void Start()
    {
        instance = this;
    }
    public void OnTimePickerButtonClicked()
    {
        DialogManager.ShowTimePicker(DateTime.MinValue.AddHours(Random.Range(0, 24)).AddMinutes(Random.Range(0, 60)), time =>
        {
            ToastManager.Show(time.ToShortTimeString());
            time1 = time.ToShortTimeString();
            print(time.ToShortTimeString());
            print(time1);
            //PlayerPrefs.SetString("currentTime", time1);
            // Selected_time.text  = (string)time1 ;
            mytime = time1;
            PlayerPrefs.SetString("ApTime", mytime);

        }, MaterialColor.Random500());



        //showtime();
    }

    public void  showtime()
    {
        Selected_time.text = mytime;
    }
    public void OnDatePickerButtonClicked()
    {
        DialogManager.ShowDatePicker(Random.Range(1980, 2050), Random.Range(1, 12), Random.Range(1, 30), (System.DateTime date) =>
        {
            ToastManager.Show(date.ToString("dd MMM, yyyy"));
            date1 = date.ToString("dd MMM, yyyy");
            print(date.ToString("dd MMM, yyyy"));
            //Selected_Date.text = date1;
            mydate = date1;
            PlayerPrefs.SetString("ndate", mydate);

        }, MaterialColor.Random500());
    }

    
}
