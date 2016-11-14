using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGateOnTrigger : MonoBehaviour {

    private Animator _camera;
    [SerializeField] Animator anim;
    [SerializeField]private float endTime;
    private float currentTime;
    private bool activateShake;


    void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetTrigger("open");
            activateShake = true;
        }
    }

    void Update()
    {
        if (activateShake)
        {
            _camera.SetTrigger("shake");
            currentTime += Time.deltaTime;
        }

        if (currentTime >=endTime)
        {
            currentTime = 0f;
            activateShake = false;
        }
    }
}
