using UnityEngine;
using System.IO;
using System.Linq;
using System.Collections.Generic;
//using CsvHelper;
//using CsvHelper.Configuration;
//using CsvHelper.Configuration.Attributes;

public class transfrompos : MonoBehaviour
{
    public transfrompos instance;
    public int Token = 0;
    public int count = 0;
    private static string reportSeparator = ",";

    [SerializeField]
    float eulerAnghips_x;
    [SerializeField]
    float eulerAnghips_y;
    [SerializeField]
    float eulerAnghips_z;
    [SerializeField]
    float eulerAngSpine_x;
    [SerializeField]
    float eulerAngSpine_y;
    [SerializeField]
    float eulerAngSpine_z;
    [SerializeField]
    float eulerAngNeck_x;
    [SerializeField]
    float eulerAngNeck_y;
    [SerializeField]
    float eulerAngNeck_z;
    [SerializeField]
    float eulerAngHead_x;
    [SerializeField]
    float eulerAngHead_y;
    [SerializeField]
    float eulerAngHead_z;
    [SerializeField]
    float eulerAngleftShoulder_x;
    [SerializeField]
    float eulerAngleftShoulder_y;
    [SerializeField]
    float eulerAngleftShoulder_z;
    [SerializeField]
    float eulerAngRightShoulder_x;
    [SerializeField]
    float eulerAngRightShoulder_y;
    [SerializeField]
    float eulerAngRightShoulder_z;
    [SerializeField]
    float eulerAngleftArm_x;
    [SerializeField]
    float eulerAngleftArm_y;
    [SerializeField]
    float eulerAngleftArm_z;
    [SerializeField]
    float eulerAngleftForeArm_x;
    [SerializeField]
    float eulerAngleftForeArm_y;
    [SerializeField]
    float eulerAngleftForeArm_z;
    [SerializeField]
    float eulerAngleftHand_x;
    [SerializeField]
    float eulerAngleftHand_y;
    [SerializeField]
    float eulerAngleftHand_z;
    [SerializeField]
    float eulerAngRightArm_x;
    [SerializeField]
    float eulerAngRightArm_y;
    [SerializeField]
    float eulerAngRightArm_z;
    [SerializeField]
    float eulerAngRightForeArm_x;
    [SerializeField]
    float eulerAngRightForeArm_y;
    [SerializeField]
    float eulerAngRightForeArm_z;
    [SerializeField]
    float eulerAngRightHand_x;
    [SerializeField]
    float eulerAngRightHand_y;
    [SerializeField]
    float eulerAngRightHand_z;
    [SerializeField]
    float eulerAngleftUpLeg_x;
    [SerializeField]
    float eulerAngleftUpLeg_y;
    [SerializeField]
    float eulerAngleftUpLeg_z;
    [SerializeField]
    float eulerAngleftLeg_x;
    [SerializeField]
    float eulerAngleftLeg_y;
    [SerializeField]
    float eulerAngleftLeg_z;
    [SerializeField]
    float eulerAngleftFoot_x;
    [SerializeField]
    float eulerAngleftFoot_y;
    [SerializeField]
    float eulerAngleftFoot_z;
    [SerializeField]
    float eulerAngrightUpLeg_x;
    [SerializeField]
    float eulerAngrightUpLeg_y;
    [SerializeField]
    float eulerAngrightUpLeg_z;
    [SerializeField]
    float eulerAngrightLeg_x;
    [SerializeField]
    float eulerAngrightLeg_y;
    [SerializeField]
    float eulerAngrightLeg_z;
    [SerializeField]
    float eulerAngrightFoot_x;
    [SerializeField]
    float eulerAngrightFoot_y;
    [SerializeField]
    float eulerAngrightFoot_z;





