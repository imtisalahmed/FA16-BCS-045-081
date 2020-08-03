using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Check_Script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Dummy") {
            Task_Handler_Script.instance.Tutoiral_Completed();
        }
        if (collision.gameObject.tag == "Player")
        {
            Task_Handler_Script.instance.Task_Completed();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag == "Dummy")
        {
            Task_Handler_Script.instance.Tutoiral_Completed();
        }
        if (other.tag == "Player")
        {
            Task_Handler_Script.instance.Task_Completed();
        }
    }
}
