using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bilboard : MonoBehaviour {

    private GameObject _camera;


    void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.LookAt(_camera.transform.position);
    }
}