    [SerializeField]
    string Avg_hips_x;
    [SerializeField]
    string Avg_hips_y;
    [SerializeField]
    string Avg_hips_z;
    [SerializeField]
    string Avg_Spine_x;
    [SerializeField]
    string Avg_Spine_y;
    [SerializeField]
    string Avg_Spine_z;
    [SerializeField]
    string Avg_Neck_x;
    [SerializeField]
    string Avg_Neck_y;
    [SerializeField]
    string Avg_Neck_z;
    [SerializeField]
    string Avg_Head_x;
    [SerializeField]
    string Avg_Head_y;
    [SerializeField]
    string Avg_Head_z;
    [SerializeField]
    string Avg_leftShoulder_x;
    [SerializeField]
    string Avg_leftShoulder_y;
    [SerializeField]
    string Avg_leftShoulder_z;
    [SerializeField]
    string Avg_RightShoulder_x;
    [SerializeField]
    string Avg_RightShoulder_y;
    [SerializeField]
    string Avg_RightShoulder_z;
    [SerializeField]
    string Avg_leftArm_x;
    [SerializeField]
    string Avg_leftArm_y;
    [SerializeField]
    string Avg_leftArm_z;
    [SerializeField]
    string Avg_leftForeArm_x;
    [SerializeField]
    string Avg_leftForeArm_y;
    [SerializeField]
    string Avg_leftForeArm_z;
    [SerializeField]
    string Avg_leftHand_x;
    [SerializeField]
    string Avg_leftHand_y;
    [SerializeField]
    string Avg_leftHand_z;
    [SerializeField]
    string Avg_RightArm_x;
    [SerializeField]
    string Avg_RightArm_y;
    [SerializeField]
    string Avg_RightArm_z;
    [SerializeField]
    string Avg_RightForeArm_x;
    [SerializeField]
    string Avg_RightForeArm_y;
    [SerializeField]
    string Avg_RightForeArm_z;
    [SerializeField]
    string Avg_RightHand_x;
    [SerializeField]
    string Avg_RightHand_y;
    [SerializeField]
    string Avg_RightHand_z;
    [SerializeField]
    string Avg_leftUpLeg_x;
    [SerializeField]
    string Avg_leftUpLeg_y;
    [SerializeField]
    string Avg_leftUpLeg_z;
    [SerializeField]
    string Avg_leftLeg_x;
    [SerializeField]
    string Avg_leftLeg_y;
    [SerializeField]
    string Avg_leftLeg_z;
    [SerializeField]
    string Avg_leftFoot_x;
    [SerializeField]
    string Avg_leftFoot_y;
    [SerializeField]
    string Avg_leftFoot_z;
    [SerializeField]
    string Avg_rightUpLeg_x;
    [SerializeField]
    string Avg_rightUpLeg_y;
    [SerializeField]
    string Avg_rightUpLeg_z;
    [SerializeField]
    string Avg_rightLeg_x;
    [SerializeField]
    string Avg_rightLeg_y;
    [SerializeField]
    string Avg_rightLeg_z;
    [SerializeField]
    string Avg_rightFoot_x;
    [SerializeField]
    string Avg_rightFoot_y;
    [SerializeField]
    string Avg_rightFoot_z;

    [SerializeField]
    string RMSE_hips_x;
    [SerializeField]
    string RMSE_hips_y;
    [SerializeField]
    string RMSE_hips_z;
    [SerializeField]
    string RMSE_Spine_x;
    [SerializeField]
    string RMSE_Spine_y;
    [SerializeField]
    string RMSE_Spine_z;
    [SerializeField]
    string RMSE_Neck_x;
    [SerializeField]
    string RMSE_Neck_y;
    [SerializeField]
    string RMSE_Neck_z;
    [SerializeField]
    string RMSE_Head_x;
    [SerializeField]
    string RMSE_Head_y;
    [SerializeField]
    string RMSE_Head_z;
    [SerializeField]
    string RMSE_leftShoulder_x;
    [SerializeField]
    string RMSE_leftShoulder_y;
    [SerializeField]
    string RMSE_leftShoulder_z;
    [SerializeField]
    string RMSE_RightShoulder_x;
    [SerializeField]
    string RMSE_RightShoulder_y;
    [SerializeField]
    string RMSE_RightShoulder_z;
    [SerializeField]
    string RMSE_leftArm_x;
    [SerializeField]
    string RMSE_leftArm_y;
    [SerializeField]
    string RMSE_leftArm_z;
    [SerializeField]
    string RMSE_leftForeArm_x;
    [SerializeField]
    string RMSE_leftForeArm_y;
    [SerializeField]
    string RMSE_leftForeArm_z;
    [SerializeField]
    string RMSE_leftHand_x;
    [SerializeField]
    string RMSE_leftHand_y;
    [SerializeField]
    string RMSE_leftHand_z;
    [SerializeField]
    string RMSE_RightArm_x;
    [SerializeField]
    string RMSE_RightArm_y;
    [SerializeField]
    string RMSE_RightArm_z;
    [SerializeField]
    string RMSE_RightForeArm_x;
    [SerializeField]
    string RMSE_RightForeArm_y;
    [SerializeField]
    string RMSE_RightForeArm_z;
    [SerializeField]
    string RMSE_RightHand_x;
    [SerializeField]
    string RMSE_RightHand_y;
    [SerializeField]
    string RMSE_RightHand_z;
    [SerializeField]
    string RMSE_leftUpLeg_x;
    [SerializeField]
    string RMSE_leftUpLeg_y;
    [SerializeField]
    string RMSE_leftUpLeg_z;
    [SerializeField]
    string RMSE_leftLeg_x;
    [SerializeField]
    string RMSE_leftLeg_y;
    [SerializeField]
    string RMSE_leftLeg_z;
    [SerializeField]
    string RMSE_leftFoot_x;
    [SerializeField]
    string RMSE_leftFoot_y;
    [SerializeField]
    string RMSE_leftFoot_z;
    [SerializeField]
    string RMSE_rightUpLeg_x;
    [SerializeField]
    string RMSE_rightUpLeg_y;
    [SerializeField]
    string RMSE_rightUpLeg_z;
    [SerializeField]
    string RMSE_rightLeg_x;
    [SerializeField]
    string RMSE_rightLeg_y;
    [SerializeField]
    string RMSE_rightLeg_z;
    [SerializeField]
    string RMSE_rightFoot_x;
    [SerializeField]
    string RMSE_rightFoot_y;
    [SerializeField]
    string Avg2_rightFoot_z;


