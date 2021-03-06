﻿using UnityEngine;
using System.Collections;

public class scythe_2H_1 : MonoBehaviour {


    [SerializeField] private int scythe_2h_level = 0;
   

    [Header("Primary stat")]
    [SerializeField] private float scythe_dmg;

    
    [Header("Level 2 stat")]
    [SerializeField] private float scyhte_imporved_dmg;
    [SerializeField] private float max_range = 5;


    [Header("Level 3 stat")]
    [SerializeField] private float hp_leech=2f;

    private RaycastHit raycast;
    private float dist = 1000f;
    private int layer_mask;
    private float rs = 2000f;

    private MeshCollider _collider;
    private GameObject[] enemies;
    private GameObject player;
    Transform parent;
    BonusController bonus;

    void Awake()
    {
        bonus = GameObject.FindGameObjectWithTag("Player").GetComponent<BonusController>();
        layer_mask = LayerMask.GetMask("floor");
        _collider = GetComponent<MeshCollider>();
        player = GameObject.FindGameObjectWithTag("Player");

        parent = transform.parent;
    }

    IEnumerator Start()
    {
        while (true)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            yield return new WaitForSeconds(0.1f);
        }
    }


    void Update()
    {
        Range();
        Rotate_towards_mouse_pos();
    }

    void Rotate_towards_mouse_pos()
    {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 target_pos_attack;
        Vector3 target_pos_retreat;
        Quaternion target_rotation_retreat;




        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            transform.rotation = Quaternion.Euler(90f, 0, 0);
        }


        if (Physics.Raycast(mousePos, out raycast, dist, layer_mask))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                target_pos_attack = new Vector3(raycast.point.x, 1f, raycast.point.z);
                transform.position = Vector3.Lerp(transform.position, target_pos_attack, Time.deltaTime * 4f);

                transform.Rotate(rs * Time.deltaTime * -Vector3.forward);
                _collider.enabled = true;
                transform.parent = player.transform;
            }
            else
            {
                target_pos_retreat = new Vector3(1.8f, -0.39f, 0.94f);
                target_rotation_retreat = Quaternion.Euler(-70f, 75f, -8f);
                transform.localPosition = Vector3.Lerp(transform.localPosition, target_pos_retreat, Time.deltaTime * 15f);
                transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation_retreat, Time.deltaTime * 20f);
                _collider.enabled = false;
                transform.parent = parent;
            } 
        }
    }


    void Range()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, -1f, max_range));

        if (scythe_2h_level >= 2)
        {
            max_range = 14f;
        }
    }


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "enemy")
            {
                switch (scythe_2h_level)
                {
                    case 0:
                        col.gameObject.GetComponent<enemySts>().enemy_hp -= (scythe_dmg+bonus.BonusDmg) * Time.deltaTime;
                        break;

                    case 1:
                        col.gameObject.GetComponent<enemySts>().enemy_hp -= (scythe_dmg +bonus.BonusDmg)* Time.deltaTime;
                        col.gameObject.GetComponent<debuffsOnEnemy>().slowDuration = 0.5f;
                        break;

                    case 2:
                        col.gameObject.GetComponent<enemySts>().enemy_hp -= scyhte_imporved_dmg * Time.deltaTime;
                        col.gameObject.GetComponent<debuffsOnEnemy>().slowDuration = 0.5f;
                        break;

                    case 3:
                        col.gameObject.GetComponent<enemySts>().enemy_hp -= scyhte_imporved_dmg * Time.deltaTime;
                        col.gameObject.GetComponent<debuffsOnEnemy>().slowDuration = 0.5f;
                        player.GetComponent<playerSts>().current_player_hp += hp_leech * Time.deltaTime;
                        break;
                }
            }
    }



}
