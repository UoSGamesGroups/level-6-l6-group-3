using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {


    public float enemy_ms;

    private float saved_ms;
    private float currentTimeRandomMovement=1f;
    private float endTimeRandomMovement=1f;
    private int randomMovement;


    private GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Start()
    {
        saved_ms = enemy_ms;
    }


    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, player.transform.position)>2f)
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * enemy_ms);
        Movement();
        RotateTowards();
    }

    void Movement()
    {
        currentTimeRandomMovement += Time.deltaTime;

        if (currentTimeRandomMovement >= endTimeRandomMovement)
        {
            randomMovement = Random.Range(1, 4);
            currentTimeRandomMovement = 0f;
        }

        switch (randomMovement)
        {
            case 1:
                break;
            case 2:
                transform.position += transform.right * Time.deltaTime * enemy_ms;
                break;
            case 3:
                transform.position -= transform.right * Time.deltaTime * enemy_ms;
                break;

        }
    }

    void RotateTowards()
    {
        Vector3 target = player.transform.position - transform.position;
        target.y =0;
        Quaternion dir = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Lerp(transform.rotation, dir, Time.deltaTime * 3f);
    }

    


}