    public Animator ybot;
    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        eulerAnghips_x = ybot.GetBoneTransform(HumanBodyBones.Hips).localEulerAngles.x;
        eulerAnghips_y = ybot.GetBoneTransform(HumanBodyBones.Hips).localEulerAngles.y;
        eulerAnghips_z = ybot.GetBoneTransform(HumanBodyBones.Hips).localEulerAngles.z;

        eulerAngSpine_x = ybot.GetBoneTransform(HumanBodyBones.Spine).localEulerAngles.x;
        eulerAngSpine_y = ybot.GetBoneTransform(HumanBodyBones.Spine).localEulerAngles.y;
        eulerAngSpine_z = ybot.GetBoneTransform(HumanBodyBones.Spine).localEulerAngles.z;

        eulerAngNeck_x = ybot.GetBoneTransform(HumanBodyBones.Neck).localEulerAngles.x;
        eulerAngNeck_y = ybot.GetBoneTransform(HumanBodyBones.Neck).localEulerAngles.y;
        eulerAngNeck_z = ybot.GetBoneTransform(HumanBodyBones.Neck).localEulerAngles.z;

        eulerAngHead_x = ybot.GetBoneTransform(HumanBodyBones.Head).localEulerAngles.x;
        eulerAngHead_y = ybot.GetBoneTransform(HumanBodyBones.Head).localEulerAngles.y;
        eulerAngHead_z = ybot.GetBoneTransform(HumanBodyBones.Head).localEulerAngles.z;

        eulerAngleftShoulder_x = ybot.GetBoneTransform(HumanBodyBones.LeftShoulder).localEulerAngles.x;
        eulerAngleftShoulder_y = ybot.GetBoneTransform(HumanBodyBones.LeftShoulder).localEulerAngles.y;
        eulerAngleftShoulder_z = ybot.GetBoneTransform(HumanBodyBones.LeftShoulder).localEulerAngles.z;

        eulerAngRightShoulder_x = ybot.GetBoneTransform(HumanBodyBones.RightShoulder).localEulerAngles.x;
        eulerAngRightShoulder_y = ybot.GetBoneTransform(HumanBodyBones.RightShoulder).localEulerAngles.y;
        eulerAngRightShoulder_z = ybot.GetBoneTransform(HumanBodyBones.RightShoulder).localEulerAngles.z;

        eulerAngleftArm_x = ybot.GetBoneTransform(HumanBodyBones.LeftUpperArm).localEulerAngles.x;
        eulerAngleftArm_y = ybot.GetBoneTransform(HumanBodyBones.LeftUpperArm).localEulerAngles.y;
        eulerAngleftArm_z = ybot.GetBoneTransform(HumanBodyBones.LeftUpperArm).localEulerAngles.z;

