using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {


    public float enemy_ms;

    private float saved_ms;

    private GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Start()
    {
        saved_ms = enemy_ms;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * enemy_ms);
    }

    void Movement()
    {
        
    }

    


}
