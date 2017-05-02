using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour {


    private Animator camera_anim;
    

    void Awake()
    {
        camera_anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }


    void CameraSk()
    {
            camera_anim.SetTrigger("shake");
           
        
    }
}
