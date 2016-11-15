using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearsBehaviour : MonoBehaviour {

    Animator anim;

    private float randomStart;
    private float currentTime;



    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        randomStart = Random.Range(1f, 3f);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= randomStart)
        {
            anim.SetBool("attack", true);
            this.enabled = false;
        }
    }






}
