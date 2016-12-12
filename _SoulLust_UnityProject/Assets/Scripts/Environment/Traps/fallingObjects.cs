using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObjects : MonoBehaviour {

    private Rigidbody _rigid;
    private Animator _camera;


    void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void Start()
    {
        _rigid.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _rigid.isKinematic)
        {
            _rigid.isKinematic = false;
            _camera.SetTrigger("shake");
            this.enabled = false;
        }
    }





}
