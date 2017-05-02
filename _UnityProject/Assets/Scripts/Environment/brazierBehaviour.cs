using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brazierBehaviour : MonoBehaviour {

    [SerializeField] GameObject objectToActivate;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            objectToActivate.gameObject.SetActive(true);
        }
    }
}