        eulerAngleftForeArm_x = ybot.GetBoneTransform(HumanBodyBones.LeftLowerArm).localEulerAngles.x;
        eulerAngleftForeArm_y = ybot.GetBoneTransform(HumanBodyBones.LeftLowerArm).localEulerAngles.y;
        eulerAngleftForeArm_z = ybot.GetBoneTransform(HumanBodyBones.LeftLowerArm).localEulerAngles.z;

        eulerAngleftHand_x = ybot.GetBoneTransform(HumanBodyBones.LeftHand).localEulerAngles.x;
        eulerAngleftHand_y = ybot.GetBoneTransform(HumanBodyBones.LeftHand).localEulerAngles.y;
        eulerAngleftHand_z = ybot.GetBoneTransform(HumanBodyBones.LeftHand).localEulerAngles.z;

        eulerAngRightArm_x = ybot.GetBoneTransform(HumanBodyBones.RightUpperArm).localEulerAngles.x;
        eulerAngRightArm_y = ybot.GetBoneTransform(HumanBodyBones.RightUpperArm).localEulerAngles.y;
        eulerAngRightArm_z = ybot.GetBoneTransform(HumanBodyBones.RightUpperArm).localEulerAngles.z;

        eulerAngRightForeArm_x = ybot.GetBoneTransform(HumanBodyBones.RightLowerArm).localEulerAngles.x;
        eulerAngRightForeArm_y = ybot.GetBoneTransform(HumanBodyBones.RightLowerArm).localEulerAngles.y;
        eulerAngRightForeArm_z = ybot.GetBoneTransform(HumanBodyBones.RightLowerArm).localEulerAngles.z;

        eulerAngRightHand_x = ybot.GetBoneTransform(HumanBodyBones.RightHand).localEulerAngles.x;
        eulerAngRightHand_y = ybot.GetBoneTransform(HumanBodyBones.RightHand).localEulerAngles.y;
        eulerAngRightHand_z = ybot.GetBoneTransform(HumanBodyBones.RightHand).localEulerAngles.z;

        eulerAngleftUpLeg_x = ybot.GetBoneTransform(HumanBodyBones.LeftUpperLeg).localEulerAngles.x;
        eulerAngleftUpLeg_y = ybot.GetBoneTransform(HumanBodyBones.LeftUpperLeg).localEulerAngles.y;
        eulerAngleftUpLeg_z = ybot.GetBoneTransform(HumanBodyBones.LeftUpperLeg).localEulerAngles.z;

        eulerAngleftLeg_x = ybot.GetBoneTransform(HumanBodyBones.LeftLowerLeg).localEulerAngles.x;
        eulerAngleftLeg_y = ybot.GetBoneTransform(HumanBodyBones.LeftLowerLeg).localEulerAngles.y;
        eulerAngleftLeg_z = ybot.GetBoneTransform(HumanBodyBones.LeftLowerLeg).localEulerAngles.z;

        eulerAngleftFoot_x = ybot.GetBoneTransform(HumanBodyBones.LeftFoot).localEulerAngles.x;
        eulerAngleftFoot_y = ybot.GetBoneTransform(HumanBodyBones.LeftFoot).localEulerAngles.y;
        eulerAngleftFoot_z = ybot.GetBoneTransform(HumanBodyBones.LeftFoot).localEulerAngles.z;

        eulerAngrightUpLeg_x = ybot.GetBoneTransform(HumanBodyBones.RightUpperLeg).localEulerAngles.x;
        eulerAngrightUpLeg_y = ybot.GetBoneTransform(HumanBodyBones.RightUpperLeg).localEulerAngles.y;
        eulerAngrightUpLeg_z = ybot.GetBoneTransform(HumanBodyBones.RightUpperLeg).localEulerAngles.z;

        eulerAngrightLeg_x = ybot.GetBoneTransform(HumanBodyBones.RightLowerLeg).localEulerAngles.x;
        eulerAngrightLeg_y = ybot.GetBoneTransform(HumanBodyBones.RightLowerLeg).localEulerAngles.y;
        eulerAngrightLeg_z = ybot.GetBoneTransform(HumanBodyBones.RightLowerLeg).localEulerAngles.z;

