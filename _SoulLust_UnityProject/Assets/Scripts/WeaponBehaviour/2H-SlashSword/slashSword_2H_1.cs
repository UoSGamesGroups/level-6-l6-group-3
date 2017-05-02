using UnityEngine;
using System.Collections;

public class slashSword_2H_1 : MonoBehaviour {


    [SerializeField] private int slashSword_2H_level = 0;


    [Header("Primary sts")]
    [SerializeField] private float dmg;
    [SerializeField] private float max_cd;


    
    [Header("Level 1")]
    [SerializeField] private float pushBackPower;


    [Header("Level 2")]
    [SerializeField] private float lvl2_max_cd;


    [Header("Level 3")]
    [SerializeField] private GameObject slashProjectile;


    private Animator anim;
    int attackPattern = 1;

    private float current_cd = 0f;
    private bool onCooldown = false;
    private GameObject[] enemies;
    private GameObject player;
    BonusController bonus;

    void Awake()
    {
        bonus = GameObject.FindGameObjectWithTag("Player").GetComponent<BonusController>();
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack_1();

        Level_2_effect(); // level_2
    }

    void OnTriggerEnter(Collider col)
    {
        foreach (GameObject enemy in enemies)
        {
            if (col.gameObject == enemy)
            {
                enemy.GetComponent<enemySts>().enemy_hp -= dmg + bonus.BonusDmg;

                if (slashSword_2H_level >= 1)
                {
                    enemy.GetComponent<Rigidbody>().AddForce((enemy.transform.position - transform.position) * pushBackPower * 1000f);
                }
            }
        }
    }


    void Attack_1()
    {
        if (!onCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Level_3_effect();
                onCooldown = true;
                switch (attackPattern)
                {
                    case 1:
                        anim.SetTrigger("attackRight");
                        attackPattern = 2;
                        break;
                    case 2:
                        anim.SetTrigger("attackLeft");
                        attackPattern = 1;
                        break;
                }
            }
        }

        if (onCooldown)
        {
            current_cd += Time.deltaTime;

            if (current_cd > max_cd)
            {
                onCooldown = false;
                current_cd = 0;
            }
        }

    }
    
    void Level_2_effect()//level 2
    {
        if (slashSword_2H_level >= 2)
        {
            anim.speed = 2.5f;
            max_cd = lvl2_max_cd;
        }
    }

    void Level_3_effect()
    {
        if (slashSword_2H_level >= 3)//level 3
        {
            Instantiate(slashProjectile, transform.position, player.transform.rotation );
        }
    }

}
