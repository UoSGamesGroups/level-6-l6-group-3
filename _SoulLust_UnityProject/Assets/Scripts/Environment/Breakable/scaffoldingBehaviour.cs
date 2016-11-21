using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaffoldingBehaviour : MonoBehaviour {

    [SerializeField] Rigidbody[] rigid;
    bool isBroken = false;


    //void Update()
    //{
    //    foreach (Rigidbody r in rigid)
    //    {
    //        if (r.velocity == Vector3.zero && isBroken)
    //        {
    //            r.isKinematic = true;
    //        }
    //    }
    //}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "weapon")
        {
            foreach (Rigidbody r in rigid)
            {
                r.isKinematic = false;
               // isBroken = true;
            }
        }
    }
}
