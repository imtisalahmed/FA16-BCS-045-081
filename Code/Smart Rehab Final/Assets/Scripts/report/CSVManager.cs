using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class CSVManager {

    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportFile2Name = "report2.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[54] {
        "hips_x",
        "hips_y",
        "hips_z",
        "Spine_x",
        "Spine_y",
        "Spine_z",
        "Neck_x",
        "Neck_y",
        "Neck_z",
        "Head_x",
        "Head_y",
        "Head_z",
        "leftShoulder_x",
        "leftShoulder_y",
        "leftShoulder_z",
        "RightShoulder_x",
        "RightShoulder_y",
        "RightShoulder_z",
        "leftArm_x",
        "leftArm_y",
        "leftArm_z",
        "leftForeArm_x",
        "leftForeArm_y",
        "leftForeArm_z",
        "leftHand_x",
        "leftHand_y",
        "leftHand_z",
        "RightArm_x",
        "RightArm_y",
        "RightArm_z",
        "RightArm_x",
        "RightForeArm_y",
        "RightForeArm_z",
        "RightHand_x",
        "RightHand_y",
        "RightHand_z",
        "leftUpLeg_x",
        "leftUpLeg_y",
        "leftUpLeg_z",
        "leftLeg_x",
        "leftLeg_y",
        "leftLeg_z",
        "leftFoot_x",
        "leftFoot_y",
        "leftFoot_z",
        "rightUpLeg_x",
        "rightUpLeg_y",
        "rightUpLeg_z",
        "rightLeg_x",
        "rightLeg_y",
        "rightLeg_z",
        "rightFoot_x",
        "rightFoot_y",
        "rightFoot_z",



    };
   // private static string timeStampHeader = "time stamp";


#region Interactions

    public static void AppendToReport(string[] strings) {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath())) {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator /*+ GetTimeStamp()*/;
            sw.WriteLine(finalString);
            
        }
    }
    public static void AppendToReport2(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFile2Path()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator/*+ GetTimeStamp()*/;
            sw.WriteLine(finalString);
            sw.WriteLine(",");

        }
    }
    public static void CreateReport() {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath())) {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator /*+ timeStampHeader*/;
            sw.WriteLine(finalString);
        }
    }
    public static void CreateReport1()
    {
        VerifyDirectory();
        /*using (StreamWriter sw = File.CreateText(GetFile2Path()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator;
            sw.WriteLine(finalString);
        }*/
    }

    #endregion


    #region Operations

    static void VerifyDirectory() {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile() {
        string file = GetFilePath();
        if (!File.Exists(file)) {
            CreateReport();
            //CreateReport1();

        }
    }
    static void VerifyFile2()
    {
        string file = GetFile2Path();
        if (!File.Exists(file))
        {
           
            CreateReport1();

        }
    }

    #endregion


    #region Queries

    static string GetDirectoryPath() {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePath() {
        return GetDirectoryPath() + "/" + reportFileName;
      
    }
    static string GetFile2Path()
    {
        return GetDirectoryPath() + "/" + reportFile2Name;

    }

    // static string GetTimeStamp() {
    //   return System.DateTime.UtcNow.ToString();
    //}

    #endregion

}