        eulerAngrightFoot_x = ybot.GetBoneTransform(HumanBodyBones.RightFoot).localEulerAngles.x;
        eulerAngrightFoot_y = ybot.GetBoneTransform(HumanBodyBones.RightFoot).localEulerAngles.y;
        eulerAngrightFoot_z = ybot.GetBoneTransform(HumanBodyBones.RightFoot).localEulerAngles.z;

        if (Token == 1)
        {

            count++;
            DEV_AppendDefaultsToReport();


        }


    }
    void DEV_AppendDefaultsToReport()
    {
        print(eulerAngrightFoot_x.ToString());

        CSVManager.AppendToReport(
            new string[54] {
                eulerAnghips_x.ToString(),
                eulerAnghips_y.ToString(),
                eulerAnghips_z.ToString(),

                eulerAngSpine_x.ToString(),
                eulerAngSpine_y.ToString(),
                eulerAngSpine_z.ToString(),

                eulerAngNeck_x.ToString(),
                eulerAngNeck_y.ToString(),
                eulerAngNeck_z.ToString(),

                eulerAngHead_x.ToString(),
                eulerAngHead_y.ToString(),
                eulerAngHead_z.ToString(),

                eulerAngleftShoulder_x.ToString(),
                eulerAngleftShoulder_y.ToString(),
                eulerAngleftShoulder_z.ToString(),

                eulerAngRightShoulder_x.ToString(),
                eulerAngRightShoulder_y.ToString(),
                eulerAngRightShoulder_z.ToString(),

                eulerAngleftArm_x.ToString(),
                eulerAngleftArm_y.ToString(),
                eulerAngleftArm_z.ToString(),

                eulerAngleftForeArm_x.ToString(),
                eulerAngleftForeArm_y.ToString(),
                eulerAngleftForeArm_z.ToString(),

                eulerAngleftHand_x.ToString(),
                eulerAngleftHand_y.ToString(),
                eulerAngleftHand_z.ToString(),

                eulerAngRightArm_x.ToString(),
                eulerAngRightArm_y.ToString(),
                eulerAngRightArm_z.ToString(),

                eulerAngRightArm_x.ToString(),
                eulerAngRightArm_y.ToString(),
                eulerAngRightArm_z.ToString(),

                eulerAngRightHand_x.ToString(),
                eulerAngRightHand_y.ToString(),
                eulerAngRightHand_z.ToString(),

                eulerAngleftUpLeg_x.ToString(),
                eulerAngleftUpLeg_y.ToString(),
                eulerAngleftUpLeg_z.ToString(),

                eulerAngleftLeg_x.ToString(),
                eulerAngleftLeg_y.ToString(),
                eulerAngleftLeg_z.ToString(),

                eulerAngleftFoot_x.ToString(),
                eulerAngleftFoot_y.ToString(),
                eulerAngleftFoot_z.ToString(),

                eulerAngrightUpLeg_x.ToString(),
                eulerAngrightUpLeg_y.ToString(),
                eulerAngrightUpLeg_z.ToString(),

                eulerAngrightLeg_x.ToString(),
                eulerAngrightLeg_y.ToString(),
                eulerAngrightLeg_z.ToString(),

                eulerAngrightFoot_x.ToString(),
                eulerAngrightFoot_y.ToString(),
                eulerAngrightFoot_z.ToString()
            }
        );
        Debug.Log("<color=green>Report updated successfully!</color>");
    }

    public void start_recording()
    {
        Token = 1;
        count = 1;
        print(count);
    }
    public void stop_recording()
    {
        Token = 0;

        print(count);
    }

    public void get_avg()
    {
        CSVManager.CreateReport1();
        //var dataset = Resources.Load<TextAsset>("W:\\csv test\\CSharpToCSV\\Assets\\Report\report.csv");
        var dataset = File.ReadAllText(@"W:\\csv test\\CSharpToCSV\\Assets\\Report\report.csv");
        var dataLines = dataset.Split(','); // Split also works with simple arguments, no need to pass char[]
        using (StreamWriter sw = File.AppendText(@"W:\\csv test\\CSharpToCSV\\Assets\\Report\report2.csv"))
        {
            for (int i = 0; i < dataLines.Length; i++)
            {
                var data = dataLines[i].Split(',');
                //string data1 = data;

                for (int d = 0; d < data.Length; d++)
                {
                    print(data[d]); // what you get is split sequential data that is column-first, then row
                                    //CSVManager.AppendToReport2(new string[]{
                                    //   data[i]

                    //data[d] += reportSeparator;

                    sw.WriteLine(data[d]);


                    //for(int k = 0; k < data.Length; k++)
                    //{
                    //  sw.WriteLine("," + data[d]);
                    //}
                    //sw.WriteLine(data[1]);
                    //sw.WriteLine(data[2]);
                    //sw.WriteLine(data[3]);


                }


            }

        }


        Avg_hips_x = "=AVERAGE(A2:A" + count + ")";
        Avg_hips_y = "=AVERAGE(B2:B" + count + ")";
        Avg_hips_z = "=AVERAGE(C2:C" + count + ")";

        Avg_Spine_x = "=AVERAGE(D2:D" + count + ")";
        Avg_Spine_y = "=AVERAGE(E2:E" + count + ")";
        Avg_Spine_z = "=AVERAGE(F2:F" + count + ")";

        Avg_Neck_x = "=AVERAGE(G2:G" + count + ")";
        Avg_Neck_y = "=AVERAGE(H2:H" + count + ")";
        Avg_Neck_z = "=AVERAGE(I2:I" + count + ")";

        Avg_Head_x = "=AVERAGE(J2:J" + count + ")";
        Avg_Head_y = "=AVERAGE(K2:K" + count + ")";
        Avg_Head_z = "=AVERAGE(L2:L" + count + ")";

        Avg_leftShoulder_x = "=AVERAGE(M2:M" + count + ")";
        Avg_leftShoulder_y = "=AVERAGE(N2:N" + count + ")";
        Avg_leftShoulder_z = "=AVERAGE(O2:O" + count + ")";

        Avg_RightShoulder_x = "=AVERAGE(P2:P" + count + ")";
        Avg_RightShoulder_y = "=AVERAGE(Q2:Q" + count + ")";
        Avg_RightShoulder_z = "=AVERAGE(R2:R" + count + ")";

        Avg_leftArm_x = "=AVERAGE(S2:S" + count + ")";
        Avg_leftArm_y = "=AVERAGE(T2:T" + count + ")";
        Avg_leftArm_z = "=AVERAGE(U2:U" + count + ")";

        Avg_leftForeArm_x = "=AVERAGE(V2:V" + count + ")";
        Avg_leftForeArm_y = "=AVERAGE(W2:W" + count + ")";
        Avg_leftForeArm_z = "=AVERAGE(X2:X" + count + ")";

        Avg_leftHand_x = "=AVERAGE(Y2:Y" + count + ")";
        Avg_leftHand_y = "=AVERAGE(Z2:Z" + count + ")";
        Avg_leftHand_z = "=AVERAGE(AA2:AA" + count + ")";

        Avg_RightArm_x = "=AVERAGE(AB2:AB" + count + ")";
        Avg_RightArm_y = "=AVERAGE(AC2:AC" + count + ")";
        Avg_RightArm_z = "=AVERAGE(AD2:AD" + count + ")";

        Avg_RightForeArm_x = "=AVERAGE(AE2:AE" + count + ")";
        Avg_RightForeArm_y = "=AVERAGE(AF2:AF" + count + ")";
        Avg_RightForeArm_z = "=AVERAGE(AG2:AG" + count + ")";

        Avg_RightHand_x = "=AVERAGE(AH2:AH" + count + ")";
        Avg_RightHand_y = "=AVERAGE(AI2:AI" + count + ")";
        Avg_RightHand_z = "=AVERAGE(AJ2:AJ" + count + ")";

        Avg_leftUpLeg_x = "=AVERAGE(AK2:AK" + count + ")";
        Avg_leftUpLeg_y = "=AVERAGE(AL2:AL" + count + ")";
        Avg_leftUpLeg_z = "=AVERAGE(AM2:AM" + count + ")";

        Avg_leftLeg_x = "=AVERAGE(AN2:AN" + count + ")";
        Avg_leftLeg_y = "=AVERAGE(AO2:AO" + count + ")";
        Avg_leftLeg_z = "=AVERAGE(AP2:AP" + count + ")";

        Avg_leftFoot_x = "=AVERAGE(AQ2:AQ" + count + ")";
        Avg_leftFoot_y = "=AVERAGE(AR2:AR" + count + ")";
        Avg_leftFoot_z = "=AVERAGE(AS2:AS" + count + ")";

        Avg_rightUpLeg_x = "=AVERAGE(AT2:AT" + count + ")";
        Avg_rightUpLeg_y = "=AVERAGE(AU2:AU" + count + ")";
        Avg_rightUpLeg_z = "=AVERAGE(AV2:AV" + count + ")";

        Avg_rightLeg_x = "=AVERAGE(AW2:AW" + count + ")";
        Avg_rightLeg_y = "=AVERAGE(AX2:AX" + count + ")";
        Avg_rightLeg_z = "=AVERAGE(AY2:AY" + count + ")";

        Avg_rightFoot_x = "=AVERAGE(AZ2:AZ" + count + ")";
        Avg_rightFoot_y = "=AVERAGE(BA2:BA" + count + ")";
        Avg_rightFoot_z = "=AVERAGE(BB2:BB" + count + ")";
        CSVManager.AppendToReport(
            new string[54] {
        Avg_hips_x,
        Avg_hips_y,
        Avg_hips_z,

        Avg_Spine_x,
        Avg_Spine_y,
        Avg_Spine_z,

        Avg_Neck_x,
        Avg_Neck_y,
        Avg_Neck_z,

        Avg_Head_x,
        Avg_Head_y,
        Avg_Head_z,

        Avg_leftShoulder_x,
        Avg_leftShoulder_y,
        Avg_leftShoulder_z,

        Avg_RightShoulder_x,
        Avg_RightShoulder_y,
        Avg_RightShoulder_z,

        Avg_leftArm_x,
        Avg_leftArm_y,
        Avg_leftArm_z,

        Avg_leftForeArm_x,
        Avg_leftForeArm_y,
        Avg_leftForeArm_z,

        Avg_leftHand_x,
        Avg_leftHand_y,
        Avg_leftHand_z,

        Avg_RightArm_x,
        Avg_RightArm_y,
        Avg_RightArm_z,

        Avg_RightForeArm_x,
        Avg_RightForeArm_y,
        Avg_RightForeArm_z,

        Avg_RightHand_x,
        Avg_RightHand_y,
        Avg_RightHand_z,

        Avg_leftUpLeg_x,
        Avg_leftUpLeg_y,
        Avg_leftUpLeg_z,

        Avg_leftLeg_x,
        Avg_leftLeg_y,
        Avg_leftLeg_z,

        Avg_leftFoot_x,
        Avg_leftFoot_y,
        Avg_leftFoot_z,

        Avg_rightUpLeg_x,
        Avg_rightUpLeg_y,
        Avg_rightUpLeg_z,

        Avg_rightLeg_x,
        Avg_rightLeg_y,
        Avg_rightLeg_z,

        Avg_rightFoot_x,
        Avg_rightFoot_y,
        Avg_rightFoot_z,
    }
    );
        //Debug.Log("<color=green>Average updated successfully!</color>");
        //var textReader = new StreamReader("W:\\csv test\\CSharpToCSV\\Assets\\Report\report.csv");
        //var csv = new CsvReader(textReader, System.Globalization.CultureInfo.CreateSpecificCulture("enUS"));
        //var records = csv.GetRecords<report>();
        // var average = records.Average(_ => _.hips_x);
        // print("avs is: " + average);

        /* var reader = new StreamReader(File.OpenRead(@"W:\\csv test\\CSharpToCSV\\Assets\\Report\report.csv"));
         List<string> listA = new List<string>();
         List<string> listB = new List<string>();
         while (!reader.EndOfStream)
         {
         var line = reader.ReadLine();
         var values = line.Split(';');

             listA.Add(values[0]);
             //listB.Add(values[1]);

         }
         int headerRow = 1;
         foreach (var values in listA.Skip(headerRow))
         {
             Debug.Log(values);
         }*/

        /*var contents = File.ReadAllText(@"W:\\csv test\\CSharpToCSV\\Assets\\Report\report.csv").Split('\n');
        var csv = from line in contents
                  select line.Split(',').ToArray();

        int headerRows = 1;
        foreach (var row in csv.Skip(headerRows)
            .TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0))
        {
            string zerothColumnValue = row[0]; // leftmost column
            var firstColumnValue = row[1];
        }*/



        //}
    }
}