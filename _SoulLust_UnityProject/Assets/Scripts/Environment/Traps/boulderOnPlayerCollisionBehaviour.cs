using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderOnPlayerCollisionBehaviour : MonoBehaviour {

    bool isHarmful = true;

    
    void Update()
    {
        //if (transform.position.y < -10f)
        //{
        //    transform.position = new Vector3()
        //}
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "collider")
            isHarmful = false;


        if (col.gameObject.tag == "Player")
        {
            if(isHarmful)
                col.gameObject.SetActive(false);
        }
    }



}
