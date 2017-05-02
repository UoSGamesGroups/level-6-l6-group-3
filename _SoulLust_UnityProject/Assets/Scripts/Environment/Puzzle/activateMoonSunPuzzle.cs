using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMoonSunPuzzle : MonoBehaviour {


    [SerializeField] openGateOnTrigger openDoorAnimationActive;
    private bool isM1;
    private bool isM2;
    private bool isS1;
    private bool isS2;

    public bool isActivated;
    private Animator _camera;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }


    private void Update()
    {
        if (isM1 && isM2 && isS1 && isS2)
        {
            isActivated = true;
            _camera.SetTrigger("shake");
            openDoorAnimationActive.activateShake=true;
            this.enabled = false;

        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "m1")
        {
            isM1 = true;
        }

        if (col.gameObject.tag == "m2")
        {
            isM2 = true;
        }

        if (col.gameObject.tag == "s1")
        {
            isS1 = true;
        }

        if (col.gameObject.tag == "s2")
        {
            isS2 = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag != "m1")
        {
            isM1 = false;
        }

        if (col.gameObject.tag != "m2")
        {
            isM2 = false;
        }

        if (col.gameObject.tag != "s1")
        {
            isS1 = false;
        }

        if (col.gameObject.tag != "s2")
        {
            isS2 = false;
        }
    }

}
