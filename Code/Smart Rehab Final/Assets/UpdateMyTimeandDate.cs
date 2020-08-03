using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMyTimeandDate : MonoBehaviour
{
    public Text timer,dateset;
    
    void Update()
    {
        timer.text = PlayerPrefs.GetString("ApTime","Time is Not Available");
        dateset.text = PlayerPrefs.GetString("ndate", "Date is Not Available");
    }
}
