using UnityEngine;
using System.Collections;

public class skySword_projectile : MonoBehaviour {



    private int skySword_level;
    private GameObject[] enemies;
    BonusController bonus;

    [SerializeField] float dot;
    [SerializeField] float dmg;


    void Awake()
    {
        bonus = GameObject.FindGameObjectWithTag("Player").GetComponent<BonusController>();
    }

   void Start()
    {
        skySword_level = GameObject.FindGameObjectWithTag("wSkySword").GetComponent<skySword_1H>().skySword_level;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
       
    }


    void Update()
    {
        Level_3_dot();
    }


    void OnTriggerEnter(Collider col)
    {
        foreach (GameObject enemy in enemies)
        {
            if (col.gameObject == enemy)
            {
                enemy.GetComponent<enemySts>().enemy_hp -= dmg  + bonus.BonusDmg;
            }
        }
    }

    void Level_3_dot()
    {
        if (skySword_level >=3)
        {
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < 10)
                {
                    enemy.GetComponent<enemySts>().enemy_hp -= dot * Time.deltaTime;
                }
            }
        }
    }

    void Level_2_Pull()
    {
        if (skySword_level >= 2)
        {
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < 10)
                {
                    enemy.GetComponent<Rigidbody>().AddForce((transform.position - enemy.transform.position) * 6000f);
                    print("asdsa");
                }
            }
        }
    }



}
