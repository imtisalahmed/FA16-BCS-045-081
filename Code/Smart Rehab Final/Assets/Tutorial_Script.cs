using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Script : MonoBehaviour
{
    public GameObject Dummy_Avatar;
    Animator Ani;
    public GameObject CutSceneCamera;
    void Start()
    {
       

        //CutSceneCamera.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Dummy")
        {
            Ani = Dummy_Avatar.GetComponent<Animator>();
            Ani.SetBool("Tpose",true);
        }
        
    }

}
