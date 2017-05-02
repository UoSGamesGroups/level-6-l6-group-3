using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapsCollisionWithPlayer : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SetActive(false);
        }
    }



}
