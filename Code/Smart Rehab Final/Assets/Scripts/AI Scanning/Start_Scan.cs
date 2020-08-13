using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Diagnostics;

using System.Runtime.InteropServices;
public class Start_Scan : MonoBehaviour
{
    //public Text Message;
    //public GameObject OpenPanel1 = null;
    // Use this for initialization
    void Start()
    {
        //python();
    }
    public void python()
    {
        ProcessStartInfo pythonInfo = new ProcessStartInfo();
        Process python;
        pythonInfo.FileName = @"C:\Users\92336\AppData\Local\Programs\Python\Python37python.exe";
        pythonInfo.Arguments = @"C:\Users\92336\Documents\ML\Tester.py";
        pythonInfo.CreateNoWindow = false;
        pythonInfo.UseShellExecute = false;
        python = Process.Start(pythonInfo);
        python.WaitForExit();
        python.Close();
    }
}