﻿using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {


    //KeyCode
    public KeyCode w;
    public KeyCode s;
    public KeyCode a;
    public KeyCode d;


    //Movement 
    private Rigidbody rigid;
    [SerializeField]
    private float player_ms = 300f;
    private Vector3 direction;	
    [SerializeField] Animator anim;



    //Raycasting
    private Ray ray;
    private RaycastHit raycast;
    private float dist = 1000f;
    private int layer_mask;


    //Rotate
    private Vector3 rotate;
    private Quaternion target_rotation;
    public float player_rotation_speed;


    //Gravity power
    [SerializeField] private float gravity_power = 5220f;

    //bonus
    BonusController bonus;


    void Awake()
    {
        Cursor.visible = true;

        bonus = GetComponent<BonusController>();
        rigid = GetComponent<Rigidbody>();
        layer_mask = LayerMask.GetMask("floor");
    }

    void Update()
    {
        Custom_gravity();
        Rotate_towards_mouse_pos();

    }

    void FixedUpdate()
    {
        if(bonus != null)
        {
            if(bonus.BonusMs >0f)
            {
                player_ms += bonus.BonusMs;
                bonus.BonusMs = 0f;
            }
        }

        //Movement();
        Movement_2();
    }


    void Rotate_towards_mouse_pos()
    {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(mousePos, out raycast, dist, layer_mask))
        {
            rotate = raycast.point - transform.position;
            rotate.y = 0f;

            target_rotation = Quaternion.LookRotation(rotate);

            transform.rotation = Quaternion.Lerp(transform.rotation, target_rotation, player_rotation_speed * Time.deltaTime);
        }
    }


    void Movement()
    {
        if (Input.GetKey(w))
        {
            direction = Vector3.forward;
            direction = direction.normalized * player_ms * 100;
            rigid.AddForce(direction);
        }

        if (Input.GetKey(s))
        {
            direction = -Vector3.forward;
            direction = direction.normalized * player_ms * 100;
            rigid.AddForce(direction);
        }

        if (Input.GetKey(a))
        {
            direction = -Vector3.right;
            direction = direction.normalized * player_ms * 100;
            rigid.AddForce(direction);
        }

        if (Input.GetKey(d))
        {
            direction = Vector3.right;
            direction = direction.normalized * player_ms * 100;
            rigid.AddForce(direction);
        }
    }


    void Movement_2()
    {
       float h = Input.GetAxisRaw("Horizontal");
       float v = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(h, 0, v);

        if (h + v > 1)
        {
            direction = direction.normalized;
        }

        if(h != 0 || v != 0)
            anim.SetBool("move", true);
        else if(h == 0 && v == 0)
            anim.SetBool("move", false);
            

        rigid.AddForce(direction * player_ms * 100);
        
    }

    void Custom_gravity()
    {
        rigid.AddForce(new Vector3(0, -gravity_power, 0));
    }


}
