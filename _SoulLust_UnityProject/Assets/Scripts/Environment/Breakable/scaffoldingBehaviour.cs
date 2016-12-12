using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaffoldingBehaviour : MonoBehaviour {

    Rigidbody[] rigid;
    bool isBroken = false;
    
    void Awake()
    {
        rigid = GetComponentsInChildren<Rigidbody>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "weapon")
        {
            foreach (Rigidbody r in rigid)
            {
                r.isKinematic = false;
            }
        }
    }
}
