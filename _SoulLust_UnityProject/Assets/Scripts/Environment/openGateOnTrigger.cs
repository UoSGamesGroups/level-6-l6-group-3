﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGateOnTrigger : MonoBehaviour {

    private Animator _camera;
    [SerializeField] Animator anim;
    [SerializeField]private float endTime;
    private float currentTime;
    public bool activateShake;


    void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            activateShake = true;
        }
    }

    void OnTriggerExit()
    {
        this.enabled = false;
    }

    void Update()
    {
        if (activateShake)
        {
            anim.SetTrigger("open");
            _camera.SetTrigger("shake");
            currentTime += Time.deltaTime;
        }

        if (currentTime >=endTime)
        {
            currentTime = 0f;
            activateShake = false;
            this.enabled = false;
        }
    }
}
